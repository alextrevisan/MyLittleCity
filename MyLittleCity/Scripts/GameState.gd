extends Node

class_name GameState

var _currentMoney:int = 70000
var _currentMonth:int = 0
var _currentYear:int = 1900

var _currentMap:Array

func Add(value:int):
	_currentMoney = _currentMoney + value
	emit_signal("update_values")

func Subtract(value:int):
	_currentMoney = _currentMoney - value
	emit_signal("update_values")

func GetMoney()->int:
	return _currentMoney
	
func GetMoneyStr()->String:
	return "$ %d" % _currentMoney

func GetDateStr()->String:
	return "%s %d" % [Constants.Months[_currentMonth], _currentYear]

func GetCurrentMap()->Array:
	return _currentMap

signal update_values
