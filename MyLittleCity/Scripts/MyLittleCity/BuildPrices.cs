namespace MyLittleCity.Scripts.MyLittleCity
{
    public struct BuildPrices
    {
        public int this[MenuItems menuItem]
        {
            get
            {
                switch (menuItem)
                {
                    case MenuItems.LowDensityResidential:
                        return 0;
                    case MenuItems.LowDensityComercial:
                        return 0;
                    case MenuItems.LowDensityIndustrial:
                        return 0;
                    case MenuItems.Road:
                        return 200;
                    case MenuItems.RemoveTile:
                        return 50;
                    case MenuItems.WindTurbineLow:
                        return 5000;
                    default:
                        return 0;
                }
            }
        }
    }
}