using System;

namespace MyLittleCity.Scripts.MyLittleCity
{
    public enum BuildType
    {
        LowDensityResidential = 0,
        LowDensityComercial = 1,
        LowDensityIndustrial = 2,
        Road = 3,
        WindTurbineLow = 4,
        PowerLine = 5,
        RemoveTile = int.MaxValue,
        
        //acessories
        ResidentialUpgrade = 1000,
        WindTurbineHigh = 1001,
    }
}