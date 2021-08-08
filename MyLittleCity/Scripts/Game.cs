using Godot;
using System;
using MyLittleCity.Scripts;
using MyLittleCity.Scripts.MyLittleCity;

public class Game : Node2D
{
	private Node2D _tileMap;
	private TileMap _gameTileMap;
	private GameState _gameState;
	private Vector2 _mapPosition;
	private bool _isSelectingMenu = true;
	private int _currentTileX = 6;
	private int _currentTileY = 17;
	private Vector2 _selectedIconPosition = new Vector2(0, 0);
	private MenuItems _currentMenuSelected = 0;
	private bool _displayYear = true;
	private Buildings _buildings;

	private const int MapMoveScale = 5;
	
	public override void _Ready()
	{
		_tileMap = GetNode<Node2D>("TileMap");
		_gameTileMap = GetNode<TileMap>("TileMap/Navigation2D/GameTileMap");
		_gameState = GetNode<GameState>("GameState");
		_mapPosition = _tileMap.Position;
		_buildings = new Buildings(_gameTileMap, _gameState);
	}

	public override void _PhysicsProcess(float delta)
	{
		base._PhysicsProcess(delta);
		var result = new Vector2(Mathf.Lerp(_tileMap.Position.x, _mapPosition.x, delta * 10),
			Mathf.Lerp(_tileMap.Position.y, _mapPosition.y, delta * 10));
		_tileMap.Position = result;
	}

	public override void _Input(InputEvent @event)
	{
		base._Input(@event);
		if (@event.IsActionPressed("input_b", false))
		{
			_isSelectingMenu = !_isSelectingMenu;
		}

		if (@event.IsActionPressed("input_a", false) && _isSelectingMenu)
		{
			_isSelectingMenu = !_isSelectingMenu;
			return;
		}

		if (_isSelectingMenu)
			return;

		if (@event.IsActionPressed("input_a", false))
		{
			_buildings.ExecuteAction(_currentMenuSelected, _currentTileX, _currentTileY);
		}

		if (@event.IsActionPressed("ui_left", false))
		{
			if (_mapPosition.x > 25)
				return;
			_currentTileX--;
			_mapPosition.x += MapMoveScale;
		}

		if (@event.IsActionPressed("ui_right", false))
		{
			if (_mapPosition.y <= -265)
				return;
			_currentTileX++;
			_mapPosition.x -= MapMoveScale;
		}

		if (@event.IsActionPressed("ui_down", false))
		{
			_currentTileY++;
			_mapPosition.y -= MapMoveScale;
		}

		if (@event.IsActionPressed("ui_up", false))
		{
			_currentTileY--;
			_mapPosition.y += MapMoveScale;
		}
	}
	
	private void _on_GameUI_OnSelectedIconPosition(MenuItems index)
	{
		_currentMenuSelected = index;
	}
}



