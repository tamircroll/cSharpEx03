﻿using System;
using System.Collections.Generic;
using System.Net.Configuration;
using Ex03.GarageLogic.Logic;
using Ex03.GarageLogic.Vehicles;

namespace Ex03.GarageManagementSystem.ConsolUI
{
    public class FuelVehiclesUiHandler
    {
        public static void UiFuelUp()
        {
            String plateNumber;
            float mountToFill;
            Fueled.eFuelType fuelType;

            while (true)
            {
                int fuelTypeIndex = 1;

                Ex02.ConsoleUtils.Screen.Clear();
                Console.WriteLine("Please enter required plate numer");
                plateNumber = Console.ReadLine();
                try
                {
                    Array allFuelTypes = GarageLogicHandler.AllFuelTypes();
                    Console.WriteLine("Please enter required fuel type");
                    foreach (Fueled.eFuelType type in allFuelTypes)
                    {
                        Console.WriteLine("{0}. {1}", fuelTypeIndex++, type);
                    }

                    int fuelTypeValue;
                    string fuelTypeStr = Console.ReadLine();
                    bool isNumber = int.TryParse(fuelTypeStr,out fuelTypeValue);
                    if (isNumber)
                    {
                        fuelTypeValue--;
                    }
                    else
                    {
                        throw new ArgumentException("The Entered fuel type value is not a number");
                    }

                    fuelType = GarageLogicHandler.IntToFuelType(fuelTypeValue);

                    Console.WriteLine("Please enter how many liters of fuel you would like to fill:");
                    string litersToFillStr = Console.ReadLine();

                    isNumber = float.TryParse(litersToFillStr, out mountToFill);
                    if (!isNumber)
                    {
                        throw new ArgumentException("The Entered mount of liters is not a number");
                    }

                    GarageLogicHandler.FillFuel(plateNumber, mountToFill, fuelType);
                    Console.WriteLine("Fuel was successfully filled");
                    Console.ReadLine();
                }
                catch (Exception e)
                {
                    string msg = e.Message;

                    if (e.InnerException!= null)
                    {
                        msg = e.InnerException.Message;
                    }
                    Console.WriteLine(
@"{0}.
Please press 'B' to go back to menu or any other thing to try again.", msg);
                    string choice = Console.ReadLine().ToLower();

                    if (choice == "b")
                    {
                        break;
                    }
                }
            }
        }
    }
}
    