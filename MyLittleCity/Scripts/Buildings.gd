
class_name Buildings

var tilemap:TileMap
var gameState:GameState

const buildTilesOffset:Dictionary = {
	Constants.LOW_DENSITY_RESIDENTIAL : Vector2(0,0),
	Constants.LOW_DENSITY_COMERCIAL : Vector2(0,0),
	Constants.LOW_DENSITY_INDUSTRIAL : Vector2(0,0),
	Constants.ROAD : Vector2(3,0),
	Constants.REMOVE_TILE : Vector2(0,0)
}
const buildTilesIndex:Dictionary = {
	Constants.LOW_DENSITY_RESIDENTIAL : 2,
	Constants.LOW_DENSITY_COMERCIAL : 3,
	Constants.LOW_DENSITY_INDUSTRIAL : 1,
	Constants.ROAD : 0,
	Constants.REMOVE_TILE : -1 
}

func _init(_tilemap:TileMap, _gameState:GameState):
	tilemap = _tilemap
	gameState = _gameState
	

func InsertTile(buildIndex, x, y):
	if CanExecuteAction(buildIndex, x, y):
		gameState.Subtract(Constants.BuildPrices[buildIndex])
		tilemap.set_cell(x,y,buildTilesIndex[buildIndex],false, false, false,buildTilesOffset[buildIndex])
		tilemap.update_bitmask_region()
		
func CanExecuteAction(buildIndex, x, y):
	if !HasMoney(buildIndex):
		return false
		
	if buildIndex == Constants.REMOVE_TILE:
		if tilemap.get_cell(x,y) == -1:
			return false
		else:
			return true
		
	if tilemap.get_cell(x,y) == -1:
		return true
		
	return false
	
func HasMoney(buildIndex):
	return gameState._currentMoney > Constants.BuildPrices[buildIndex]
