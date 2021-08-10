using Godot;

namespace MyLittleCity.Scripts.MyLittleCity.Buildings
{
    public class LowDensityResidentialUpgrade : Building
    {
        public LowDensityResidentialUpgrade(GameState gameState, int x, int y, TileMap tileMap, Navigation2D navigation2D)
            : base(BuildType.ResidentialUpgrade, gameState, x, y, tileMap, navigation2D)
        {
        }
    }
}