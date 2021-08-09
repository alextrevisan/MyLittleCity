using Godot;
using MyLittleCity.Scripts.MyLittleCity;
using MyLittleCity.Scripts.Utils;

namespace MyLittleCity.Scripts
{
	public class GameUI : Control
	{
		private Node2D _mapSelection;
		private bool _isSelectingMenu = true;
		private bool _displayYear = true;
		private GameState _gameState;
		private Label _uiInfo;
		private Label _costLabel;
		private Sprite _iconList;
		private Sprite _selectedItemMenu;
		private AnimatedSprite _selection2X;
		private Vector2 _menuPosition;
		private MenuItems _currentMenuSelected = MenuItems.LowDensityResidential;
		private Vector2 _selectedIconPosition;
		private const int MenuMoveScale = 10;
		
		private BuildPrices BuildPrices { get; }
		private Upkeep Upkeep { get; }
		private MenuItemToBuildType MenuItemToBuildType { get; }
		
		public override void _Ready()
		{
			base._Ready();
			_mapSelection = GetNode<Node2D>("mapSelection");
			_gameState = GetNode<GameState>("../GameState");
			_uiInfo = GetNode<Label>("ui_info");
			_costLabel = GetNode<Label>("cost_label");
			_iconList = GetNode<Sprite>("icon_list");
			_selectedItemMenu = GetNode<Sprite>("selectedItemMenu");
			_selection2X = GetNode<AnimatedSprite>("selection_2x");
			_menuPosition = _iconList.Position;
			_selectedIconPosition = new Vector2(0, 0);
			
			_mapSelection.Visible = !_isSelectingMenu;
			_uiInfo.Text = _gameState.DateString;
			UpdateCostLabel();
		}

		public override void _PhysicsProcess(float delta)
		{
			base._PhysicsProcess(delta);
			if (!_isSelectingMenu)
				return;
			var result = Mathf.Lerp(_iconList.Position.x, _menuPosition.x, delta * 10);
			_iconList.Position = new Vector2(result, _menuPosition.y);
		}

		public override void _Input(InputEvent @event)
		{
			base._Input(@event);
			if (@event.IsActionPressed("input_b", false))
			{
				_isSelectingMenu = !_isSelectingMenu;
				_selection2X.Visible = _isSelectingMenu;
				_iconList.Visible = _isSelectingMenu;
				_costLabel.Visible = _isSelectingMenu;
				_mapSelection.Visible = !_isSelectingMenu;
			}

			if (@event.IsActionPressed("input_a", false))
			{
				if (_isSelectingMenu)
				{
					_isSelectingMenu = !_isSelectingMenu;
					_selection2X.Visible = _isSelectingMenu;
					_iconList.Visible = _isSelectingMenu;
					_costLabel.Visible = _isSelectingMenu;
					_mapSelection.Visible = !_isSelectingMenu;
				}
			}

			if (_isSelectingMenu)
			{
				if (@event.IsActionPressed("ui_left", false))
				{
					UpdateSelectedBuilding(-1);
				}
					
				if (@event.IsActionPressed("ui_right", false))
				{
					UpdateSelectedBuilding(1);
				}
				if (_selectedItemMenu.Texture is AtlasTexture texture)
					texture.Region = new Rect2(_selectedIconPosition.x, 0, 10, 10);
			}
		}

		private void UpdateSelectedBuilding(int value)
		{
			if (_currentMenuSelected + value >= 0 && _currentMenuSelected + value <= MenuItems.WindTurbine)
			{
				_selectedIconPosition.x += value * 10;
				_menuPosition.x += -value * MenuMoveScale;
				_currentMenuSelected += value;
				UpdateCostLabel();
				EmitSignal("OnSelectedIconPosition", _currentMenuSelected);
			}
		}

		private void UpdateCostLabel()
		{
			var currentBuildType = MenuItemToBuildType[_currentMenuSelected];
			if (Upkeep[currentBuildType] == 0)
			{
				_costLabel.Text = $"$ {BuildPrices[_currentMenuSelected]}";
				return;
			}

			_costLabel.Text = $"$ {BuildPrices[_currentMenuSelected]}/$ {Upkeep[currentBuildType]}";
		}

		public void UpdateUI()
		{
			_uiInfo.Text = _displayYear ? _gameState.DateString : _gameState.MoneyString;
		}
		
		[Signal]
		public delegate void OnSelectedIconPosition(MenuItems index);
		
		private void _onUIInfoTimerTimeout()
		{
			_displayYear = !_displayYear;
			UpdateUI();
		}
		private void _onGameStateUpdateValues()
		{
			UpdateUI();
		}
	}
}






