﻿namespace Ex03.GarageLogic.Vehicles
{
    public abstract class Motorcycle : Vehicle
    {
        private const int k_NumOfWheels = 2;
        protected eLicense m_License;
        protected int m_Engine;

        public Motorcycle(string i_Model, string i_PlateNumber, string i_WheelManufacturer, float i_AirPressure, float i_MaxWheelAirPresure, eLicense i_License, int i_Engine)
            : base(i_Model, i_PlateNumber, i_WheelManufacturer, i_AirPressure, i_MaxWheelAirPresure, k_NumOfWheels)
        {
            m_License = i_License;
            m_Engine = i_Engine;
        }

        public eLicense License
        {
            get { return m_License; }
            set { m_License = value; }
        }

        public int Engine
        {
            get { return m_Engine; }
            set { m_Engine = value; }
        }

        public enum eLicense
        {
            A = 1,
            A2 = 2,
            AB = 3,
            B1 = 4
        }

        public override string ToString()
        {
            return string.Format(
@"{0}
License: {1}
Engine Volume: {2}",
           base.ToString(),
           m_License,
           m_Engine);
        }
    }
}
