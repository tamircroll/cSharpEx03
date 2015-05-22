﻿using Ex03.GarageLogic.Vehicles;

namespace Ex03.GarageLogic
{
    public class ElectricMotorcycle : Motorcycle
    {
        private const float k_MaxBattery = 2.2f;
        private readonly Electric r_ElectricEngine;

        public ElectricMotorcycle(string i_Model, string i_PlateNumber, Wheel i_Wheel, eLicense i_License, int i_Engine,
            float i_MaxWheelAirPresure, float i_RemainBatteryTime)
            : base(i_Model, i_PlateNumber, i_Wheel, i_License, i_Engine, i_MaxWheelAirPresure)
        {
            r_ElectricEngine = new Electric(i_RemainBatteryTime, k_MaxBattery);
        }

        public float RemainBatteryTime()
        {
            return r_ElectricEngine.RemainBatteryTime;
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
@"{0}
{1}
",
base.ToString(),
r_ElectricEngine);
        }
    }
}
