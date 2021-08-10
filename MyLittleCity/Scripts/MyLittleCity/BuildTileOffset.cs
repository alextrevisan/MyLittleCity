using Godot;

namespace MyLittleCity.Scripts.MyLittleCity
{
    public struct BuildTileOffset
    {
        public Vector2 this[BuildType buildType]
        {
            get
            {
                switch (buildType)
                {
                    case BuildType.Road:
                        return new Vector2(3, 0);
                    case BuildType.LowDensityResidential:
                    case BuildType.LowDensityComercial:
                    case BuildType.LowDensityIndustrial:
                    default:
                        return new Vector2(0,0);
                }
            }
        }
    }
}