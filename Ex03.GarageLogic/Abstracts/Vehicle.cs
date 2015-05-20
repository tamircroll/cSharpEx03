using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        protected readonly string r_PlateNumber;
        protected readonly string r_Model;
        protected List<Wheel> m_Wheels;
        protected bool? m_IsElectric;
        private int m_NumOfWheels;
        private float m_MaxWheelAirPrusre;

        public Vehicle(string i_Model, string i_PlateNumber, List<Wheel> i_wheels, int i_NumOfWheels, float i_MaxWheelAirPresure)
        {
            r_Model = i_Model;
            r_PlateNumber = i_PlateNumber;
            SetIsElectric();
            m_Wheels = i_wheels;
            m_NumOfWheels = i_NumOfWheels;
            m_MaxWheelAirPrusre = i_MaxWheelAirPresure;
        }

        public string Model
        {
            get { return r_Model; }
        }

        public string PlateNumber
        {
            get { return r_PlateNumber; }
        }

        public List<Wheel> Wheels
        {
            get { return m_Wheels; }
            set { m_Wheels = value; }
        }

        public bool? IsElectric
        {
            get { return m_IsElectric; }
        }

        public int NumOfWheels
        {
            get { return m_NumOfWheels; }
        }

        public float MaxWheelAirPrusre
        {
            get { return m_MaxWheelAirPrusre; }
        }

        public override bool Equals(object obj)
        {
            bool isEqual = false;

            Vehicle vehicle = obj as Vehicle;
            if (vehicle != null)
            {
                if (vehicle.PlateNumber == PlateNumber)
                {
                    isEqual = true;
                }
            }

            return isEqual;
        }

        public override int GetHashCode()
        {
            return PlateNumber.GetHashCode();
        }

        public abstract float PrecentOfEnergyLeft();

        protected abstract void SetIsElectric();

        public override string ToString()
        {
            string wheelsInfo = string.Empty;
            int i = 1;

            foreach (Wheel wheel in Wheels)
            {
                wheelsInfo = string.Format(
@"{0}
Wheel {1}:
{2}",
    wheelsInfo,
    i,
    wheel);
                i++;
            }

            return string.Format(
@"Plate: {0}
Model: {1}{2}
Precent of energy left: {3}",
                            r_PlateNumber,
                            Model, wheelsInfo,
                            PrecentOfEnergyLeft());
        }
    }
}