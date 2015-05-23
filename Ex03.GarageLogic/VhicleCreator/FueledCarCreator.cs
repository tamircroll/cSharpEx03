using System;
using System.Text;
using Ex03.GarageLogic.Vehicles;
using Ex03.GarageManagementSystem.ConsolUI;

namespace Ex03.GarageLogic.Logic.VhicleCreator
{
    public class FueledCarCreator : FueledVehicleCreator
    {
        protected int m_NumOfDoorsInt;
        protected int m_ColorInt;
        protected string m_ColorString;
        protected Car.eColor m_Color;
        protected Car.eNumOfDoors m_NumOfDoors;
        protected string m_Colors = setColorsField();
        protected string m_NumOfDoorsStr = setNumOfDoorsField();


        protected override void AddSpecificVehicleParams()
        {
            ParamsList.Add(m_NumOfDoorsStr);
            ParamsList.Add(m_Colors);
        }

        private static string setColorsField()
        {
            StringBuilder str = new StringBuilder();

            str.Append(string.Format("Color:{0}", System.Environment.NewLine));
            foreach (Car.eColor color in Enum.GetValues(typeof(Car.eColor)))
            {
                str.Append(String.Format("{0}. {1}{2}", (int)color, color, System.Environment.NewLine));
            }

            return str.ToString();
        }

        private static string setNumOfDoorsField()
        {
            StringBuilder str = new StringBuilder();

            str.Append(string.Format("Number of doors:{0}", System.Environment.NewLine));
            foreach (Car.eNumOfDoors numOfDoors in Enum.GetValues(typeof(Car.eNumOfDoors)))
            {
                str.Append(String.Format("{0}. {1}{2}", (int)numOfDoors, numOfDoors, System.Environment.NewLine));
            }

            return str.ToString();
        }

        protected override void InitSpecificVehicleParams()
        {
            bool isNumber = Int32.TryParse(ParamsDic[m_NumOfDoorsStr], out m_NumOfDoorsInt);
            if (!isNumber)
            {
                throw new FormatException("The numbers of doors input was not a number");
            }

            if (m_NumOfDoorsInt < 0 || m_NumOfDoorsInt >= Enum.GetValues(typeof(Car.eNumOfDoors)).Length)
            {
                throw new ValueOutOfRangeException(m_NumOfDoorsInt, Enum.GetValues(typeof (Car.eNumOfDoors)).Length, 0);
            }

            m_NumOfDoors = (Car.eNumOfDoors)m_NumOfDoorsInt;

            isNumber = Int32.TryParse(ParamsDic[m_Colors], out m_ColorInt);
            if (!isNumber)
            {
                throw new FormatException("The numbers of doors input was not a number");
            }

            if (m_ColorInt < 0 || m_ColorInt >= Enum.GetValues(typeof(Car.eColor)).Length)
            {
                throw new ValueOutOfRangeException(m_NumOfDoorsInt, Enum.GetValues(typeof(Car.eColor)).Length, 0);
            }

            m_Color = (Car.eColor)m_ColorInt;
        }

        public override CustomerCard InsertVehicle()
        {
            initBaseVehicleParams();
            InitEngineParams();
            InitSpecificVehicleParams();

            Vehicle vehicle = new FueledCar(
                m_Model,
                m_PlateNumber,
                m_Manufacturer,
                m_AirPressure,
                m_Color,
                m_NumOfDoors,
                m_MountOfFuel);

            return new CustomerCard(m_Owners, m_Phone, vehicle);
        }
    }
}
