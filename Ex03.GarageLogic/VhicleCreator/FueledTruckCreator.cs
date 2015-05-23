using System;
using Ex03.GarageLogic.Logic.VhicleCreator;
using Ex03.GarageLogic.Vehicles;
using Ex03.GarageManagementSystem.ConsolUI;

namespace Ex03.GarageLogic.VhicleCreator
{
    public class FueledTruckCreator : FueledVehicleCreator
    {
        protected const string k_CarryWeight = "how much weight the truck is carrying";
        protected const string k_DangerousMatirials = @"Dangerous Matirial:
1. Carrying
2. Not Carrying";
        protected bool m_DangerousMaterials;
        protected float m_CarryWeight;

        protected override void AddSpecificVehicleParams()
        {
            ParamsList.Add(k_CarryWeight);
            ParamsList.Add(k_DangerousMatirials);
        }

        protected override void InitSpecificVehicleParams()
        {
            bool isNumber = float.TryParse(ParamsDic[k_CarryWeight], out m_CarryWeight);
            if (!isNumber)
            {
                throw new FormatException("The engine input is not a number");
            }

            if (ParamsDic[k_DangerousMatirials] != "1" && ParamsDic[k_DangerousMatirials] != "2")
            {
                throw new FormatException("The input for Dangerous matirials is not valid");
            }

            m_DangerousMaterials = ParamsDic[k_DangerousMatirials] == "1";
        }

        public override CustomerCard InsertVehicle()
        {
            initBaseVehicleParams();
            InitEngineParams();
            InitSpecificVehicleParams();

            Vehicle vehicle = new FueledTruck(
                m_Model,
                m_PlateNumber,
                m_Manufacturer,
                m_AirPressure,
                m_MountOfFuel,
                m_DangerousMaterials,
                m_CarryWeight);

            return new CustomerCard(m_Owners, m_Phone, vehicle);
        }
    }
}