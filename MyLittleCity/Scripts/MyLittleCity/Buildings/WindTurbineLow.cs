using Godot;

namespace MyLittleCity.Scripts.MyLittleCity.Buildings
{
    public class WindTurbineLow : Building
    {
        public WindTurbineLow(GameState gameState, int x, int y, TileMap tileMap, Navigation2D navigation2D) 
            : base(BuildType.WindTurbineLow, gameState, x, y, tileMap, navigation2D)
        {
            gameState.ExecuteAction(MenuItems.WindTurbineHigh, x, y - 1);
        }

        
        public override void Remove()
        {
            base.Remove();
            if(GameState.Building[X][Y - 1] is not null)
                GameState.ExecuteAction(MenuItems.RemoveTile, X, Y - 1);
        }
    }
}