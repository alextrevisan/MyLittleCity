
namespace MyLittleCity.Scripts.MyLittleCity.Buildings
{
    struct CanInserTileFor
    {
        public static bool Building(MenuItems menuItem, int x, int y)
        {
            switch (menuItem)
            {
                case MenuItems.WindTurbineLow:
                    return (GameState.Building[x][y] is null or PowerLine) && (GameState.Building[x][y - 1] is null or PowerLine);
                
                case MenuItems.LowDensityResidential:
                case MenuItems.LowDensityComercial:
                case MenuItems.LowDensityIndustrial:
                case MenuItems.Road:
                    return GameState.Building[x][y] is null or PowerLine;
                default:
                    return GameState.Building[x][y] is null;
            }
        }
    }
}