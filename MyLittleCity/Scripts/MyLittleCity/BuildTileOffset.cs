using Godot;

namespace MyLittleCity.Scripts.MyLittleCity
{
    public struct BuildTileOffset
    {
        public Vector2 this[MenuItems menuItem]
        {
            get
            {
                switch (menuItem)
                {
                    case MenuItems.Road:
                        return new Vector2(3, 0);
                    case MenuItems.LowDensityResidential:
                    case MenuItems.LowDensityComercial:
                    case MenuItems.LowDensityIndustrial:
                    default:
                        return new Vector2(0,0);
                }
            }
        }
    }
}