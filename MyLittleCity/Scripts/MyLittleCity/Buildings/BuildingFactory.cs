using System;
using Godot;

namespace MyLittleCity.Scripts.MyLittleCity.Buildings
{
    public class BuildingFactory
    {
        private readonly GameState _gameState;
        private readonly TileMap _tileMap;
        private readonly Navigation2D _navigation2D;
        public BuildingFactory(GameState gameState, TileMap tileMap, Navigation2D navigation2D)
        {
            _gameState = gameState;
            _tileMap = tileMap;
            _navigation2D = navigation2D;
        }
        public Building Make(BuildType buildType, int x, int y)
        {
            switch (buildType)
            {
                case BuildType.LowDensityResidential:
                    return new LowDensityResidentialBuilding(_gameState, x, y, _tileMap, _navigation2D);
                case BuildType.LowDensityComercial:
                    return new LowDensityComercialBuilding(_gameState, x, y, _tileMap, _navigation2D);
                case BuildType.LowDensityIndustrial:
                    return new LowDensityIndustrialBuilding(_gameState, x, y, _tileMap, _navigation2D);
                case BuildType.WindTurbine:
                    return new WindTurbine(_gameState, x, y, _tileMap, _navigation2D);
                case BuildType.Road:
                    return new Road(_gameState, x, y, _tileMap, _navigation2D);
                
                case BuildType.ResidentialUpgrade:
                case BuildType.RemoveTile:
                default:
                    throw new ArgumentOutOfRangeException(nameof(buildType), buildType, null);
            }
        }
    }
}