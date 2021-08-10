namespace MyLittleCity.Scripts.MyLittleCity
{
    public struct ResidentialTaxGenerated
    {
        public int this[int populationDensity]
        {
            get
            {
                return populationDensity switch
                {
                    0 => 0,
                    1 => 1,
                    2 => 3,
                    3 => 3,
                    4 => 4,
                    _ => 0
                };
            }
        }
    }
}