using Ex03.GarageLogic.Logic.VhicleCreator;
using Ex03.GarageLogic.Not_Abstracts_Vehicles;
using Ex03.GarageLogic.Vehicles;
using Ex03.GarageManagementSystem.ConsolUI;

namespace Ex03.GarageLogic.VhicleCreator
{
    using System;
    using System.Text;

    public class FueledMotorcycleCreator : FueledVehicleCreator
    {
        protected const string k_Engine = "Engine";
        protected Motorcycle.eLicense m_License;
        protected int m_LicenseInt;
        protected string m_EngineStr;
        protected int m_Engine;
        protected string m_LicenseStr = setLicenseField();
        protected Car.eNumOfDoors m_NumOfDoors;

        protected override void AddSpecificVehicleParams()
        {
            ParamsList.Add(m_LicenseStr);
            ParamsList.Add(k_Engine);
        }
        
        private static string setLicenseField()
        {
            StringBuilder str = new StringBuilder();

            str.Append(string.Format("License:{0}", Environment.NewLine));
            foreach (Motorcycle.eLicense color in Enum.GetValues(typeof(Motorcycle.eLicense)))
            {
                str.Append(string.Format("{0}. {1}{2}", (int) color, color, Environment.NewLine));
            }

            return str.ToString();
        }

        protected override void InitSpecificVehicleParams()
        {
            bool isNumber = int.TryParse(ParamsDic[k_Engine], out m_Engine);
            if (!isNumber)
            {
                throw new FormatException("The engine input is not a number");
            }

            isNumber = int.TryParse(ParamsDic[m_LicenseStr], out m_LicenseInt);
            if (!isNumber)
            {
                throw new FormatException("The numbers of doors input is not a number");
            }

            if (m_LicenseInt < 0 || m_LicenseInt >= Enum.GetValues(typeof(Motorcycle.eLicense)).Length)
            {
                throw new ValueOutOfRangeException("number of doors", m_LicenseInt, Enum.GetValues(typeof(Motorcycle.eLicense)).Length - 1, 0);
            }

            m_License = (Motorcycle.eLicense)m_LicenseInt;
        }

        public override CustomerCard InsertVehicle()
        {
            initBaseVehicleParams();
            InitEngineParams();
            InitSpecificVehicleParams();

            Vehicle vehicle = new FueledMotorcycle(
                m_Model,
                m_PlateNumber,
                m_Manufacturer,
                m_AirPressure,
                m_MountOfFuel,
                m_License,
                m_Engine);

            return new CustomerCard(m_Owners, m_Phone, vehicle);
        }
    }
}
