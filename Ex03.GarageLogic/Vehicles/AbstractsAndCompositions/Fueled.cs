﻿namespace Ex03.GarageLogic.Vehicles
{
    using System;

    public class Fueled
    {
        private readonly float r_MaxFuel;
        private readonly eFuelType r_FuelType;
        private float m_LitersOfFuel;

        public Fueled(eFuelType i_FuelType, float i_LitersOfFuel, float i_MaxFuel)
        {
            if (i_LitersOfFuel > i_MaxFuel)
            {
                throw new ValueOutOfRangeException("liters of fuel", i_LitersOfFuel, i_MaxFuel, 0);
            }

            r_FuelType = i_FuelType;
            m_LitersOfFuel = i_LitersOfFuel;
            r_MaxFuel = i_MaxFuel;
        }

        public eFuelType FuelType
        {
            get { return r_FuelType; }
        }

        public float LitersOfFuel
        {
            get { return m_LitersOfFuel; }
        }

        public float PrecentOfEnergyLeft()
        {
            return LitersOfFuel / MaxFuel;
        }

        public void FuelUp(float i_ToFuel, eFuelType i_FuelType)
        {
            if (FuelType != i_FuelType)
            {
                throw new ArgumentException("Wrong fuel Type");
            }

            float fuelAfterFueling = m_LitersOfFuel + i_ToFuel;
            if (i_ToFuel <= 0)
            {
                throw new ArgumentException("The mount to fuel have to be possitive");
            }

            if (fuelAfterFueling > r_MaxFuel)
            {
                throw new ValueOutOfRangeException("Liters after fueling", fuelAfterFueling, r_MaxFuel, 0);
            }

            m_LitersOfFuel = fuelAfterFueling;
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
              LitersOfFuel,
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