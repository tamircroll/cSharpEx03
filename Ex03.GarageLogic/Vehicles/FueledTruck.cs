namespace Ex03.GarageLogic.Vehicles
{
    public class FueledTruck : Truck
    {
        private const float k_MaxFuelTankInLiters = 170;
        private const Fueled.eFuelType k_FuelType = Fueled.eFuelType.Soler;
        private readonly Fueled r_FuelEngine;

        public FueledTruck(string i_Model, string i_PlateNumber, string i_WheelManufacturer, float i_AirPressure, float i_MountOfFuel, bool i_DangerousMaterial, float i_CarryWeight) : 
            base(i_Model, i_PlateNumber, i_WheelManufacturer, i_AirPressure, i_DangerousMaterial, i_CarryWeight)
        {
            r_FuelEngine = new Fueled(k_FuelType, i_MountOfFuel, k_MaxFuelTankInLiters);
        }

        public Fueled.eFuelType FuelType()
        {
            return r_FuelEngine.FuelType;
        }

        public float MountOfFuel()
        {
            return r_FuelEngine.MountOfFuel;
        }

        public void FuelUp(float i_ToFuel, Fueled.eFuelType i_FuelType)
        {
            r_FuelEngine.FuelUp(i_ToFuel, i_FuelType);
        }

        public float MaxFuel()
        {
            return r_FuelEngine.MaxFuel;
        }

        public override float PercentOfEnergyLeft()
        {
            return r_FuelEngine.PrecentOfEnergyLeft();
        }

        protected override void SetIsElectric()
        {
            m_IsElectric = false;
        }

        public override string ToString()
        {
            return string.Format(
@"{0}
{1}
",
 base.ToString(),
 r_FuelEngine);
        }
    }
}