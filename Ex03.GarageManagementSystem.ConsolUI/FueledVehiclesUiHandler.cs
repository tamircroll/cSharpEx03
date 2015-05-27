using System;
using Ex03.GarageLogic.Logic;
using Ex03.GarageLogic.Vehicles;

namespace Ex03.GarageManagementSystem.ConsolUI
{
    public class FueledVehiclesUiHandler
    {
        public static void UiFuelUp(GarageLogicHandler i_Logic)
        {
            float mountToFill;

            while (true)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("Please enter required plate numer");
                    string plateNumber = Console.ReadLine();
                    var fuelType = getFuelTypeFromUser(i_Logic);
                    mountToFill = getMountToFillFromUser();
                    i_Logic.FillFuel(plateNumber, mountToFill, fuelType);
                    Console.WriteLine("Fuel was successfully filled");
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

        private static float getMountToFillFromUser()
        {
            float mountToFill;
            Console.WriteLine("Please enter how many liters of fuel you would like to fill:");
            string litersToFillStr = Console.ReadLine();
            bool isNumber = float.TryParse(litersToFillStr, out mountToFill);
            if (!isNumber)
            {
                throw new ArgumentException("The Entered mount of liters is not a number");
            }

            return mountToFill;
        }

        private static Fueled.eFuelType getFuelTypeFromUser(GarageLogicHandler i_Logic)
        {
            Array allFuelTypes = i_Logic.AllFuelTypes();
            Console.WriteLine("Please enter required fuel type");
            foreach (Fueled.eFuelType curFuelType in allFuelTypes)
            {
                Console.WriteLine("{0}. {1}", (int) curFuelType, curFuelType);
            }

            int fuelTypeValue;
            string fuelTypeStr = Console.ReadLine();
            bool isNumber = int.TryParse(fuelTypeStr, out fuelTypeValue);

            if (!isNumber)
            {
                throw new FormatException("The Entered fuel type value is not a number");
            }

            Fueled.eFuelType fuelType = i_Logic.IntToFuelType(fuelTypeValue);
            return fuelType;
        }
    }
}