using Ex03.GarageLogic.Vehicles;

namespace Ex03.GarageLogic
{
    public class ElectricMotorcycle : Motorcycle
    {
        private const float k_MaxBattery = 2.2f;
        private const float k_MaxWheelAirPrusre = 31;
        private readonly Electric r_ElectricEngine;

        public ElectricMotorcycle(string i_Model, string i_PlateNumber, string i_WheelManufacturer, float i_AirPressure, float i_RemainBatteryTime, eLicense i_License, int i_Engine) :
                base(i_Model, i_PlateNumber, i_WheelManufacturer, i_AirPressure, k_MaxWheelAirPrusre, i_License, i_Engine)
        {
            r_ElectricEngine = new Electric(i_RemainBatteryTime, k_MaxBattery);
        }

        public float RemainBatteryTime()
        {
            return r_ElectricEngine.RemainBatteryInHours;
        }

        public float MaxBattery()
        {
            return r_ElectricEngine.MaxBattery;
        }

        public void ChargeBattery(float i_ToCharge)
        {
            r_ElectricEngine.ChargeBattery(i_ToCharge);
        }

        public override float PercentOfEnergyLeft()
        {
            return RemainBatteryTime() / MaxBattery();
        }

        protected override void SetIsElectric()
        {
            m_IsElectric = true;
        }

        public override string ToString()
        {
            return string.Format(
@"Electric Motorcycle:

{0}
{1}
",
                base.ToString(),
                r_ElectricEngine);
        }
    }
}
