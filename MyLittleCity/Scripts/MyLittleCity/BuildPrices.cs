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
                        return LowDensityResidentialPrice;
                    case MenuItems.LowDensityComercial:
                        return LowDensityComercialPrice;
                    case MenuItems.LowDensityIndustrial:
                        return LowDensityIndustrialPrice;
                    case MenuItems.Road:
                        return RoadPrice;
                    case MenuItems.RemoveTile:
                        return RemoveTilePrice;
                    default:
                        return 0;
                }
            }
        }

        private const int LowDensityResidentialPrice = 0;
        private const int LowDensityComercialPrice = 0;
        private const int LowDensityIndustrialPrice = 0;
        private const int RoadPrice = 200;
        private const int RemoveTilePrice = 50;
    }
}