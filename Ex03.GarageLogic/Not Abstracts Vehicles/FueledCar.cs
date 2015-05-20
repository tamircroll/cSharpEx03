using System.Collections.Generic;

namespace Ex03.GarageLogic.Vehicles
{
    public class FueledCar : Car
    {
        private const float k_MaxFuelTankInLiters = 35;
        private readonly Fueled r_FuelEngine;

        public FueledCar(string i_Model, string i_PlateNumber, eColor i_Color, eNumOfDoors i_NumOfDoors, float i_MountOfFuel, List<Wheel> i_Wheel)
            : base(i_Model, i_PlateNumber, i_Color, i_NumOfDoors, i_Wheel)
        {
            r_FuelEngine = new Fueled(Fueled.eFuelType.Octan96, i_MountOfFuel, k_MaxFuelTankInLiters);
        }

        public Fueled.eFuelType FuelType()
        {
            return r_FuelEngine.FuelType;
        }

        public float MountOfFuel()
        {
            return r_FuelEngine.MountOfFuel;
        }

        public void FuelUp(float i_ToFuel)
        {
            r_FuelEngine.FuelUp(i_ToFuel);
        }

        public float MaxFuel()
        {
            return r_FuelEngine.MaxFuel;
        }

        public override float PrecentOfEnergyLeft()
        {
            return r_FuelEngine.PrecentOfEnergyLeft();
        }

        protected override void SetIsElectric()
        {
            m_IsElectric = false;
        }

        public override string ToString()
        {
            return string.Format(
@"{0}
{1}
", 
 base.ToString(), 
 r_FuelEngine);
        }
    }
}
