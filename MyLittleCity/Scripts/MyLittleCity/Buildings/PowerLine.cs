using Godot;

namespace MyLittleCity.Scripts.MyLittleCity.Buildings
{
    public class PowerLine : Building
    {
        public PowerLine(GameState gameState, int x, int y, TileMap tileMap, Navigation2D navigation2D) : base(BuildType.PowerLine, gameState, x, y, tileMap, navigation2D)
        {
        }
    }
}