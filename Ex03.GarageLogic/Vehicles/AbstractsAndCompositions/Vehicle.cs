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

        public Vehicle(string i_Model, string i_PlateNumber, string i_WheelManufacturer, float i_AirPressure, float i_MaxWheelAirPresure, int i_NumOfWheels)
        {
            r_Model = i_Model;
            r_PlateNumber = i_PlateNumber;
            SetIsElectric();
            setWheels(i_WheelManufacturer, i_AirPressure, i_MaxWheelAirPresure, i_NumOfWheels);
        }

        private void setWheels(string i_WheelManufacturer, float i_AirPressure, float i_MaxWheelAirPresure, int i_NumOfWheels)
        {
            Wheels = new List<Wheel>();

            for (int i = 0; i < i_NumOfWheels; i++)
            {
                Wheel wheelToAdd = new Wheel(i_WheelManufacturer, i_AirPressure, i_MaxWheelAirPresure);
                m_Wheels.Add(wheelToAdd);
            }
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

        public override bool Equals(object i_Obj)
        {
            bool isEqual = false;
            Vehicle vehicle = i_Obj as Vehicle;

            if (vehicle != null)
            {
                if (vehicle.PlateNumber == PlateNumber)
                {
                    isEqual = true;
                }
            }
            else
            {
                throw new ArgumentException("The compared Object is not of type Vehicle");
            }

            return isEqual;
        }

        public override int GetHashCode()
        {
            return PlateNumber.GetHashCode();
        }

        public abstract float PercentOfEnergyLeft();

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
Model: {1}
{2}

Percent of energy left: {3:p}",
                            r_PlateNumber,
                            Model,
                            wheelsInfo,
                            PercentOfEnergyLeft());
        }
    }
}