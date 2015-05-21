using System;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        protected readonly string r_Manufacturer;
        protected float m_AirPressure;
        protected float m_MaxAirPressure;

        public Wheel(string i_Manufacturer, float i_AirPressure, float i_MaxAirPressure)
        {
            r_Manufacturer = i_Manufacturer;
            m_AirPressure = i_AirPressure;
            m_MaxAirPressure = i_MaxAirPressure;
        }

        public void AddAir(float i_AirToAdd)
        {
            float airAfterAddition = i_AirToAdd + m_AirPressure;

            if (airAfterAddition > m_MaxAirPressure || airAfterAddition < 0)
            {
                throw new ValueOutOfRangeException(airAfterAddition, m_MaxAirPressure, 0);
            }

            m_AirPressure = airAfterAddition;
        }

        public string Manufacturer
        {
            get { return r_Manufacturer; }
        }

        public float AirPressure
        {
            get { return m_AirPressure; }
            set { m_AirPressure = value; }
        }

        public override string ToString()
        {
            return string.Format(
@"Air Pressure: {0}
Manufacturer: {1}",
                  AirPressure,
                  Manufacturer);
        }
    }
}