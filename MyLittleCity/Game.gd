extends Node2D

onready var GameUI = $GameUI

onready var ui_info = $"GameUI/ui_info"
onready var ui_info_timer = $"GameUI/ui_info_timer"
onready var tilemap = $"TileMap"
onready var gameTilemap = $"TileMap/GameTileMap"
onready var mapPosition:Vector2 = tilemap.position
onready var isSelectingMenu:bool = true

onready var currentTileX:int = 6
onready var currentTileY:int = 6

var selectedIconPosition:Vector2 = Vector2(0,0)
var currentMenuSelected:int = 0
var display_year = true

const buildTilesOffset:Dictionary = {
	0 : Vector2(0,0),
	1 : Vector2(0,0),
	2 : Vector2(0,0),
	3 : Vector2(3,0)
}
const buildTilesIndex:Dictionary = {
	0 : 2,
	1 : 3,
	2 : 1,
	3 : 0
}

const mapMoveScale:int = 5
	

func _physics_process(delta):
	var result = lerp(tilemap.position,mapPosition,delta*10)
	tilemap.position = result

	
func _input(event):
	if event.is_action_pressed("input_b", false):
		isSelectingMenu = !isSelectingMenu
		
	if event.is_action_pressed("input_a", false) and isSelectingMenu:
		isSelectingMenu = !isSelectingMenu
		return
		
	if isSelectingMenu:
		return
		
	if event.is_action_pressed("input_a", false):
		if gameTilemap.get_cell(currentTileX,currentTileY) == -1:
			gameTilemap.set_cell(currentTileX,currentTileY,buildTilesIndex[currentMenuSelected],false, false, false,buildTilesOffset[currentMenuSelected])
			gameTilemap.update_bitmask_region()
			
	if event.is_action_pressed("ui_left", false):
		mapPosition.x += mapMoveScale
		currentTileX -= 1
	if event.is_action_pressed("ui_right", false):
		mapPosition.x -= mapMoveScale
		currentTileX += 1
	if event.is_action_pressed("ui_down", false):
		mapPosition.y -= mapMoveScale
		currentTileY += 1
	if event.is_action_pressed("ui_up",false):
		mapPosition.y += mapMoveScale
		currentTileY -= 1


func _on_GameUI_onSelectedIconPosition(index):
	currentMenuSelected = index
