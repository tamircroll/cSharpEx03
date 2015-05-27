using System;
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
                    string msg = e.Message;

                    if (e.InnerException != null)
                    {
                        msg = e.InnerException.Message;
                    }

                    Console.WriteLine(
@"{0}.
Please press 'B' and Enter to go back to menu or just Enter to try again.",
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
