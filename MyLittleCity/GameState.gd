class_name GameState

var year:int = 1900
var month:int = 1
var simulationStep:int = 0

var money: int

# 2 bits per tile : road and power line
var connectionMap:Array

var terrainType:int
var taxRate:int

var residentialPopulation:int
var industrialPopulation:int
var commercialPopulation:int

var taxesCollected:int = 0
var policeBudget:int = 0
var fireBudget:int = 0
var roadBudget:int = 0

var timeToNextDisaster:int = 0

var buildings:Array

func init():
	taxRate = Constants.STARTING_TAX_RATE
	timeToNextDisaster = Constants.MAX_TIME_BETWEEN_DISASTERS
	money = Constants.STARTING_FUNDS
