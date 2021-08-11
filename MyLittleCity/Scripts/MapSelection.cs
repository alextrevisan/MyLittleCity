using System.Collections.Generic;
using Godot;

namespace MyLittleCity.Scripts
{
	public class MapSelection : Node2D
	{
		private AnimatedSprite _selection1X;
		private AnimatedSprite _windTurbine;
		private readonly List<AnimatedSprite> _sprites = new List<AnimatedSprite>();
		public override void _Ready()
		{
			
			_selection1X = GetNode<AnimatedSprite>("selection_1x");
			_sprites.Add(_selection1X);
			_sprites.Add(_selection1X);
			_sprites.Add(_selection1X);
			_sprites.Add(_selection1X);
			_sprites.Add(_selection1X);
			_windTurbine = GetNode<AnimatedSprite>("wind_turbine");
			_sprites.Add(_windTurbine);
			_sprites.Add(_selection1X);
		}
		private void _on_GameUI_OnSelectedIconPosition(int index)
		{
			foreach (var sprite in _sprites)
			{
				sprite.Visible = false;
			}
			
			if (index > _sprites.Count)
			{
				_selection1X.Visible = true;
				return;
			}

			_sprites[index].Visible = true;
		}
	}
}



