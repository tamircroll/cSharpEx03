using Ex03.GarageLogic.Vehicles;
using Ex03.GarageLogic.VhicleCreator;
using Ex03.GarageManagementSystem.ConsolUI;

namespace Ex03.GarageLogic.Logic.VhicleCreator
{
    public class FueledCarCreator : FueledVehicleCreator
    {
        protected Car.eColor m_Color;
        protected Car.eNumOfDoors m_NumOfDoors;
        protected string m_Colors = CarCreatorHelper.SetColorsField();
        protected string m_NumOfDoorsStr = CarCreatorHelper.SetNumOfDoorsField();

        protected override void AddSpecificVehicleParams()
        {
            ParamsDic.Add(m_NumOfDoorsStr, null);
            ParamsDic.Add(m_Colors, null);
        }

        protected override void InitSpecificVehicleParams()
        {
            m_NumOfDoors = CarCreatorHelper.GetNumOfDoorsStr(ParamsDic[m_NumOfDoorsStr]);
            m_Color = CarCreatorHelper.GetColorStr(ParamsDic[m_Colors]);
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
