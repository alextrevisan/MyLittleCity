using System;

namespace MyLittleCity.Scripts.MyLittleCity
{
    public struct MonthToString
    {
        public string this[int month]
        {
            get
            {
                return month switch
                {
                    0 => "Jan",
                    1 => "Fev",
                    2 => "Mar",
                    3 => "Apr",
                    4 => "May",
                    5 => "Jun",
                    6 => "Jul",
                    7 => "Aug",
                    8 => "Sep",
                    9 => "Oct",
                    10 => "Nov",
                    11 => "Dec",
                    _ => "---"
                };
            }
        }
    }
}