using System;
using System.Net.Configuration;
using Ex03.GarageLogic.Vehicles;

namespace Ex03.GarageManagementSystem.ConsolUI
{
    public static class ConsoleHandler
    {
        public const int k_MaxPlateSize = 12;
        public const int k_MinPlateSize = 4;

        public static int ChooseAction()
        {
            Ex02.ConsoleUtils.Screen.Clear();
            string choiseStr, msg = "Please choose the action you like to perform and press Enter:";
            char choise = '0';

            while (true)
            {
                Console.WriteLine(String.Format(
@"{0}
1. Insert a new vehicle.
2. Show all vehicles plates numbers.
3. Change vehicle state.
4. Fill wheels to maximum
5. Fill full Fuel Tank.
6. Charge battery to maximum.
7. Show vehicle details.
", msg));

                choiseStr = Console.ReadLine();
                if (choiseStr.Length == 1)
                {
                    choise = choiseStr.ToCharArray()[0];
                    if (choise >= '1' && choise <= '7')
                    {
                        break;
                    }
                }

                Ex02.ConsoleUtils.Screen.Clear();
                msg = "invalid input, please choose again:";
            }

            return choise - '0';
        }

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

        public static Fueled.eFuelType GetFuel()
        {
            string msg = "Please Choose fuel Type:";
            char choice;

            while (true)
            {
                Ex02.ConsoleUtils.Screen.Clear();
                int i = 1;
                Console.WriteLine(msg);

                foreach (Fueled.eFuelType fuelType in Enum.GetValues(typeof (Fueled.eFuelType)))
                {
                    Console.WriteLine("{0}. {1}", i++, fuelType);
                }

                string choiceStr = Console.ReadLine();
                if (choiceStr.Length == 1)
                {
                    choice = choiceStr.ToCharArray()[0];
                    choice -= '1';
                    if (choice >= 0 && choice < Enum.GetValues(typeof (Fueled.eFuelType)).Length)
                    {
                        break;
                    }
                }
            }

            return (Fueled.eFuelType)choice;
        }

        public static float GetFuelMountToFill()
        {
            float fuelAmount;
            string msg = "Please enter how many liters of fuel you would like to fill:";

            while (true)
            {
                Ex02.ConsoleUtils.Screen.Clear();
                Console.WriteLine(msg);
                string fuelAmountStr = Console.ReadLine();
                bool isNumber = float.TryParse(fuelAmountStr, out fuelAmount);
                if (isNumber)
                {
                    if (fuelAmount > 0)
                    {
                        break;
                    }
                    msg = "Please do not enter a negative number. Please try again:";
                }
                else
                {
                    msg = "The input is not a number. Please try again:";
                }
            }

            return fuelAmount;
        }
    }
}