using Ex03.GarageLogic.Logic.VhicleCreator;
using Ex03.GarageLogic.Vehicles;

namespace Ex03.GarageManagementSystem.ConsolUI
{
    using System;
    using System.Collections.Generic;

    // לנסות להחזיק רשימה של מחלקות

    public class VehicleCreatorManager
    {
        // private Type v = (new Vehicle()).GetType();

        public static Dictionary<string, string> m_SupportedVehicles = new Dictionary<string, string>
        {
            {"1", "Fuled Car"},
            {"2", "Electric Car"},
            {"3", "Track"},
            {"4", "Fuled Motorcycle"},
            {"5", "Electric Motorcycle"}
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
            }
            
            throw new FormatException("The vehicle choice is not a number in the given range");
        }
//
//        public enum eSupportedVehicles
//        {
//            ElectricCar,
//            FuledCar,
//            Track,
//            ElectricMotorcycle,
//            FuledMotorcycle
//        }
    }
}
