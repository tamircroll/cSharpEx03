using System;
using Ex02.ConsoleUtils;
using Ex03.GarageLogic.Logic;
using Ex03.GarageLogic.Vehicles;

namespace Ex03.GarageManagementSystem.ConsolUI
{
    public class FueledVehiclesUiHandler
    {
        public static void UiFuelUp(GarageLogicHandler i_Logic)
        {
            string plateNumber;
            float mountToFill;
            Fueled.eFuelType fuelType;

            while (true)
            {
                int fuelTypeIndex = 1;

                Screen.Clear();
                Console.WriteLine("Please enter required plate numer");
                plateNumber = Console.ReadLine();
                try
                {
                    Array allFuelTypes = i_Logic.AllFuelTypes();
                    Console.WriteLine("Please enter required fuel type");
                    foreach (Fueled.eFuelType type in allFuelTypes)
                    {
                        Console.WriteLine("{0}. {1}", fuelTypeIndex++, type);
                    }

                    int fuelTypeValue;
                    string fuelTypeStr = Console.ReadLine();
                    bool isNumber = int.TryParse(fuelTypeStr, out fuelTypeValue);
                    
                    if (!isNumber)
                    {
                        throw new FormatException("The Entered fuel type value is not a number");
                    }

                    fuelTypeValue--;
                    fuelType = i_Logic.IntToFuelType(fuelTypeValue);

                    Console.WriteLine("Please enter how many liters of fuel you would like to fill:");
                    string litersToFillStr = Console.ReadLine();

                    isNumber = float.TryParse(litersToFillStr, out mountToFill);
                    if (!isNumber)
                    {
                        throw new ArgumentException("The Entered mount of liters is not a number");
                    }

                    i_Logic.FillFuel(plateNumber, mountToFill, fuelType);
                    Console.WriteLine("Fuel was successfully filled");
                    Console.ReadLine();
                    break;
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
Please press 'B' to go back to menu or any other thing to try again.",
                                                                     msg);
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