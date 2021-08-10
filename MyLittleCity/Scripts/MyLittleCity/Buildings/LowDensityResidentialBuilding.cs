using System;
using System.Linq;
using System.Timers;
using Godot;

namespace MyLittleCity.Scripts.MyLittleCity.Buildings
{
    public class LowDensityResidentialBuilding : Building
    {
        private int PopulationDensity;
        public LowDensityResidentialBuilding(GameState gameState, int x, int y, TileMap tileMap, Navigation2D navigation2D) : base(BuildType.LowDensityResidential, gameState, x, y, tileMap, navigation2D)
        {
            PopulationDensity = 0;
            Timer.AutoReset = false;
        }

        public override void Remove()
        {
            base.Remove();
            if (PopulationDensity == 2)
            {
                GameState.ExecuteAction(MenuItems.RemoveTile, X, Y - 1);
            }
        }

        protected override void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            lock (Mutex)
            {
                base.OnTimedEvent(sender, e);
                if (Removed)
                {
                    return;
                }

                var nearestRoad = GetNearestRoad();

                var houseHasRoad = nearestRoad is not null;

                var maxDensity = houseHasRoad ? 1 : 0;
                var topBuilding = GameState.Building[X][Y - 1];
                if (topBuilding is not null && houseHasRoad)
                {
                    if (topBuilding.BuildType is BuildType.LowDensityResidential or BuildType.ResidentialUpgrade &&
                        ((LowDensityResidentialBuilding)topBuilding).PopulationDensity <= PopulationDensity)
                        maxDensity = 2;
                }

                if (nearestRoad is not null)
                {
                    var globalStartPos = TileMap.MapToWorld(new Vector2(-10, 16));
                    var globalEndPos = TileMap.MapToWorld(new Vector2(X, Y));


                    var path = Navigation2D.GetSimplePath(globalStartPos, globalEndPos, false).ToList();

                    if (path.Count > 0 && !HasCar)
                    {
                        HasCar = true;
                        var ground = ResourceLoader.Load<PackedScene>("res://scenes/Car.tscn");
                        var car = (Car)ground.Instance();
                        car.SetBuilding(this);
                        car.SetPath(path);
                        TileMap.AddChild(car);
                    }

                }

                if (CarArrived)
                    PopulationDensity = Math.Min(PopulationDensity + 1, maxDensity);
                ExecuteResidentialUpgrade();
                Timer.Start();
            }
        }

        public override void Tick()
        {
            base.Tick();
            GameState.AddMoney(TaxGenerated[PopulationDensity]);
        }

        private void ExecuteResidentialUpgrade()
        {
            if (BuildType != BuildType.LowDensityResidential)
            {
                return;
            }
                
            if (ResidentialCanUpgrade())
            {
                GameState.ExecuteAction(MenuItems.ResidentialUpgrade, X, Y - 1);
                TileMap.SetCell(X, Y -1, UpgradeResidential[PopulationDensity]+1, false, false, false, new Vector2(0,0));
            }
            TileMap.SetCell(X, Y, UpgradeResidential[PopulationDensity], false, false, false, new Vector2(0,0));
        }
        
        private bool ResidentialCanUpgrade()
        {
            var topBuilding = GameState.Building[X][Y - 1];
            if (topBuilding is not LowDensityResidentialBuilding building)
                return false;

            return PopulationDensity switch
            {
                2 => building.PopulationDensity <= PopulationDensity,
                _ => false
            };
        }
        private static readonly int[] UpgradeResidential = {2,4,5,4,4};
        
    }
}