using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using Ex03.GarageLogic.Vehicles;
using Ex03.GarageManagementSystem.ConsolUI;

namespace Ex03.GarageLogic.Logic.VhicleCreator
{
    public abstract class VehicleCreator
    {
        protected const string k_Owners = "Owners";
        protected const string k_Phone = "Phone";
        protected const string k_Model = "Model";
        protected const string k_PlateNumber = "Plate number";
        protected const string k_Manufacturer = "Wheel manufacturer";
        protected const string k_AirPressure = "Current air pressure";
        protected string m_Owners;
        protected string m_Phone;
        protected string m_Model;
        protected string m_PlateNumber;
        protected Wheel m_Wheel;
        protected string m_Manufacturer;
        protected float m_AirPressure;
        private List<string> m_ParamsList = new List<string>();
        private Dictionary<string, string> m_ParamsDic = new Dictionary<string, string>();

        public VehicleCreator()
        {
            addVehicleParams();
            AddSpecificVehicleParams();
            AddEngineParams();
        }

        private void addVehicleParams()
        {
            ParamsList.Add(k_Owners);
            ParamsList.Add(k_Phone);
            ParamsList.Add(k_Model);
            ParamsList.Add(k_PlateNumber);
            ParamsList.Add(k_Manufacturer);
            ParamsList.Add(k_AirPressure);
        }

        public List<string> ParamsList
        {
            get { return m_ParamsList; }
        }

        public Dictionary<string, string> ParamsDic
        {
            get { return m_ParamsDic; }
        }

        protected void initBaseVehicleParams()
        {
            m_Owners = ParamsDic[k_Owners];
            m_Phone = ParamsDic[k_Phone];
            m_Model = ParamsDic[k_Model];
            m_PlateNumber = ParamsDic[k_PlateNumber];
            m_Manufacturer = ParamsDic[k_Manufacturer];
            bool isNumber = float.TryParse(ParamsDic[k_AirPressure], out m_AirPressure);
            if (!isNumber)
            {
                throw new FormatException("The air pressure input given is not a number");
            }
        }

        protected abstract void AddEngineParams();

        protected abstract void AddSpecificVehicleParams();

        protected abstract void InitSpecificVehicleParams();

        protected abstract void InitEngineParams();

        public abstract CustomerCard InsertVehicle();
    }
}
