using System;

namespace Ex03.GarageLogic.Logic.VhicleCreator
{
    public abstract class FueledVehicleCreator : VehicleCreator
    {
        public const string k_MountOfFuel = "Mount Of Fuel";
        protected float m_MountOfFuel;

        protected override void AddEngineParams()
        {
            ParamsDic.Add(k_MountOfFuel, null);
        }

        protected override void InitEngineParams()
        {
            bool isNumber = float.TryParse(ParamsDic[k_MountOfFuel], out m_MountOfFuel);
            if (!isNumber)
            {
                throw new FormatException("The mount of fuel given is not a number");
            }
        }
    }
}
