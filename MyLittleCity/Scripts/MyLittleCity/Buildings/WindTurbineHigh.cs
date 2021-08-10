using Godot;

namespace MyLittleCity.Scripts.MyLittleCity.Buildings
{
    public class WindTurbineHigh : Building
    {
        public WindTurbineHigh(GameState gameState, int x, int y, TileMap tileMap, Navigation2D navigation2D) 
            : base(BuildType.WindTurbineHigh, gameState, x, y, tileMap, navigation2D)
        {
        }

        
        public override void Remove()
        {
            base.Remove();
            if(GameState.Building[X][Y + 1] is not null)
                GameState.ExecuteAction(MenuItems.RemoveTile, X, Y + 1);
        }
    }
}