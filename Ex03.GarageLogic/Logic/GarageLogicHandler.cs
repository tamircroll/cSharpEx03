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
        private static string k_FillFuelMethos = "FuelUp";
        private static string k_ChargeBatteryMethos = "ChargeBattery";
        private static readonly Dictionary<string, CustomerCard> sr_AllVehicles = new Dictionary<string, CustomerCard>();

        public static CustomerCard GetCustomerCard(string i_Key)
        {
            CustomerCard customerCard;
            bool isInGarage = sr_AllVehicles.TryGetValue(i_Key, out customerCard);

            if (!isInGarage)
            {
                throw  new KeyNotFoundException(String.Format("The vehicle with plate number {0} is not in the garage", i_Key));
            }

            return customerCard;
        }

        public static Vehicle GetVehicle(string i_Plate)
        {
            return GetCustomerCard(i_Plate).Vehicle;
        }

        public static string InsertVehicle(Vehicle vehicle, string i_Owners, string Phone)
        {
            string msg = String.Format("Car with plate {0} added", vehicle.PlateNumber);

            if (sr_AllVehicles.ContainsKey(vehicle.PlateNumber))
            {
                GetCustomerCard(vehicle.PlateNumber).State = CustomerCard.eState.Repairing;
                msg = String.Format("Car with plate {0} changed to 'Repairing' state", vehicle.PlateNumber);
            }
            
            sr_AllVehicles.Add(vehicle.PlateNumber, new CustomerCard(i_Owners, Phone, vehicle));
            
            return msg;
        }

        public static void FillFuel(string i_Plate, float i_ToFill, Fueled.eFuelType i_FuelType)
        {
            Vehicle curVehicle = GetVehicle(i_Plate);
            MethodInfo[] methods = curVehicle.GetType().GetMethods();
            bool wasFuled = false; 

            foreach (MethodInfo method in methods)
            {
                if (method.Name == k_FillFuelMethos)
                {
                    method.Invoke(curVehicle, new object[]{i_ToFill, i_FuelType});
                    wasFuled = true;
                }
            }

            if (!wasFuled)
            {
                throw new ArgumentException("This Car does not support fuel funcions");
            }
        }

        public static Array AllFuelTypes()
        {
            return Enum.GetValues(typeof(Fueled.eFuelType));
        }

        public static Fueled.eFuelType IntToFuelType(int i_FuelTypeInt)
        {
            if (i_FuelTypeInt < 0 || i_FuelTypeInt >= Enum.GetValues(typeof(Fueled.eFuelType)).Length)
            {
                throw new ValueOutOfRangeException(i_FuelTypeInt ,0, Enum.GetValues(typeof (Fueled.eFuelType)).Length);
            }

            return (Fueled.eFuelType) i_FuelTypeInt;
        }

        public static CustomerCard.eState IntToStateType(int i_StateTypeInt)
        {
            if (i_StateTypeInt < 0 || i_StateTypeInt >= Enum.GetValues(typeof(CustomerCard.eState)).Length)
            {
                throw new ValueOutOfRangeException(i_StateTypeInt, 0, Enum.GetValues(typeof(CustomerCard.eState)).Length);
            }

            return (CustomerCard.eState)i_StateTypeInt;
        }

        public static void ChargeBattery(string i_Plate, float i_ToFill)
        {
            Vehicle curVehicle = GetVehicle(i_Plate);
            MethodInfo[] methods = curVehicle.GetType().GetMethods();
            bool wasCharged = false;

            foreach (MethodInfo method in methods)
            {
                if (method.Name == k_ChargeBatteryMethos)
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

        public static string showPlates(bool i_ToShowRepairing, bool i_ToShowRepaired, bool i_ToShowPaid)
        {
            StringBuilder allPlates = new StringBuilder("");

            foreach (KeyValuePair<string, CustomerCard> card in sr_AllVehicles)
            {
                if (card.Value.State == CustomerCard.eState.Repairing && i_ToShowRepairing)
                {
                    allPlates.Append(string.Format("{0}{1}", card.Key, System.Environment.NewLine));
                }
                else if (card.Value.State == CustomerCard.eState.Repaired && i_ToShowRepaired)
                {
                    allPlates.Append(string.Format("{0}{1}", card.Key, System.Environment.NewLine));
                }
                else if (card.Value.State == CustomerCard.eState.Paid && i_ToShowPaid)
                {
                    allPlates.Append(string.Format("{0}{1}", card.Key, System.Environment.NewLine));
                }
            }

            return allPlates.ToString();
        }

        public static void ChangeStatus(string i_PlatNumber, CustomerCard.eState i_NewState)
        {
            CustomerCard curCard= GetCustomerCard(i_PlatNumber);
            curCard.State = i_NewState;
        }

        public static string ShowAllVehicleDetails(string i_Plate)
        {
            return GetCustomerCard(i_Plate).ToString();
        }
    }
}





//    foreach (var vehicle in VehicleManager<Vehicle>.SupportedVehicles)
//    {
//        if (curVehicle.GetType() == vehicle)
//        {
//            Console.WriteLine(vehicle.Name + " GGGGGGGOOOOOOOOOOOODDDDDDDDDDDDDDD");
//            Console.ReadLine();
//        }
//    }
//}
//else
//{
//    //TODO: Throw Exception
//}
