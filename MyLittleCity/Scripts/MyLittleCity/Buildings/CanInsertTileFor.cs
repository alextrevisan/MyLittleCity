
namespace MyLittleCity.Scripts.MyLittleCity.Buildings
{
    struct CanInserTileFor
    {
        public static bool Building(MenuItems menuItem, int x, int y)
        {
            switch (menuItem)
            {
                case MenuItems.WindTurbineLow:
                    return GameState.Building[x][y] is null && GameState.Building[x][y - 1] is null;
                default:
                    return GameState.Building[x][y] is null;
            }
        }
    }
}