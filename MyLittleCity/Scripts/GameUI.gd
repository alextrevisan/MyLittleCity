extends Control
class_name GameUI

onready var isSelectingMenu:bool = true
onready var mapSelection:Node2D = $"mapSelection"
onready var selection2x:AnimatedSprite = $"selection_2x"
onready var icon_list:Sprite = $"icon_list"
onready var cost_label:Label = $"cost_label"
onready var selectedItemMenu:Sprite = $"selectedItemMenu"
onready var ui_info:Label = $"ui_info"
onready var gameState:GameState = $"../GameState"
onready var menuPosition:Vector2 = icon_list.position
onready var selectedIconPosition:Vector2 = Vector2(0,0)
onready var currentMenuSelected:int = 0
onready var display_year:bool = true
const menuMoveScale:int = 10

func _ready():
	mapSelection.visible = !isSelectingMenu
	ui_info.text = gameState.GetDateStr()
	updateCostLabel()
	
func _physics_process(delta):
	if !isSelectingMenu:
		return
		
	var result = lerp(icon_list.position,menuPosition,delta*10)
	icon_list.position = result
		
		
func _input(event):	
	if event.is_action_pressed("input_b", false):
		isSelectingMenu = !isSelectingMenu
		selection2x.visible = isSelectingMenu
		icon_list.visible = isSelectingMenu
		cost_label.visible = isSelectingMenu
		mapSelection.visible = !isSelectingMenu
		
	if event.is_action_pressed("input_a", false):
		if isSelectingMenu:
			isSelectingMenu = !isSelectingMenu
			selection2x.visible = isSelectingMenu
			icon_list.visible = isSelectingMenu
			cost_label.visible = isSelectingMenu
			mapSelection.visible = !isSelectingMenu
		
	if isSelectingMenu:
		if event.is_action_pressed("ui_left", false):
			updateSelectedBuilding(-1)
		if event.is_action_pressed("ui_right", false):
			updateSelectedBuilding(1)
		selectedItemMenu.texture.set_region(Rect2(selectedIconPosition.x, 0,10,10))

func updateSelectedBuilding(value:int):
	if currentMenuSelected+value >= 0 && currentMenuSelected+value <= 10:
		selectedIconPosition.x += value * 10
		menuPosition.x += -value * menuMoveScale
		currentMenuSelected += value
		updateCostLabel()
		emit_signal("onSelectedIconPosition", currentMenuSelected)
		
func updateCostLabel():
	if Constants.Upkeep[currentMenuSelected] == 0:
		cost_label.text = "$ %d" % Constants.BuildPrices[currentMenuSelected]
	else:
		cost_label.text = "$ %d/$ %d" % [Constants.BuildPrices[currentMenuSelected], Constants.Upkeep[currentMenuSelected]]
	
func updateUI():
	if(display_year == true):
		ui_info.text = gameState.GetDateStr()
	else:
		ui_info.text = gameState.GetMoneyStr()

func _on_ui_info_timer_timeout():
	display_year = !display_year
	updateUI()

func _on_GameState_update_values():
	updateUI()
	
signal onSelectedIconPosition(index)
