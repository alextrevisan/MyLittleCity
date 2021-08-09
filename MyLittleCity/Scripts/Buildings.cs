using Godot;
using MyLittleCity.Scripts.MyLittleCity;

namespace MyLittleCity.Scripts
{
    public class Buildings
    {
        private TileMap _tilemap;
        private GameState _gameState;

        public Buildings(TileMap tilemap, GameState gameState)
        {
            _tilemap = tilemap;
            _gameState = gameState;
        }

        public void AddBuildingToTileMap(int x, int y, int buildTileIndex)
        {
            _tilemap.SetCell(x, y - 1, buildTileIndex, false, false, false,
                Vector2.Zero);
        }
        
        public void ExecuteAction(MenuItems menuItem, int x, int y)
        {
            if (!CanExecuteAction(menuItem, x, y)) return;
            
            _gameState.SubtractMoney(BuildPrices[menuItem]);

            _tilemap.SetCell(x, y, BuildTilesIndex[menuItem], false, false, false,
                BuildTilesOffset[menuItem]);
            if (menuItem == MenuItems.WindTurbine)
            {
                _tilemap.SetCell(x, y - 1, BuildTilesIndex[menuItem] + 1, false, false, false,
                    BuildTilesOffset[menuItem]);
            }
            _tilemap.UpdateBitmaskRegion();
            _gameState.ExecuteAction(menuItem, x, y);
        }

        bool CanRemoveTile(int x, int y)
        {
            return _gameState.Building[x][y] != null;
        }
        
        bool CanInsertTile(int x, int y)
        {
            return _gameState.Building[x][y] == null;
        }
        
        private bool CanExecuteAction(MenuItems menuItems, int x, int y)
        {
            if (!HasMoney(menuItems))
                return false;
            
            if (menuItems == MenuItems.RemoveTile)
                return CanRemoveTile(x, y);
            
            return CanInsertTile(x, y);
        }

        private bool HasMoney(MenuItems menuItem)
        {
            return _gameState.Money > BuildPrices[menuItem];
        }
        private BuildTileOffset BuildTilesOffset { get; }
        private BuildTileIndex BuildTilesIndex { get; }
        private BuildPrices BuildPrices { get; }
    }
}