using System;

namespace MyLittleCity.Scripts.MyLittleCity
{
    public enum BuildType
    {
        LowDensityResidential = 0,
        LowDensityComercial = 1,
        LowDensityIndustrial = 2,
        Road = 3,
        WindTurbine = 4,
        
        ResidentialUpgrade = 1000,
        
        RemoveTile = int.MaxValue,
        
    }
}