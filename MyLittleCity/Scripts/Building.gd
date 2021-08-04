class_name Building

var buildType:int
var powerAmount:int
var isPoweLine:bool
var populationDensity:int
var onFire:bool
var x:int
var y:int
var gameState
var tileMap:TileMap
var timer:Timer
var removed:bool = false

const UpgradeResidentialIndex:Dictionary = {
	0:2,
	1:4,
	2:5,
	3:4,
	4:4,
}
const TaxGenerated:Dictionary = {
	0:0,
	1:1,
	2:3,
	3:3,
	4:4,
}

func _init(_buildType:int, _gameState, _x:int, _y:int, _tileMap:TileMap):
	buildType = _buildType
	powerAmount = 0
	isPoweLine = buildType >= Constants.LOW_DENSITY_RESIDENTIAL && buildType <= Constants.LOW_DENSITY_INDUSTRIAL
	populationDensity = 0
	onFire = false
	gameState = _gameState
	x = _x
	y = _y
	tileMap = _tileMap
	
	if(buildType >= Constants.LOW_DENSITY_RESIDENTIAL && buildType <= Constants.LOW_DENSITY_INDUSTRIAL):
		upgrade_buildings()
	
func Tick():
	if Constants.Upkeep[buildType] != 0:
		gameState.Subtract(Constants.Upkeep[buildType])
	if buildType == Constants.LOW_DENSITY_RESIDENTIAL:
		gameState.Add(TaxGenerated[populationDensity])
func Remove():
	removed = true
	
func BuildingCanUpgrade():
	var topBuilding = gameState.GetBuilding(x, y-1)
	match populationDensity:
		Constants.HOUSE_1x2:
			if topBuilding == null:
				return false
			if topBuilding.buildType != buildType:
				return false
			if gameState.GetBuilding(x, y-1).populationDensity <= populationDensity:
				return true
	return false
	
func upgrade_buildings():
	yield(tileMap.get_tree().create_timer(2.0), "timeout")
	if removed:
		return
	var maxDensity = 1
	var cell = tileMap.get_cell(x,y-1)
	#print("cell = %d" % cell)
	if cell == Constants.LOW_DENSITY_RESIDENTIAL || cell == 2 || cell == 4 || cell == 6:
		maxDensity = 2
		
	populationDensity = min(populationDensity + 1, maxDensity)
	
	if BuildingCanUpgrade():
		gameState.AddBuilding(Constants.REMOVE_TILE, x, y-1)#remove previous building to upgrade
		tileMap.set_cell(x,y-1,UpgradeResidentialIndex[populationDensity]+1,false, false, false, Vector2(0,0))

	tileMap.set_cell(x,y,UpgradeResidentialIndex[populationDensity],false, false, false, Vector2(0,0))
	
	return upgrade_buildings()
