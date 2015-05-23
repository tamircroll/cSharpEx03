using System;
using Ex03.GarageLogic.Logic.VhicleCreator;

namespace Ex03.GarageLogic.VhicleCreator
{
    public abstract class ElectricVehicleCreator : VehicleCreator
    {
        private const string k_BatteryHoursRemains = "battery minutes remains";
        protected float m_BatteryHoursRemains;

        protected override void AddEngineParams()
        {
            ParamsList.Add(k_BatteryHoursRemains);
        }

        protected override void InitEngineParams()
        {
            bool isNumber = float.TryParse(ParamsDic[k_BatteryHoursRemains], out m_BatteryHoursRemains);
            if (!isNumber)
            {
                throw new FormatException("The battery hours given is not a number");
            }
        }
    }
}
