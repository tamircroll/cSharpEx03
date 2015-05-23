using Ex03.GarageLogic.Logic.VhicleCreator;
using Ex03.GarageLogic.VhicleCreator;

namespace Ex03.GarageManagementSystem.ConsolUI
{
    using System;
    using System.Collections.Generic;

    public class VehicleCreatorManager
    {
        public static Dictionary<string, string> m_SupportedVehicles = new Dictionary<string, string>
        {
            { "1", "Fuled Car" },
            { "2", "Electric Car" },
            { "3", "Track" },
            { "4", "Fuled Motorcycle" },
            { "5", "Electric Motorcycle" }
        };

        public static Dictionary<string, string> SupportedVehicles
        {
            get { return m_SupportedVehicles; }
        }

        public static VehicleCreator GetVehicleCreator(string i_VehicleIndex)
        {
            switch (i_VehicleIndex)
            {
                case "1":
                    return new FueledCarCreator();
                case "2":
                    return null;
                case "3":
                    return new FueledTruckCreator();
                case "4":
                    return new FueledMotorcycleCreator();
                case "5":
                    return null;
            }
            
            throw new FormatException("The vehicle choice is not a number in the given range");
        }
    }
}
