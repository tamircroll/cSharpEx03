using System;

namespace Ex03.GarageLogic.Vehicles
{
    public class Electric
    {
        private readonly float r_MaxBattery;
        private float m_RemainBatteryInHours;

        public Electric(float i_RemainBatteryInMinutes, float i_MaxBattery)
        {
            if (i_RemainBatteryInMinutes / 60 > i_MaxBattery)
            {
                throw new ValueOutOfRangeException("maximum battery", i_RemainBatteryInMinutes, i_MaxBattery, 0);
            }

            m_RemainBatteryInHours = i_RemainBatteryInMinutes / 60;
            r_MaxBattery = i_MaxBattery;
        }

        public float RemainBatteryInHours
        {
            get { return m_RemainBatteryInHours; }
        }

        public void ChargeBattery(float i_ToChargeInMinutes)
        {
            float batteryAfterCharge = m_RemainBatteryInHours + (i_ToChargeInMinutes / 60);

            if (i_ToChargeInMinutes <= 0)
            {
                throw new ArgumentException("The charging value has to be bigger then 0");
            }

            if (batteryAfterCharge <= r_MaxBattery && batteryAfterCharge >= 0 )
            {
                m_RemainBatteryInHours = batteryAfterCharge;
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
@"remain battery: {0:f} hours
Max Battery: {1:F} hours",
                 RemainBatteryInHours,
                 MaxBattery);
        }
    }
}
