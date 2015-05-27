﻿using System;
using Ex03.GarageLogic.Logic;

namespace Ex03.GarageManagementSystem.ConsolUI
{
    public class ElectricVehiclesUiHandler
    {
        public static void Charge(GarageLogicHandler i_Logic)
        {
            string plateNumber;
            float minutesToFill;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Please enter required plate numer");
                plateNumber = Console.ReadLine();
                try
                {
                    Console.WriteLine("Please enter how many minutes you would like to charge:");
                    string minutesToFillStr = Console.ReadLine();

                    bool isNumber = float.TryParse(minutesToFillStr, out minutesToFill);
                    if (!isNumber)
                    {
                        throw new FormatException("The Entered mount of liters is not a number");
                    }

                    i_Logic.ChargeBattery(plateNumber, minutesToFill);
                    Console.WriteLine("Battery was successfully charged");
                    Console.ReadLine();
                    break;
                }
                catch (Exception e)
                {
                    string choice = GarageUiHandler.ExceptionPrintMsg(e);
                    if (choice == "b")
                    {
                        break;
                    }
                }
            }
        }
    }
}
