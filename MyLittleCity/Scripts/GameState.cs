#nullable enable

using System;
using System.Collections.Generic;
using Godot;
using MyLittleCity.Scripts.MyLittleCity;
using MyLittleCity.Scripts.MyLittleCity.Buildings;
using MyLittleCity.Scripts.Utils;

namespace MyLittleCity.Scripts
{
	public class GameState : Node
	{
		public int Money { get; private set; } = 70000;

		public string MoneyString => $"$ {Money}";

		private DateTime _dateTime = new (1900, 1, 1);

		public string DateString => $"{_dateTime:MMM yyyy}";
		public static List<List<Building?>> Building { get; } = new ();
		
		private TileMap? _tileMap;
		private Navigation2D? _roadsNavigation2D;
		private Navigation2D? _powerLinesNavigation2D;
		private BuildingFactory _buildingFactory;

		public override void _Ready()
		{
			base._Ready();
			_tileMap = GetNode<TileMap>("../TileMap/Navigation2D/GameTileMap");
			_roadsNavigation2D = GetNode<Navigation2D>("../TileMap/Navigation2D");
			for (var x = 0; x < 60; x++)
			{
				Building.Add(new List<Building?>());
				for (var y = 0; y < 60; y++)
				{
					Building[x].Add(null);
				}
			}

			_buildingFactory = new BuildingFactory(this, _tileMap, _roadsNavigation2D);
		}
		

		public void AddMoney(int value)
		{
			Money += value;
			EmitSignal("UpdateValues");
		}
		
		public void SubtractMoney(int value)
		{
			Money -= value;
			EmitSignal("UpdateValues");
		}

		public void ExecuteAction(MenuItems menuItem, int x, int y)
		{
			if (menuItem == MenuItems.RemoveTile)
			{
				var building = Building[x][y];
				Building[x][y] = null;
				building?.Remove();
			}
			else
			{
				Building[x][y]?.Remove();
				Building[x][y] = _buildingFactory.Make(MenuItemToBuildType[menuItem], x, y);
			}
		}

		[Signal]
		public delegate void UpdateValues();

		public void _on_GameTimerTick()
		{
			foreach (var row in Building)
			{
				foreach (var building in row)
				{
					building?.Tick();
				}
			}


			_dateTime = _dateTime.AddMonths(1);
		}

		private MenuItemToBuildType MenuItemToBuildType { get; }
	}
}

#nullable disable
