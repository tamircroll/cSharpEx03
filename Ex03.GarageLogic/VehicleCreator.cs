using System.Runtime.CompilerServices;
using Ex03.GarageLogic;

namespace Ex03.GarageManagementSystem.ConsolUI
{
    using System;
    using System.Collections.Generic;
    using System.Text;


    // לנסות להחזיק רשימה של מחלקות

    public class VehicleCreator
    {
        private List<eSupportedVehicles> m_SupportedVehicles = new List<eSupportedVehicles>
        {
            eSupportedVehicles.ElectricCar,
            eSupportedVehicles.FuledCar,
            eSupportedVehicles.ElectricTrack,
            eSupportedVehicles.FuledTrack,
            eSupportedVehicles.ElectricMotorcycle,
            eSupportedVehicles.FuledMotorcycle
        };

        public List<eSupportedVehicles> SupportedVehicles
        {
            get { return m_SupportedVehicles; }
        }   
    }

    public enum eSupportedVehicles
    {
        ElectricCar,
        FuledCar,
        ElectricTrack,
        FuledTrack,
        ElectricMotorcycle,
        FuledMotorcycle
    }
}
