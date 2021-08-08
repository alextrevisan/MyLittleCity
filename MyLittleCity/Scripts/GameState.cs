#nullable enable

using System.Collections.Generic;
using Godot;
using MyLittleCity.Scripts.MyLittleCity;
using MyLittleCity.Scripts.Utils;

namespace MyLittleCity.Scripts
{
	public class GameState : Node
	{
		public int Money { get; set; } = 70000;

		public string MoneyString => $"$ {Money}";

		public int Month { get; set; } = 0;
		public int Year { get; set; } = 1900;
		
		private static readonly MonthToString MonthToString;
		
		public string DateString => $"{MonthToString[Month]} {Year}";
		public List<List<Building?>> Building { get; } = new ();
		
		private TileMap _tileMap;

		public override void _Ready()
		{
			base._Ready();
			_tileMap = GetNode<TileMap>("../TileMap/Navigation2D/GameTileMap");
			for (var x = 0; x < 60; x++)
			{
				Building.Add(new List<Building?>());
				for (var y = 0; y < 60; y++)
				{
					Building[x].Add(null);
				}
			}
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
				Building[x][y]?.Remove();
				Building[x][y] = null;
			}
			else
			{
				Building[x][y]?.Remove();
				Building[x][y] = new Building(MenuItemToBuildType[menuItem], this, x, y, _tileMap);
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


			Month ++;
			if (Month >= 12)
			{
				Year++;
				Month = 0;
			}
		}

		private MenuItemToBuildType MenuItemToBuildType { get; }
	}
}

#nullable disable
