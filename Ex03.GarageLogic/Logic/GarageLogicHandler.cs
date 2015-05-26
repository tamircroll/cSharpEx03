using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Ex03.GarageLogic.Vehicles;
using Ex03.GarageManagementSystem.ConsolUI;

namespace Ex03.GarageLogic.Logic
{
    public class GarageLogicHandler
    {
        private readonly Dictionary<string, CustomerCard> r_AllVehicles = new Dictionary<string, CustomerCard>();
        private string m_FillFuelMethos = "FuelUp";
        private string m_ChargeBatteryMethos = "ChargeBattery";

        public CustomerCard GetCustomerCard(string i_Key)
        {
            CustomerCard customerCard;
            bool isInGarage = r_AllVehicles.TryGetValue(i_Key, out customerCard);

            if (!isInGarage)
            {
                throw new KeyNotFoundException(string.Format("The vehicle with plate number {0} is not in the garage", i_Key));
            }

            return customerCard;
        }

        public Vehicle GetVehicle(string i_Plate)
        {
            return GetCustomerCard(i_Plate).Vehicle;
        }

        public string InsertCustomerCard(CustomerCard i_CustomerCard)
        {
            string msg = string.Format("Car with plate {0} added", i_CustomerCard.Vehicle.PlateNumber);

            if (r_AllVehicles.ContainsKey(i_CustomerCard.Vehicle.PlateNumber))
            {
                GetCustomerCard(i_CustomerCard.Vehicle.PlateNumber).Status = CustomerCard.eStatus.Repairing;
                msg = string.Format("Car with plate {0} changed to 'Repairing' state", i_CustomerCard.Vehicle.PlateNumber);
            }
            else
            {
                r_AllVehicles.Add(i_CustomerCard.Vehicle.PlateNumber, i_CustomerCard);
            }

            return msg;
        }

        public void FillFuel(string i_Plate, float i_ToFill, Fueled.eFuelType i_FuelType)
        {
            Vehicle curVehicle = GetVehicle(i_Plate);
            MethodInfo[] methods = curVehicle.GetType().GetMethods();
            bool wasFuled = false; 

            foreach(MethodInfo method in methods)
            {
                if(method.Name == m_FillFuelMethos)
                {
                    method.Invoke(curVehicle, new object[] { i_ToFill, i_FuelType });
                    wasFuled = true;
                }
            }

            if (!wasFuled)
            {
                throw new ArgumentException("This Car does not support fuel funcions");
            }
        }

        public Array AllFuelTypes()
        {
            return Enum.GetValues(typeof(Fueled.eFuelType));
        }

        public Fueled.eFuelType IntToFuelType(int i_FuelTypeInt)
        {
            if (i_FuelTypeInt < 1 || i_FuelTypeInt > Enum.GetValues(typeof(Fueled.eFuelType)).Length)
            {
                throw new ValueOutOfRangeException("fuel type", i_FuelTypeInt, 1, Enum.GetValues(typeof(Fueled.eFuelType)).Length);
            }

            return (Fueled.eFuelType) i_FuelTypeInt;
        }

        public CustomerCard.eStatus IntToStateType(int i_StateTypeInt)
        {
            if (i_StateTypeInt < 1 || i_StateTypeInt > Enum.GetValues(typeof(CustomerCard.eStatus)).Length)
            {
                throw new ValueOutOfRangeException(i_StateTypeInt, 1, Enum.GetValues(typeof(CustomerCard.eStatus)).Length);
            }

            return (CustomerCard.eStatus)i_StateTypeInt;
        }

        public void ChargeBattery(string i_Plate, float i_ToFill)
        {
            Vehicle curVehicle = GetVehicle(i_Plate);
            MethodInfo[] methods = curVehicle.GetType().GetMethods();
            bool wasCharged = false;

            foreach (MethodInfo method in methods)
            {
                if (method.Name == m_ChargeBatteryMethos)
                {
                    method.Invoke(curVehicle, new object[] { i_ToFill });
                    wasCharged = true;
                }
            }

            if (!wasCharged)
            {
                throw new ArgumentException("This Car does not support electric funcions");
            }
        }

        public string showPlates(bool i_ToShowRepairing, bool i_ToShowRepaired, bool i_ToShowPaid)
        {
            StringBuilder allPlates = new StringBuilder(string.Empty);

            foreach (KeyValuePair<string, CustomerCard> card in r_AllVehicles)
            {
                if (card.Value.Status == CustomerCard.eStatus.Repairing && i_ToShowRepairing)
                {
                    allPlates.Append(string.Format("{0}{1}", card.Key, Environment.NewLine));
                }
                else if (card.Value.Status == CustomerCard.eStatus.Repaired && i_ToShowRepaired)
                {
                    allPlates.Append(string.Format("{0}{1}", card.Key, Environment.NewLine));
                }
                else if (card.Value.Status == CustomerCard.eStatus.Paid && i_ToShowPaid)
                {
                    allPlates.Append(string.Format("{0}{1}", card.Key, Environment.NewLine));
                }
            }

            return allPlates.ToString();
        }

        public void ChangeStatus(string i_PlatNumber, CustomerCard.eStatus i_NewStatus)
        {
            CustomerCard curCard = GetCustomerCard(i_PlatNumber);
            curCard.Status = i_NewStatus;
        }

        public string ShowAllVehicleDetails(string i_Plate)
        {
            return GetCustomerCard(i_Plate).ToString();
        }

        public void InflateWheels(string i_Plate)
        {
            Vehicle curVehicle = GetVehicle(i_Plate);
            List<Wheel> curWheels = curVehicle.Wheels;
            foreach (Wheel wheel in curWheels)
            {
                float toInflate = wheel.MaxAirPressure - wheel.AirPressure;
                wheel.InflatWheel(toInflate);
            }
        }
    }
}