using Ex03.GarageLogic.Logic.VhicleCreator;
using Ex03.GarageLogic.VhicleCreator;
using Ex03.GarageLogic.VhicleCreator.NotAbstract;

namespace Ex03.GarageManagementSystem.ConsolUI
{
    using System;
    using System.Collections.Generic;

    public class VehicleCreatorManager
    {
        private const string k_FuledCarIndex = "1";
        private const string k_ElectricCarIndex = "2";
        private const string k_FueledMotorcycleIndex = "3";
        private const string k_ElectricMotorcycleIndex = "4";
        private const string k_FueledTruckIndex = "5";

        public static Dictionary<string, string> m_SupportedVehicles = new Dictionary<string, string>
        {
            { k_FuledCarIndex, "Fuled Car" },
            { k_ElectricCarIndex, "Electric Car" },
            { k_FueledMotorcycleIndex, "Fuled Motorcycle" },
            { k_ElectricMotorcycleIndex, "Electric Motorcycle" },
            { k_FueledTruckIndex, "Track" }
        };

        public static Dictionary<string, string> SupportedVehicles
        {
            get { return m_SupportedVehicles; }
        }

        public static VehicleCreator GetVehicleCreator(string i_VehicleIndex)
        {
            switch (i_VehicleIndex)
            {
                case k_FuledCarIndex:
                    return new FueledCarCreator();
                case k_ElectricCarIndex:
                    return new ElectricCarCreator();
                case k_FueledMotorcycleIndex:
                    return new FueledMotorcycleCreator();
                case k_ElectricMotorcycleIndex:
                    return new ElectricMotorcycleCreator();
                case k_FueledTruckIndex:
                    return new FueledTruckCreator();
            }
            
            throw new FormatException("The vehicle choice is not a number in the given range");
        }
    }
}
