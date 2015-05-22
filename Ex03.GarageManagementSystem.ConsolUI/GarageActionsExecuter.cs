using System;
using System.Collections.Generic;
using Ex03.GarageLogic;
using Ex03.GarageLogic.Logic;

namespace Ex03.GarageManagementSystem.ConsolUI
{
    public static class GarageActionsExecuter
    {
        public static void InsertNewCar(Dictionary<string, CustomerCard> i_AllVehicles)
        {
            //TODO!!!!
        }

        public static void ShowAllPlates()
        {
            while(true)
            {
                int filterBy;

                Ex02.ConsoleUtils.Screen.Clear();
                try
                {
                    bool toShowRepairing, toShowRepaired, toShowPaid;
                    Console.WriteLine(
@"Please Choose a filter:
1. No filter
2. Repairing
3. Repaired
4. Paid");
                    string filterByStr = Console.ReadLine();
                    bool isNumber = int.TryParse(filterByStr, out filterBy);

                    if (!isNumber)
                    {
                        throw new ArgumentException("The input is not a number");
                    }

                    if (filterBy < 1 || filterBy > 4)
                    {
                        throw new ValueOutOfRangeException(filterBy, 4, 1);
                    }

                    toShowRepairing = filterBy == 1 || filterBy == 2;
                    toShowRepaired = filterBy == 1 || filterBy == 3;
                    toShowPaid = filterBy == 1 || filterBy == 4;

                    Ex02.ConsoleUtils.Screen.Clear();
                    Console.WriteLine(GarageLogicHandler.showPlates(toShowRepairing, toShowRepaired, toShowPaid));
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
Please press 'B' to go back to menu or any other thing to try again.", msg);
                    string choice = Console.ReadLine().ToLower();

                    if (choice == "b")
                    {
                        break;
                    }
                }
            }
        }

        public static void ShowAllDetails()
        {
            Ex02.ConsoleUtils.Screen.Clear();
            Console.WriteLine("Please enter the required Plate Number");
            string plate = Console.ReadLine();
            string allDetails = GarageLogicHandler.ShowAllVehicleDetails(plate);
            
            Console.WriteLine(allDetails);
            Console.ReadLine();
        }
    }
}


//    foreach (var vehicle in VehicleManager<Vehicle>.SupportedVehicles)
//    {
//        if (curVehicle.GetType() == vehicle)
//        {
//            Console.WriteLine(vehicle.Name + " GGGGGGGOOOOOOOOOOOODDDDDDDDDDDDDDD");
//            Console.ReadLine();
//        }
//    }
//}
//else
//{
//    //TODO: Throw Exception
//}
