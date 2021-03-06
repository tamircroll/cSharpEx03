﻿using Ex03.GarageLogic.Vehicles;
using Ex03.GarageManagementSystem.ConsolUI;

namespace Ex03.GarageLogic.VhicleCreator.NotAbstract
{
    using System;
    using System.Text;

    public class ElectricMotorcycleCreator : ElectricVehicleCreator
    {
        public const string k_Engine = "Engine volume";
        protected Motorcycle.eLicense m_License;
        protected int m_Engine;
        protected string m_LicenseStr = setLicenseField();

        protected override void AddSpecificVehicleParams()
        {
            ParamsDic.Add(m_LicenseStr, null);
            ParamsDic.Add(k_Engine, null);
        }

        private static string setLicenseField()
        {
            StringBuilder str = new StringBuilder();

            str.Append(string.Format("License:{0}", Environment.NewLine));
            foreach (Motorcycle.eLicense color in Enum.GetValues(typeof(Motorcycle.eLicense)))
            {
                str.Append(string.Format("{0}. {1}{2}", (int)color, color, Environment.NewLine));
            }

            return str.ToString();
        }

        protected override void InitSpecificVehicleParams()
        {
            MotorcycleCreatorHelper.SetEngineFeild(ParamsDic[k_Engine], out m_Engine);
            m_License = MotorcycleCreatorHelper.GetLicense(ParamsDic[m_LicenseStr]);
        }

        public override CustomerCard InsertVehicle()
        {
            initBaseVehicleParams();
            InitEngineParams();
            InitSpecificVehicleParams();

            Vehicle vehicle = new ElectricMotorcycle(
                m_Model,
                m_PlateNumber,
                m_Manufacturer,
                m_AirPressure,
                m_BatteryMinutesRemain,
                m_License,
                m_Engine);

            return new CustomerCard(m_Owners, m_Phone, vehicle);
        }
    }
}
