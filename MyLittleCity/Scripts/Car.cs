using System.Collections.Generic;
using System.Linq;
using Godot;
using MyLittleCity.Scripts.MyLittleCity;

namespace MyLittleCity.Scripts
{
	public class Car : Node2D
	{
		private List<Vector2> _path;
		private Building _building;
		private const float Speed = 8.0f;
		private Vector2 _virtualPosition;
		public override void _Ready()
		{
			//SetProcess(false);
		}

		public override void _Process(float delta)
		{
			base._Process(delta);
			if (_path is null || _path.Count == 0)
			{
				_building.CarArrived = true;
				QueueFree();
				return;
			}
				
			var moveDistance = delta * Speed;
			MoveAlongPath(moveDistance);
		}

		private void MoveAlongPath(float distance)
		{
			var startPoint = _virtualPosition;
			if (_path.Count == 0)
			{
				SetProcess(false);
				return;
			}
			var distanceToNextPoint = startPoint.DistanceTo(_path[0]);
			if (distance <= distanceToNextPoint && distance > 0)
			{
				var position = startPoint.LinearInterpolate(_path[0], distance / distanceToNextPoint);
				_virtualPosition = position;
				var mapPosition = _building.TileMap.WorldToMap(position);
				Position = _building.TileMap.MapToWorld(mapPosition);
			}
			else
			{
				//Position = _path[0];
				_path.RemoveAt(0);
			}
		}

		public void SetPath(List<Vector2> path)
		{
			if (path.Count == 0)
				return;

			_path = path;
			Position = _path[0];
			_virtualPosition = _path[0];
			_path.RemoveAt(0);
			SetProcess(true);
		}
		public void SetBuilding(Building building)
		{
			_building = building;
		}
	}
}
