namespace Ex03.GarageLogic.Vehicles
{
    using System.Collections.Generic;

    public class Truck : Vehicle
    {
        private const int k_NumOfWheels = 16;
        private const float k_MaxWheelAirPrusre = 25;
        private const float k_FuelTankInLiters = 170;
        private readonly Fueled r_FuelEngine;
        protected bool m_DangerousMaterial;
        protected float m_CarryWeight;

        public Truck(string i_Model, string i_PlateNumber, float i_MountOfFuel, List<Wheel> i_Wheels, bool i_DangerousMaterial, float i_CarryWeight)
            : base(i_Model, i_PlateNumber, i_Wheels, k_NumOfWheels, k_MaxWheelAirPrusre)
        {
            m_DangerousMaterial = i_DangerousMaterial;
            m_CarryWeight = i_CarryWeight;
            r_FuelEngine = new Fueled(Fueled.eFuelType.Soler, i_MountOfFuel, k_FuelTankInLiters);
        }

        public bool DangerousMaterial
        {
            get { return m_DangerousMaterial; }
            set { m_DangerousMaterial = value; }
        }

        public float CarryWeight
        {
            get { return m_CarryWeight; }
            set { m_CarryWeight = value; }
        }

        public Fueled.eFuelType FuelType()
        {
            return r_FuelEngine.FuelType;
        }

        public int NumOfWheels
        {
            get { return k_NumOfWheels; }
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
Does carry dangerous material : {2}
Carrying weight: {3}",
                     base.ToString(),
                     r_FuelEngine,
                     DangerousMaterial, 
                     CarryWeight);
        }
    }
}
