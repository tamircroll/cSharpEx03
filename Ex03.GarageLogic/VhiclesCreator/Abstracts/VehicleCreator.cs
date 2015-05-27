using System;
using System.Collections.Generic;
using Ex03.GarageManagementSystem.ConsolUI;

namespace Ex03.GarageLogic.Logic.VhicleCreator
{
    public abstract class VehicleCreator
    {
        public const string k_Owners = "Owners";
        public const string k_Phone = "Phone";
        public const string k_Model = "Model";
        public const string k_Manufacturer = "Wheel manufacturer";
        public const string k_AirPressure = "Current air pressure";
        public const string k_PlateNumber = "Plate number";
        protected string m_Owners;
        protected string m_Phone;
        protected string m_Model;
        protected string m_PlateNumber;
        protected string m_Manufacturer;
        protected float m_AirPressure;
        private Dictionary<string, string> m_ParamsDic = new Dictionary<string, string>();

        public VehicleCreator()
        {
            addVehicleParams();
            AddSpecificVehicleParams();
            AddEngineParams();
        }

        private void addVehicleParams()
        {
            ParamsDic.Add(k_PlateNumber, null);
            ParamsDic.Add(k_Owners, null);
            ParamsDic.Add(k_Phone, null);
            ParamsDic.Add(k_Model, null);
            ParamsDic.Add(k_Manufacturer, null);
            ParamsDic.Add(k_AirPressure, null);
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
