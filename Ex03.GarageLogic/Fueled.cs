using System.Runtime.InteropServices.ComTypes;

namespace Ex03.GarageLogic.Vehicles
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Fueled
    {
        private readonly float r_MaxFuel;
        private readonly eFuelType r_FuelType;
        private float m_MountOfFuel;

        public Fueled(eFuelType i_FuelType, float i_MountOfFuel, float i_MaxFuel)
        {
            r_FuelType = i_FuelType;
            m_MountOfFuel = i_MountOfFuel;
            r_MaxFuel = i_MaxFuel;
        }

        public eFuelType FuelType
        {
            get { return r_FuelType; }
        }

        public float MountOfFuel
        {
            get { return m_MountOfFuel; }
        }

        public float PrecentOfEnergyLeft()
        {
            return MountOfFuel / MaxFuel;
        }

        public void FuelUp(float i_ToFuel)
        {
            float FuelAfterFueling = m_MountOfFuel + i_ToFuel;
            if (FuelAfterFueling <= r_MaxFuel)
            {
                m_MountOfFuel = FuelAfterFueling;
            }
            else
            {
                throw new ValueOutOfRangeException(FuelAfterFueling, r_MaxFuel);
            }
        }

        public float MaxFuel
        {
            get { return r_MaxFuel; }
        }

        public override string ToString()
        {
            return string.Format(
@"Mount of fuel: {0}
Fuel type: {1}
Max fuel: {2}",
              MountOfFuel,
              FuelType.ToString(),
              MaxFuel);
        }

        public enum eFuelType
        {
            Soler,
            Octan95,
            Octan96,
            Octan98
        }
    }
}
