extends Control
class_name GameUI

onready var isSelectingMenu:bool = true
onready var mapSelection:Node2D = $"mapSelection"
onready var selection2x:AnimatedSprite = $"selection_2x"
onready var icon_list:Sprite = $"icon_list"
onready var selectedItemMenu:Sprite = $"selectedItemMenu"
onready var ui_info:Label = $"ui_info"
onready var menuPosition:Vector2 = icon_list.position
onready var selectedIconPosition:Vector2 = Vector2(0,0)
onready var currentMenuSelected:int = 0
onready var display_year:bool = true
const menuMoveScale:int = 10

func _ready():
	mapSelection.visible = !isSelectingMenu
	
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
		mapSelection.visible = !isSelectingMenu
		
	if event.is_action_pressed("input_a", false):
		if isSelectingMenu:
			isSelectingMenu = !isSelectingMenu
			selection2x.visible = isSelectingMenu
			icon_list.visible = isSelectingMenu
			mapSelection.visible = !isSelectingMenu
		
	if isSelectingMenu:
		if event.is_action_pressed("ui_left", false):
			if selectedIconPosition.x >= 10:
				selectedIconPosition.x -= 10
				menuPosition.x += menuMoveScale
				currentMenuSelected -= 1
				emit_signal("onSelectedIconPosition", currentMenuSelected)
		if event.is_action_pressed("ui_right", false):
			if selectedIconPosition.x <= 70:
				selectedIconPosition.x += 10
				menuPosition.x -= menuMoveScale
				currentMenuSelected += 1
				emit_signal("onSelectedIconPosition", currentMenuSelected)
		selectedItemMenu.texture.set_region(Rect2(selectedIconPosition.x, 0,10,10))
		
func _on_ui_info_timer_timeout():
	display_year = !display_year
	if(display_year == true):
		ui_info.text = "Mar 1900"
	else:
		ui_info.text = "$999.000"
		
signal onSelectedIconPosition(index)
	
