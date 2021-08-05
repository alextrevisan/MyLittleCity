extends Node

class_name GameState

var _currentMoney:int = 70000
var _currentMonth:int = 0
var _currentYear:int = 1900
var _currentMap:Array

onready var tileMap:TileMap = $"../TileMap/Navigation2D/GameTileMap"

func _init():
	_currentMap.resize(60)
	for x in 60:
		_currentMap[x] = []
		_currentMap[x].resize(60)
		
			
	
func Add(value:int):
	_currentMoney = _currentMoney + value
	Debounce.Debounce(funcref(self, "EmitSignalUpdateValues"))
	

func Subtract(value:int):
	_currentMoney = _currentMoney - value
	Debounce.Debounce(funcref(self, "EmitSignalUpdateValues"))

func EmitSignalUpdateValues():
	emit_signal("update_values")

func GetMoney()->int:
	return _currentMoney
	
func GetMoneyStr()->String:
	return "$ %d" % _currentMoney

func GetDateStr()->String:
	return "%s %d" % [Constants.Months[_currentMonth], _currentYear]

func GetBuilding(x, y):
	return _currentMap[x][y]

func AddBuilding(building:int, x:int, y:int):
	if building == Constants.REMOVE_TILE:
		if _currentMap[x][y] == null:
			return
		_currentMap[x][y].Remove()
		_currentMap[x][y] = null
	else:
		if _currentMap[x][y] != null:
			_currentMap[x][y].Remove()
		_currentMap[x][y] = Building.new(building, self, x, y, tileMap)
	

func GetCurrentMap()->Array:
	return _currentMap

signal update_values

var roadCount:int = 0

func _on_GameTimerTick():
	for row in _currentMap:
		for tile in row:
			if tile is Building:
				tile.Tick()
				
	_currentMonth += 1
	if _currentMonth >= 12:
		_currentYear += 1
		_currentMonth = 0
				
