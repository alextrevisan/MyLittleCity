using Godot;

namespace MyLittleCity.Scripts.MyLittleCity.Buildings
{
    public class WindTurbine : Building
    {
        public WindTurbine(GameState gameState, int x, int y, TileMap tileMap, Navigation2D navigation2D) 
            : base(BuildType.WindTurbine, gameState, x, y, tileMap, navigation2D)
        {
            TileMap.SetCell(x, y - 1, BuildTileIndex[MenuItems.WindTurbine] + 1, false, false, false,
                Vector2.Zero);
        }

        
        public override void Remove()
        {
            base.Remove();
            TileMap.SetCell(X, Y - 1, -1, false, false, false,
                Vector2.Zero);
        }
    }
}