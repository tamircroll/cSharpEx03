namespace Ex03.GarageLogic
{
    public class Wheel
    {
        protected readonly string r_Manufacturer;
        protected float m_AirPressure;
        protected float m_MaxAirPressure;

        public Wheel(string i_Manufacturer, float i_AirPressure, float i_MaxAirPressure)
        {
            if (i_AirPressure > i_MaxAirPressure)
            {
                throw new ValueOutOfRangeException("air pressure", i_AirPressure, i_MaxAirPressure, 0);
            }

            r_Manufacturer = i_Manufacturer;
            m_AirPressure = i_AirPressure;
            m_MaxAirPressure = i_MaxAirPressure;
        }

        public void InflatWheel(float i_ToInflate)
        {
            if (i_ToInflate + AirPressure > MaxAirPressure)
            {
                throw new ValueOutOfRangeException("air pressure", i_ToInflate + AirPressure, MaxAirPressure, 0);
            }

            m_AirPressure += i_ToInflate;
        }

        public string Manufacturer
        {
            get { return r_Manufacturer; }
        }

        public float AirPressure
        {
            get { return m_AirPressure; }
            set { }
        }

        public float MaxAirPressure
        {
            get { return m_MaxAirPressure; }
        }

        public override string ToString()
        {
            return string.Format(
@"Air Pressure: {0}
Max air presure: {1}
Manufacturer: {2}",
                  AirPressure,
                  MaxAirPressure,
                  Manufacturer);
        }
    }
}