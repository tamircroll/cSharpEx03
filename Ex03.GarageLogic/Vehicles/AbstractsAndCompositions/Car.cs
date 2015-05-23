namespace Ex03.GarageLogic.Vehicles
{
    public abstract class Car : Vehicle
    {
        private const int k_NumOfWheels = 4;
        protected eColor m_Color; 
        protected eNumOfDoors m_NumOfDoors;

        public Car(string i_Model, string i_PlateNumber, string i_WheelManufacturer, float i_AirPressure, float i_MaxWheelAirPrusre, eColor i_Color, eNumOfDoors i_NumOfDoors)
            : base(i_Model, i_PlateNumber, i_WheelManufacturer, i_AirPressure, i_MaxWheelAirPrusre, k_NumOfWheels)
        {
            m_Color = i_Color;
            m_NumOfDoors = i_NumOfDoors;
        }

        public eColor Color
        {
            get { return m_Color; }
            set { m_Color = value; }
        }

        public eNumOfDoors NumOfDoors
        {
            get { return m_NumOfDoors; }
            set { m_NumOfDoors = value; }
        }

        public enum eColor : byte
        {
            Green,
            Black,
            White,
            Red
        }

        public enum eNumOfDoors : byte
        {
            Two = 0,
            Three = 1,
            Four = 2,
            Five = 3
        }

        public override string ToString()
        {
            return string.Format(
@"{0}
Number of doors: {1}
Color: {2}", 
           base.ToString(),
           NumOfDoors,
           Color);
        }
    }
}