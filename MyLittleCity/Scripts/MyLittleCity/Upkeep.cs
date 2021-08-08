namespace MyLittleCity.Scripts.MyLittleCity
{
    public struct Upkeep
    {
        public int this[BuildType buildType]
        {
            get
            {
                switch (buildType)
                {
                    case BuildType.LowDensityResidential:
                        return LowDensityResidentialPrice;
                    
                    case BuildType.ResidentialUpgrade:
                        return LowDensityResidentialPrice;
                    
                    case BuildType.LowDensityComercial:
                        return LowDensityComercialPrice;
                    
                    case BuildType.LowDensityIndustrial:
                        return LowDensityIndustrialPrice;
                    
                    case BuildType.Road:
                        return RoadPrice;
                    
                    default:
                        return 0;
                }
            }
        }

        private const int LowDensityResidentialPrice = 0;
        private const int LowDensityComercialPrice = 0;
        private const int LowDensityIndustrialPrice = 0;
        private const int RoadPrice = 1;
    }
}