using System;
using System.Timers;
using Godot;
using Object = Godot.Object;

namespace MyLittleCity.Scripts.MyLittleCity
{
    public class Building
    {
        public BuildType BuildType { get; private set; }
        public int PowerAmount { get; set; }

        private int _populationDensity;
        private bool _onFire;
        private int _x;
        private int _y;
        private GameState _gameState;
        private TileMap _tileMap;
        private bool _removed;
        private System.Timers.Timer aTimer;
        private static Mutex _mutex = new ();
        public bool CanUpgrade()
        {
            return false;
            
        }

        public bool IsPowerLine()
        {
            return true;
            
        }

        public Building(BuildType buildType, GameState gameState, int x, int y, TileMap tileMap)
        {
            BuildType = buildType;
            _gameState = gameState;
            _x = x;
            _y = y;
            _tileMap = tileMap;
            PowerAmount = 0;
            _populationDensity = 0;
            _onFire = false;
            _removed = false;
            SetTimer();
        }

        public void Remove()
        {
            _removed = true;
            
            if (BuildType != BuildType.LowDensityResidential) return;
            
            if (_populationDensity == 2)
                _gameState.ExecuteAction(MenuItems.RemoveTile, _x, _y - 1);
        }

        public void Tick()
        {
            if (BuildType == BuildType.ResidentialUpgrade)
                return;
            
            _gameState.SubtractMoney(Upkeep[BuildType]);
            
            if(BuildType == BuildType.LowDensityResidential)
                _gameState.AddMoney(TaxGenerated[_populationDensity]);
        }

        private TaxGenerated TaxGenerated { get; }

        private Upkeep Upkeep { get; }
        
        private void SetTimer()
        {
            aTimer = new System.Timers.Timer(2000);
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = false;
            aTimer.Enabled = true;
        }

        private void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            _mutex.Lock();
            if (_removed || BuildType == BuildType.ResidentialUpgrade)
            {
                _mutex.Unlock();
                return;
            }
                
            var maxDensity = 1;
            var topBuilding = _gameState.Building[_x][_y - 1];
            if (topBuilding is not null)
            {
                if (topBuilding.BuildType is BuildType.LowDensityResidential or BuildType.ResidentialUpgrade && topBuilding._populationDensity <= _populationDensity)
                    maxDensity = 2;
            }

            _populationDensity = Math.Min(_populationDensity + 1, maxDensity);
            CheckForResidentialUpgrade();
            aTimer.Start();
            _mutex.Unlock();
        }

        private bool ResidentialCanUpgrade()
        {
            var topBuilding = _gameState.Building[_x][_y - 1];
            if (topBuilding == null)
                return false;
            switch (_populationDensity)
            {
                case 2:
                {
                    if (topBuilding.BuildType != BuildType)
                        return false;
                    if (topBuilding._populationDensity <= _populationDensity)
                        return true;
                    return false;
                }
                default:
                    return false;
            }
        }
        
        private void CheckForResidentialUpgrade()
        {
            //using var locker = new MutexLocker(_mutex);
            
            if (BuildType != BuildType.LowDensityResidential)
            {
                return;
            }
                
            if (ResidentialCanUpgrade())
            {
                _gameState.ExecuteAction(MenuItems.ResidentialUpgrade, _x, _y - 1);
                _tileMap.SetCell(_x, _y -1, UpgradeResidential[_populationDensity]+1, false, false, false, new Vector2(0,0));
            }
            _tileMap.SetCell(_x, _y, UpgradeResidential[_populationDensity], false, false, false, new Vector2(0,0));
        }

        private static readonly int[] UpgradeResidential = {2,4,5,4,4};
    }
}