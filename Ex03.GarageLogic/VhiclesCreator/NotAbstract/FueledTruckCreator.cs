using Ex03.GarageLogic.Logic.VhicleCreator;
using Ex03.GarageLogic.Vehicles;
using Ex03.GarageManagementSystem.ConsolUI;

namespace Ex03.GarageLogic.VhicleCreator
{
    public class FueledTruckCreator : FueledVehicleCreator
    {
        public const string k_CarryWeight = "how much weight the truck is carrying";
        public const string k_DangerousMatirials = @"Dangerous Matirial:
1. Carrying
2. Not Carrying";

        protected bool m_DangerousMaterials;
        protected float m_CarryWeight;

        protected override void AddSpecificVehicleParams()
        {
            ParamsDic.Add(k_CarryWeight, null);
            ParamsDic.Add(k_DangerousMatirials, null);
        }

        protected override void InitSpecificVehicleParams()
        {
            TruckCreatorHelper.SetCarryWeight(ParamsDic[k_CarryWeight], out m_CarryWeight);
            m_DangerousMaterials = TruckCreatorHelper.GetDangerousMaterials(ParamsDic[k_DangerousMatirials]);
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