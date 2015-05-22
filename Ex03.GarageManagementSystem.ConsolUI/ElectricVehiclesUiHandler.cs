﻿using System;
using Ex03.GarageLogic.Logic;

namespace Ex03.GarageManagementSystem.ConsolUI
{
    public class ElectricVehiclesUiHandler
    {
        public static void Charge()
        {
            String plateNumber;
            float minutesToFill;

            while (true)
            {
                int fuelTypeIndex = 1;

                Ex02.ConsoleUtils.Screen.Clear();
                Console.WriteLine("Please enter required plate numer");
                plateNumber = Console.ReadLine();
                try
                {
                    Console.WriteLine("Please enter how many minutes you would like to charge:");
                    string minutesToFillStr = Console.ReadLine();

                    bool isNumber = float.TryParse(minutesToFillStr, out minutesToFill);
                    if (!isNumber)
                    {
                        throw new ArgumentException("The Entered mount of liters is not a number");
                    }

                    GarageLogicHandler.ChargeBattery(plateNumber, minutesToFill);
                    Console.WriteLine("Battery was successfully charged");
                    Console.ReadLine();
                }
                catch (Exception e)
                {
                    string msg = e.Message;

                    if (e.InnerException != null)
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