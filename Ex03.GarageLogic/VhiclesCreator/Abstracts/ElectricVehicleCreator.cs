using System;
using Ex03.GarageLogic.Logic.VhicleCreator;

namespace Ex03.GarageLogic.VhicleCreator
{
    public abstract class ElectricVehicleCreator : VehicleCreator
    {
        private const string k_BatteryMinutesRemain = "battery minutes remains";
        protected float m_BatteryMinutesRemain;

        protected override void AddEngineParams()
        {
            ParamsList.Add(k_BatteryMinutesRemain);
        }

        protected override void InitEngineParams()
        {
            bool isNumber = float.TryParse(ParamsDic[k_BatteryMinutesRemain], out m_BatteryMinutesRemain);
            if (!isNumber)
            {
                throw new FormatException("The battery minutes given is not a number");
            }
        }
    }
}
