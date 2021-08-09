using Godot;

namespace MyLittleCity.Scripts.MyLittleCity.Buildings
{
    public class LowDensityComercialBuilding : Building
    {
        public LowDensityComercialBuilding(GameState gameState, int x, int y, TileMap tileMap, Navigation2D navigation2D) : base(BuildType.LowDensityResidential, gameState, x, y, tileMap, navigation2D)
        {
            
        }
    }
}