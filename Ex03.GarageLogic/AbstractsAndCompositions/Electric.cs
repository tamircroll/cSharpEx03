using System;

namespace Ex03.GarageLogic.Vehicles
{
    public class Electric
    {
        private readonly float r_MaxBattery;
        private float m_RemainBatteryTime;

        public Electric(float i_RemainBatteryTime, float i_MaxBattery)
        {
            if (i_RemainBatteryTime > i_MaxBattery)
            {
                throw new ValueOutOfRangeException(i_RemainBatteryTime, i_MaxBattery, 0);
            }

            m_RemainBatteryTime = i_RemainBatteryTime;
            r_MaxBattery = i_MaxBattery;
        }

        public float RemainBatteryTime
        {
            get { return m_RemainBatteryTime; }
        }

        public void ChargeBattery(float i_ToCharge)
        {
            float batteryAfterCharge = m_RemainBatteryTime + (i_ToCharge / 60);

            if (i_ToCharge <= 0)
            {
                throw new ArgumentException("The charging value has to be bigger then 0");
            }

            if (batteryAfterCharge <= r_MaxBattery && batteryAfterCharge >= 0 )
            {
                m_RemainBatteryTime = batteryAfterCharge;
            }
            else
            {
                throw new ValueOutOfRangeException(batteryAfterCharge, r_MaxBattery, 0);
            }
        }

        public float MaxBattery
        {
            get { return r_MaxBattery; }
        }

        public override string ToString()
        {
            return string.Format(
@"remain battery: {0}
Max Battery: {1}",
                 RemainBatteryTime,
                 MaxBattery);
        }
    }
}
