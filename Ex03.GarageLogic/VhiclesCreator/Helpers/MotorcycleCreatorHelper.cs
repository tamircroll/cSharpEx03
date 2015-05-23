using System;
using Ex03.GarageLogic.Vehicles;

namespace Ex03.GarageLogic.VhicleCreator
{
    public class MotorcycleCreatorHelper
    {
        public static void SetEngineFeild(string i_EngineStr, out int o_Engine)
        {
            bool isNumber = int.TryParse(i_EngineStr, out o_Engine);
            if (!isNumber)
            {
                throw new FormatException("The engine input is not a number");
            }
        }

        public static Motorcycle.eLicense GetLicense(string i_LicenseStr)
        {
            int licenseInt;
            bool isNumber = int.TryParse(i_LicenseStr, out licenseInt);
            if (!isNumber)
            {
                throw new FormatException("The numbers of doors input is not a number");
            }

            if (licenseInt < 0 || licenseInt >= Enum.GetValues(typeof(Motorcycle.eLicense)).Length)
            {
                throw new ValueOutOfRangeException("number of doors", licenseInt,
                    Enum.GetValues(typeof(Motorcycle.eLicense)).Length - 1, 0);
            }

            return (Motorcycle.eLicense)licenseInt;
        }
    }
}