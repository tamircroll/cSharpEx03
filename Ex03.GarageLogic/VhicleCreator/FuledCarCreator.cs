using System;
using Ex03.GarageLogic.Vehicles;
using Ex03.GarageManagementSystem.ConsolUI;

namespace Ex03.GarageLogic.Logic.VhicleCreator
{
    public class FuledCarCreator : CarCreator
    {
        private const string k_MountOfFuel = "Mount Of Fuel";
        private float m_MountOfFuel;

        protected override void AddEngineParams()
        {
            ParamsList.Add(k_MountOfFuel);
        }

        protected override void InitEngineParams()
        {
            bool isNumber = float.TryParse(ParamsDic[k_MountOfFuel], out m_MountOfFuel);
            if (!isNumber)
            {
                throw new FormatException("The mount of fuel given is not a number");
            }
        }

        public override CustomerCard InsertVehicle()
        {
            initBaseVehicleParams();
            InitEngineParams();
            InitSpecificVehicleParams();

            Vehicle vehicle = new FueledCar(
                m_Model,
                m_PlateNumber, 
                m_Manufacturer,
                m_AirPressure, 
                m_Color, 
                m_NumOfDoors,
                m_MountOfFuel);

            return new CustomerCard(m_Owners, m_Phone, vehicle);
        }
    }
}
