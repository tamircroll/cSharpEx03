using System;
using System.Net.Configuration;
using Ex03.GarageLogic.Vehicles;

namespace Ex03.GarageManagementSystem.ConsolUI
{
    public static class ConsoleHandler
    {
        public const int k_MaxPlateSize = 12;
        public const int k_MinPlateSize = 4;


        public static string GetPlateNumber()
        { 
            string plate = string.Empty;
            string msg = "Please enter the required Plate Number";

            while (true)
            {
                Ex02.ConsoleUtils.Screen.Clear();
                Console.WriteLine(msg);
                plate = Console.ReadLine();

                if (plate.Length >= k_MinPlateSize && plate.Length <= k_MaxPlateSize)
                {
                    break;
                }

                msg = "Invalid plate number, Please try again:";
            }

            return plate;
        }
    }
}