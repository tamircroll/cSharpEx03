namespace Ex03.GarageLogic.Vehicles
{
    public class Electric
    {
        private readonly float r_MaxBattery;
        private float m_RemainBattery;

        public Electric(float i_RemainBattery, float i_MaxBattery)
        {
            m_RemainBattery = i_RemainBattery;
            r_MaxBattery = i_MaxBattery;
        }

        public float RemainBattery
        {
            get { return m_RemainBattery; }
        }

        public void ChargeBattery(float i_ToCharge)
        {
            float batteryAfterCharge = m_RemainBattery + i_ToCharge;
            if (m_RemainBattery + i_ToCharge <= r_MaxBattery)
            {
                m_RemainBattery = batteryAfterCharge;
            }
            else
            {
                throw new ValueOutOfRangeException(batteryAfterCharge, r_MaxBattery);
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
                 RemainBattery,
                 MaxBattery);
        }
    }
}
