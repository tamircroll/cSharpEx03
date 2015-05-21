namespace Ex03.GarageLogic.Vehicles
{
    using System;

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

        public void FuelUp(float i_ToFuel, eFuelType i_FuelType)
        {
            if (FuelType != i_FuelType)
            {
                throw new ArgumentNullException("Wrong fuel Type!");
            }

            float fuelAfterFueling = m_MountOfFuel + i_ToFuel;
            if (fuelAfterFueling <= r_MaxFuel && fuelAfterFueling >= 0)
            {
                m_MountOfFuel = fuelAfterFueling;
            }
            else
            {
                throw new ValueOutOfRangeException(fuelAfterFueling, r_MaxFuel, 0);
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

        public enum eFuelType : byte
        {
            Soler = 0,
            Octan95 = 1,
            Octan96 = 2,
            Octan98 = 3
        }
    }
}
