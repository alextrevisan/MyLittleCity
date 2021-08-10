using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using Godot;
using Object = Godot.Object;

namespace MyLittleCity.Scripts.MyLittleCity
{
    public abstract class Building
    {
        public BuildType BuildType { get; private set; }
        public int PowerAmount { get; set; }

        protected static BuildTileIndex BuildTilesIndex { get; }
        protected static BuildTileOffset BuildTilesOffset { get; }
        
        protected readonly int X;
        protected readonly int Y;
        protected readonly GameState GameState;
        public readonly TileMap TileMap;
        protected bool Removed;
        protected System.Timers.Timer Timer;
        protected static readonly Mutex Mutex = new ();
        protected readonly Navigation2D Navigation2D;
        private static Vector2 _startPos = new Vector2(-48, 58);
        protected bool HasCar = false;
        public bool CarArrived = false;
        public virtual bool CanUpgrade()
        {
            return false;
        }

        public virtual bool IsPowerLine()
        {
            return true;
        }

        protected Vector2? GetNearestRoad()
        {
            if (BuildType != BuildType.LowDensityResidential)
                return null;
            var minX = Math.Max(0, X - 2);
            var minY = Math.Max(0, Y - 2);
            var maxX = Math.Min(60, X + 2);
            var maxY = Math.Min(60, Y + 2);
            
            for (var x = minX; x <= maxX; x++)
            {
                for (var y = minY; y <= maxY; y++)
                {
                    if (GameState.Building[x][y]?.BuildType == BuildType.Road)
                        return new Vector2(x, y);
                }
            }

            return null;
        }

        protected Building(BuildType buildType, GameState gameState, int x, int y, TileMap tileMap, Navigation2D navigation2D)
        {
            BuildType = buildType;
            GameState = gameState;
            X = x;
            Y = y;
            TileMap = tileMap;
            Navigation2D = navigation2D;
            PowerAmount = 0;
            Removed = false;
            SetTimer();
            var buildTileIndex = BuildTilesIndex[buildType];
            TileMap.SetCell(x, y, buildTileIndex, false, false, false,
                BuildTilesOffset[buildType]);
        }

        protected static BuildTileIndex BuildTileIndex { get; }
        protected static Upkeep Upkeep { get; }
        protected static TaxGenerated TaxGenerated { get; }
        
        public virtual void Remove()
        {
            Removed = true;
            TileMap.SetCell(X, Y, -1, false, false, false,
                Vector2.Zero);
        }

        public virtual void Tick()
        {

        }
        
        private void SetTimer()
        {
            Timer = new System.Timers.Timer(2000);
            Timer.Elapsed += OnTimedEvent;
            Timer.AutoReset = true;
            Timer.Enabled = true;
        }

        protected virtual void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            if(Removed)
                Timer.Stop();
        }
    }
}