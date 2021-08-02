extends Node2D
const BuildingInfo = preload("res://BuildingInfo.gd")
class_name Building

enum {
	BuildingType_None = 0,
	Residential,
	Commercial,
	Industrial,
	Powerplant,
	Park,
	PoliceDept,
	FireDept,
	Stadium,
	Rubble3x3,
	Rubble4x4,
	Num_BuildingTypes = Stadium + 1
}

#Building
var type:int
var populationDensity:int
var onFire:int
var heavyTraffic:bool
var hasPower:bool
	
var buildingInfo = [
	BuildingInfo.new(0,0,0,0),
	# None,
	BuildingInfo.new(0, 0, 0, 0),
	# Residential,
	BuildingInfo.new(100, 3, 3, 64),
	# Commercial,
	BuildingInfo.new(100, 3, 3, 67),
	# Industrial,
	BuildingInfo.new(100, 3, 3, 70),
	# Powerplant,
	BuildingInfo.new(3000, 4, 4, 160),
	# Park,
	BuildingInfo.new(50, 3, 3, 73),
	# PoliceDept,
	BuildingInfo.new(500, 3, 3, 76),
	# FireDept,
	BuildingInfo.new(500, 3, 3, 124),
	# Stadium,
	BuildingInfo.new(3000, 4, 4, 164),
	# Rubble3x3,
	BuildingInfo.new(0, 3, 3, 0),
	# Rubble4x4,
	BuildingInfo.new(0, 4, 4, 0),
]

func IsRubble(buildingType):
	return buildingType >= Rubble3x3

func GetBuildingInfor(buildingType):
	return buildingInfo[buildingType]

func PlaceBuilding(buildingType:int, x:int, y:int):
	var index = 0
	


func _ready():
	pass # Replace with function body.
