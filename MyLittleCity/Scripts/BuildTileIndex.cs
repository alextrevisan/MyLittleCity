using MyLittleCity.Scripts.MyLittleCity;

namespace MyLittleCity.Scripts
{
    public struct BuildTileIndex
    {
        public int this[BuildType buildType]
        {
            get
            {
                switch (buildType)
                {
                    case BuildType.LowDensityResidential:
                        return 2;
                    
                    case BuildType.LowDensityComercial:
                        return 3;
                    
                    case BuildType.LowDensityIndustrial:
                        return 1;
                    
                    case BuildType.Road:
                        return 0;
                    case BuildType.WindTurbineLow:
                        return 8;
                    case BuildType.WindTurbineHigh:
                        return 9;
                    
                    case BuildType.RemoveTile:
                    default:
                        return -1;
                }
            }
        }
    }
}