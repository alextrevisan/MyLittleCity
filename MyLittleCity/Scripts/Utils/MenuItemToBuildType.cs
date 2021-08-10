using System;
using MyLittleCity.Scripts.MyLittleCity;

namespace MyLittleCity.Scripts.Utils
{
    public struct MenuItemToBuildType
    {
        public BuildType this[MenuItems menuItem]
        {
            get
            {
                switch (menuItem)
                {
                    case MenuItems.LowDensityResidential:
                        return BuildType.LowDensityResidential;
                    case MenuItems.LowDensityComercial:
                        return BuildType.LowDensityComercial;
                    case MenuItems.LowDensityIndustrial:
                        return BuildType.LowDensityIndustrial;
                    case MenuItems.Road:
                        return BuildType.Road;
                    case MenuItems.RemoveTile:
                        return BuildType.RemoveTile;
                    case MenuItems.ResidentialUpgrade:
                        return BuildType.ResidentialUpgrade;
                    case MenuItems.WindTurbineLow:
                        return BuildType.WindTurbineLow;
                    case MenuItems.WindTurbineHigh:
                        return BuildType.WindTurbineHigh;
                    default:
                        Console.WriteLine($"Can't convert {menuItem.ToString()} to BuildType");
                        throw new Exception($"Can't convert {menuItem.ToString()} to BuildType");
                }
            }
        }
    }
}