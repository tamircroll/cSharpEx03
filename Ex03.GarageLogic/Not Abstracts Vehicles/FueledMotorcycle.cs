using Ex03.GarageLogic.Vehicles;

namespace Ex03.GarageLogic.Not_Abstracts_Vehicles
{
    public class FueledMotorcycle : Motorcycle
    {
        private const float k_MaxFuelTankInLiters = 35;
        private readonly Fueled r_FuelEngine;

        public FueledMotorcycle(string i_Model, string i_PlateNumber, Wheel i_Wheel, eLicense i_License, int i_Engine,
            float i_MountOfFuel, float i_MaxWheelAirPresure)
            : base(i_Model, i_PlateNumber, i_Wheel, i_License, i_Engine, i_MaxWheelAirPresure)
        {
            r_FuelEngine = new Fueled(Fueled.eFuelType.Octan96, i_MountOfFuel, k_MaxFuelTankInLiters);
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
