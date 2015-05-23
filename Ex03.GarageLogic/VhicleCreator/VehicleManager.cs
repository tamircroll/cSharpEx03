using Ex03.GarageLogic.Vehicles;

namespace Ex03.GarageManagementSystem.ConsolUI
{
    using System;
    using System.Collections.Generic;

    // לנסות להחזיק רשימה של מחלקות

    public class VehicleManager<T>
    {
       // private Type v = (new Vehicle()).GetType();

        public static List<Type> m_SupportedVehicles = new List<Type>
        {
            typeof(ElectricCar),
            typeof(FueledCar),
            typeof(Truck),
//            typeof(ElectricMotorcycle),
//            typeof(FuledMotorcycle)

            //eSupportedVehicles.ElectricCar,
            //eSupportedVehicles.FuledCar,
            //eSupportedVehicles.Track,
            //eSupportedVehicles.ElectricMotorcycle,
            //eSupportedVehicles.FuledMotorcycle
        };

        public static List<Type> SupportedVehicles
        {
            get { return m_SupportedVehicles; }
        }   
    }

    public enum eSupportedVehicles
    {
        ElectricCar,
        FuledCar,
        Track,
        ElectricMotorcycle,
        FuledMotorcycle
    }
}
