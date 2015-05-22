using System;
using System.Reflection;
using Ex03.GarageLogic;
using Ex03.GarageLogic.Vehicles;

namespace Ex03.GarageManagementSystem.ConsolUI
{
    using System.Collections.Generic;

    public class ElectricVehiclesActionsExecuter
    {
        private static string k_RemainBatteryMethod = "RemainBattery";
        private static string k_MaxBatteryMethod = "MaxBattery";
        private static string k_ChargeBatteryMethos = "ChargeBattery";

        public static void FuelUp(Dictionary<string, CustomerCard> i_AllVehicles)
        {
            float? maxBattery = null, batteryLeft = null;
            bool isInGarage;
            Vehicle curVehicle = null;

            do
            {
                var plate = ConsoleHandler.GetPlateNumber();
                CustomerCard customerCard;
                isInGarage = i_AllVehicles.TryGetValue(plate, out customerCard);

                if (!isInGarage)
                {
                    Console.WriteLine("The vehicle with plate {0} is not in the garage, please prees Enter and try again.", plate);
                    Console.ReadLine();
                    continue;
                }

                curVehicle = customerCard.Vehicle;
                if (!(bool)curVehicle.IsElectric)
                {
                    Console.WriteLine("The vehicle with plate {0} does not run on electricity, please prees Enter and try again.", plate);
                    Console.ReadLine();
                }
            } while (!isInGarage || !(bool)curVehicle.IsElectric);

            MethodInfo[] methods = curVehicle.GetType().GetMethods();
            foreach (var method in methods)
            {
                if (method.Name == k_MaxBatteryMethod)
                {  
                    maxBattery = (float)method.Invoke(curVehicle, null);
                }

                if (method.Name == k_RemainBatteryMethod)
                {
                    batteryLeft = (float)method.Invoke(curVehicle, null);   //להעביר לדקות!!!!!!!!!
                }
            }

            if (maxBattery == null || batteryLeft == null)
            {
                throw new ArgumentException(@"Could not find all methods");
            }

            float mountToFill;
            float batteryAfterCharge;
            do
            {
                mountToFill = ConsoleHandler.GetFuelMountToFill();
                batteryAfterCharge = (float)( batteryLeft + mountToFill);
                if (batteryAfterCharge > maxBattery)
                {
                    Console.WriteLine("The max mount of battery is {0} and you tried to fill up to {1}, please prees Enter and try again.",
                        maxBattery, batteryAfterCharge);
                    Console.ReadLine();
                }
            } while (batteryAfterCharge > maxBattery);

            bool isCharge = false;
            foreach (var method in methods)
            {
                if (method.Name == k_ChargeBatteryMethos)
                {
                    method.Invoke(curVehicle, new object[] { mountToFill });
                    Console.WriteLine("{0} Liters added and now there are {1} Liters.", mountToFill, batteryAfterCharge);
                    Console.ReadLine();
                    isCharge = true;
                    break;
                }
            }

            if (!isCharge)
            {
                throw new ArgumentException(@"Could not find the method {0}", k_ChargeBatteryMethos);
            }
        }
    }
}
