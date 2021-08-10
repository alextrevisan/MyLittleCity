using Godot;
using MyLittleCity.Scripts.MyLittleCity;
using MyLittleCity.Scripts.MyLittleCity.Buildings;

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

        public void ExecuteAction(MenuItems menuItem, int x, int y)
        {
            if (!CanExecuteAction(menuItem, x, y)) return;
            
            _gameState.SubtractMoney(BuildPrices[menuItem]);

            _gameState.ExecuteAction(menuItem, x, y);
            _tilemap.UpdateBitmaskRegion();
        }

        bool CanRemoveTile(int x, int y)
        {
            return GameState.Building[x][y] != null;
        }

        private bool CanExecuteAction(MenuItems menuItem, int x, int y)
        {
            if (!HasMoney(menuItem))
                return false;
            
            if (menuItem == MenuItems.RemoveTile)
                return CanRemoveTile(x, y);
            
            return CanInserTileFor.Building(menuItem, x, y);
        }

        private bool HasMoney(MenuItems menuItem)
        {
            return _gameState.Money > BuildPrices[menuItem];
        }
        
        private BuildPrices BuildPrices { get; }
    }
}