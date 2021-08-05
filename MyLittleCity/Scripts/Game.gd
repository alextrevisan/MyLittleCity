extends Node2D

onready var tilemap = $"TileMap"
onready var gameTilemap = $"TileMap/Navigation2D/GameTileMap"
onready var gameState:GameState = $"GameState"
onready var mapPosition:Vector2 = tilemap.position
onready var isSelectingMenu:bool = true

onready var currentTileX:int = 6
onready var currentTileY:int = 17

var selectedIconPosition:Vector2 = Vector2(0,0)
var currentMenuSelected:int = 0
var display_year = true

onready var building:Buildings = Buildings.new(gameTilemap, gameState)

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
		building.InsertTile(currentMenuSelected, currentTileX, currentTileY)
		
			
	if event.is_action_pressed("ui_left", false):
		if mapPosition.x > 25:
			return
		currentTileX -= 1 
		mapPosition.x += mapMoveScale
		
	if event.is_action_pressed("ui_right", false):
		if mapPosition.x <= -265:
			return
		currentTileX += 1
		mapPosition.x -= mapMoveScale
		
	if event.is_action_pressed("ui_down", false):
		mapPosition.y -= mapMoveScale
		currentTileY += 1
	if event.is_action_pressed("ui_up",false):
		mapPosition.y += mapMoveScale
		currentTileY -= 1

func funcToDebounce():
	print("my function!")
	
func _on_GameUI_onSelectedIconPosition(index):
	currentMenuSelected = index
