namespace MyLittleCity.Scripts.MyLittleCity
{
    public struct BuildingUpkeep
    {
        public int this[BuildType buildType]
        {
            get
            {
                switch (buildType)
                {
                    case BuildType.LowDensityResidential:
                        return 0;
                    
                    case BuildType.ResidentialUpgrade:
                        return 0;
                    
                    case BuildType.LowDensityComercial:
                        return 0;
                    
                    case BuildType.LowDensityIndustrial:
                        return 0;
                    
                    case BuildType.Road:
                        return 1;
                    
                    default:
                        return 0;
                }
            }
        }
    }
}