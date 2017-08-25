using System;

namespace TellRachel.Shared
{
    public class UnitConverter : IUnitConverter
    {
        public double ToFahrenheit(double celsius)
        {
            return celsius * (9 / 5) + 32;
        }
    }
}
