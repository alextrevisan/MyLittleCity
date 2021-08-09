using Godot;

namespace MyLittleCity.Scripts.MyLittleCity.Buildings
{
    public class Road : Building
    {
        public Road(GameState gameState, int x, int y, TileMap tileMap, Navigation2D navigation2D) 
            : base(BuildType.Road, gameState, x, y, tileMap, navigation2D)
        {
        }

        public override void Tick()
        {
            base.Tick();
            GameState.SubtractMoney(Upkeep[BuildType]);
        }
        
        
    }
}