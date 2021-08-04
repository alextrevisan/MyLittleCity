
class_name Buildings

var tilemap:TileMap
var gameState:GameState



func _init(_tilemap:TileMap, _gameState:GameState):
	tilemap = _tilemap
	gameState = _gameState
	

func InsertTile(buildIndex, x, y):
	if CanExecuteAction(buildIndex, x, y):
		gameState.Subtract(Constants.BuildPrices[buildIndex])
		tilemap.set_cell(x,y,Constants.BuildTilesIndex[buildIndex],false, false, false,Constants.BuildTilesOffset[buildIndex])
		tilemap.update_bitmask_region()
		gameState.AddBuilding(buildIndex, x, y)
		
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
