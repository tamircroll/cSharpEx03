using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic.Vehicles
{
    public abstract class Car : Vehicle
    {
        private const int k_NumOfWheels = 4;
        private const float k_MaxWheelAirPrusre = 31;
        protected eColor m_Color; 
        protected eNumOfDoors m_NumOfDoors;

        public Car(string i_Model, string i_PlateNumber, eColor i_Color, eNumOfDoors i_NumOfDoors, Wheel i_Wheel)
            : base(i_Model, i_PlateNumber, i_Wheel, k_NumOfWheels, k_MaxWheelAirPrusre)
        {
            m_Color = i_Color;
            m_NumOfDoors = i_NumOfDoors;
        }

        public eColor Color
        {
            get { return m_Color; }
            set { m_Color = value; }
        }

        public eNumOfDoors NumOfDoors
        {
            get { return m_NumOfDoors; }
            set { m_NumOfDoors = value; }
        }

        public enum eColor : byte
        {
            Green,
            Black,
            White,
            Red
        }

        public enum eNumOfDoors : byte
        {
            Two = 2,
            Three = 3,
            Four = 4,
            Five = 5
        }

        public override string ToString()
        {
            return string.Format(
@"{0}
Number of doors: {1}
Color: {2}", 
           base.ToString(),
           NumOfDoors,
           Color);
        }
    }
}