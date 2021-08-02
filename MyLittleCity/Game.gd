extends Node2D

onready var ui_info = $"Control/ui_info"
onready var ui_info_timer = $"Control/ui_info_timer"
onready var tilemap = $"TileMap"
onready var gameTilemap = $"TileMap/GameTileMap"
onready var mapPosition:Vector2 = tilemap.position

onready var icon_list = $"Control/icon_list"
onready var menuPosition:Vector2 = icon_list.position
onready var startPosition = menuPosition
onready var currentTileX:int = 6
onready var currentTileY:int = 6

var selectedIconPosition:Vector2 = Vector2(0,0)
var isSelectingMenu:bool = true
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
const menuMoveScale:int = 10

func _ready():
	$"mapSelection".visible = !isSelectingMenu
	

func _on_ui_info_timer_timeout():
	display_year = !display_year;
	if(display_year == true):
		ui_info.text = "Mar 1900"
	else:
		ui_info.text = "$999.000"
		
func _physics_process(delta):
	if isSelectingMenu:
		var result = lerp(icon_list.position,menuPosition,delta*10)
		icon_list.position = result
	else:
		var result = lerp(tilemap.position,mapPosition,delta*10)
		tilemap.position = result

	
func _input(event):
	if event.is_action_pressed("input_b", false):
		isSelectingMenu = !isSelectingMenu
		$"Control/selection_2x".visible = isSelectingMenu
		$"Control/icon_list".visible = isSelectingMenu
		$"mapSelection".visible = !isSelectingMenu
	if event.is_action_pressed("input_a", false):
		if !isSelectingMenu:
			if gameTilemap.get_cell(currentTileX,currentTileY) == -1:
				gameTilemap.set_cell(currentTileX,currentTileY,buildTilesIndex[currentMenuSelected],false, false, false,buildTilesOffset[currentMenuSelected])
				gameTilemap.update_bitmask_region()
		else:
			isSelectingMenu = !isSelectingMenu
			$"Control/selection_2x".visible = isSelectingMenu
			$"Control/icon_list".visible = isSelectingMenu
			$"mapSelection".visible = !isSelectingMenu
		
	if isSelectingMenu:
		if event.is_action_pressed("ui_left", false):
			if selectedIconPosition.x >= 10:
				selectedIconPosition.x -= 10
				menuPosition.x += menuMoveScale
				currentMenuSelected -= 1
		if event.is_action_pressed("ui_right", false):
			if selectedIconPosition.x <= 70:
				selectedIconPosition.x += 10
				menuPosition.x -= menuMoveScale
				currentMenuSelected += 1
		$"Control/selectedItemMenu".texture.set_region(Rect2(selectedIconPosition.x, 0,10,10))
	else:
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
