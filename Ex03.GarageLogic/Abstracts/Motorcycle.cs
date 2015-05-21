namespace Ex03.GarageLogic.Vehicles
{
    using System.Collections.Generic;

    public abstract class Motorcycle : Vehicle
    {
        protected eLicense m_License;
        protected int m_Engine;

        public Motorcycle(string i_Model, string i_PlateNumber, Wheel i_Wheel, eLicense i_License, int i_Engine,
            int i_NumOfWheels, float i_MaxWheelAirPresure) 
            : base(i_Model, i_PlateNumber, i_Wheel, i_NumOfWheels, i_MaxWheelAirPresure)
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
            A,
            A2,
            AB,
            B1
        }
    }
}
