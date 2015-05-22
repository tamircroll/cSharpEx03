using System;
using System.Collections.Generic;
using Ex03.GarageLogic.Logic;
using Ex03.GarageLogic.Vehicles;

namespace Ex03.GarageManagementSystem.ConsolUI
{
    public class FuelVehiclesUiHandler
    {


        public void UiFuelUp(Dictionary<string, CustomerCard> i_AllVehicles)
        {
            while (true)
            {
                int fuelTypeIndex = 1;
                GarageLogicHandler logic = new GarageLogicHandler();
                try
                {
                    Console.WriteLine("Please enter required plate numer");
                    logic.PlateNumber = Console.ReadLine();

                    Array allFuelTypes = logic.AllFuelTypes();
                    
                    Console.WriteLine("Please enter required fuel type");
                    foreach (Fueled.eFuelType fuelType in allFuelTypes)
                    {
                        Console.WriteLine("{0}. {1}", fuelTypeIndex++, fuelType);
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
                        fuelTypeValue = -1;
                    }

                    logic.FuelTypeToAdd = fuelTypeValue;


                }
                catch (Exception e)
                {
                    Console.WriteLine(string.Format(
@"{0}.
Please press 'B' to go back to menu or any other thing to try again.",e.Message));
                    string choice = Console.ReadLine().ToLower();

                    if (choice == 'b')
                    {
                        break;
                    }
                }
            }
        }
    }
}
    