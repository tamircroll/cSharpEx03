using Ex03.GarageLogic.Logic.VhicleCreator;
using Ex03.GarageLogic.VhicleCreator;
using Ex03.GarageLogic.VhicleCreator.NotAbstract;

namespace Ex03.GarageManagementSystem.ConsolUI
{
    using System;
    using System.Collections.Generic;

    public class VehicleCreatorFactory
    {
        public static Dictionary<int, string> m_SupportedVehicles = new Dictionary<int, string>
        {
            { (int)eVehicleType.FuledCar, "Fuled Car" },
            { (int)eVehicleType.ElectricCar, "Electric Car" },
            { (int)eVehicleType.FueledMotorcycle, "Fuled Motorcycle" },
            { (int)eVehicleType.ElectricMotorcycle, "Electric Motorcycle" },
            { (int)eVehicleType.FueledTruck, "Track" }
        };

        public static Dictionary<int, string> SupportedVehicles
        {
            get { return m_SupportedVehicles; }
        }

        public static VehicleCreator Create(int i_VehicleIndex)
        {
            VehicleCreator vehicleCreator;
            switch ((eVehicleType)i_VehicleIndex)
            {
                case eVehicleType.FuledCar:
                    vehicleCreator = new FueledCarCreator();
                    break;
                case eVehicleType.ElectricCar:
                    vehicleCreator = new ElectricCarCreator();
                    break;
                case eVehicleType.FueledMotorcycle:
                    vehicleCreator = new FueledMotorcycleCreator();
                    break;
                case eVehicleType.ElectricMotorcycle:
                    vehicleCreator = new ElectricMotorcycleCreator();
                    break;
                case eVehicleType.FueledTruck:
                    vehicleCreator = new FueledTruckCreator();
                    break;
                default:
                    throw new FormatException("The vehicle choice is not a number in the given range");
            }

            return vehicleCreator;
        }

        public enum eVehicleType
        {
            FuledCar = 1,
            ElectricCar = 2, 
            FueledMotorcycle = 3, 
            ElectricMotorcycle = 4,
            FueledTruck = 5
        }
    }
}
