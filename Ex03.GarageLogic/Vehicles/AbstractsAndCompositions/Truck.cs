namespace Ex03.GarageLogic.Vehicles
{
    public abstract class Truck : Vehicle
    {
        private const int k_NumOfWheels = 16;
        protected bool m_DangerousMaterial;
        protected float m_CarryWeight;

        public Truck(string i_Model, string i_PlateNumber, string i_WheelManufacturer, float i_AirPressure, float i_MaxPressure, bool i_DangerousMaterial, float i_CarryWeight)
            : base(i_Model, i_PlateNumber, i_WheelManufacturer, i_AirPressure, i_MaxPressure, k_NumOfWheels)
        {
            m_DangerousMaterial = i_DangerousMaterial;
            m_CarryWeight = i_CarryWeight;
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

        public override string ToString()
        {
            return string.Format(
@"{0}
Does carry dangerous material : {1}
Carrying weight: {2:F}",
                     base.ToString(),
                     DangerousMaterial, 
                     CarryWeight);
        }
    }
}
