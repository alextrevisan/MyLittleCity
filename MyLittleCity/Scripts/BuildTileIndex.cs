using MyLittleCity.Scripts.MyLittleCity;

namespace MyLittleCity.Scripts
{
    public struct BuildTileIndex
    {
        public int this[MenuItems menuItem]
        {
            get
            {
                switch (menuItem)
                {
                    case MenuItems.LowDensityResidential:
                        return 2;
                    
                    case MenuItems.LowDensityComercial:
                        return 3;
                    
                    case MenuItems.LowDensityIndustrial:
                        return 1;
                    
                    case MenuItems.Road:
                        return 0;
                    
                    case MenuItems.RemoveTile:
                    default:
                        return -1;
                }
            }
        }
    }
}