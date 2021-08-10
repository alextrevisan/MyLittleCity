using MyLittleCity.Scripts.MyLittleCity;

namespace MyLittleCity.Scripts
{
    public struct BuildTileIndex
    {
        public int this[BuildType buildType]
        {
            get
            {
                return buildType switch
                {
                    BuildType.LowDensityResidential => 2,
                    BuildType.LowDensityComercial => 3,
                    BuildType.LowDensityIndustrial => 1,
                    BuildType.Road => 0,
                    BuildType.WindTurbineLow => 8,
                    BuildType.WindTurbineHigh => 9,
                    BuildType.RemoveTile => -1,
                    _ => -1
                };
            }
        }
    }
}