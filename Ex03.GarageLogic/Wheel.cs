using System;

namespace Ex03.GarageLogic
{
    public abstract class Wheel
    {
        protected string m_Producer;
        protected float m_AirPressure;
        protected float m_MaxAirPressure;

        public Wheel(string i_Producer, float i_AirPressure, float i_MaxAirPressure)
        {
            m_Producer = i_Producer;
            m_AirPressure = i_AirPressure;
            m_MaxAirPressure = i_AirPressure;
        }

        public void AddAir(float i_AirToAdd)
        {
            float airAfterAddition = i_AirToAdd + m_AirPressure;

            if (airAfterAddition > m_MaxAirPressure)
            {
                throw new Exception(); //TODO!!!!!!!!!!!!!!!!
            }

            m_AirPressure = airAfterAddition;
        }
    }
}