using System;
using System.Collections.Generic;
using Ex02.ConsoleUtils;
using Ex03.GarageLogic;
using Ex03.GarageLogic.Logic;
using Ex03.GarageLogic.Logic.VhicleCreator;

namespace Ex03.GarageManagementSystem.ConsolUI
{
    public static class GarageUiHandler
    {
        public static void InsertNewCar()
        {
            FuledCarCreator c = new FuledCarCreator();

            foreach (string param in c.ParamsList)  // בעיה! אני משנה את הפרמטרים תוך כדי ריצה!!!
            {
                Console.WriteLine("Please Choose {0}", param);
                c.ParamsDic.Add(param, Console.ReadLine());
            }

            CustomerCard v = c.InsertVehicle();

            Console.WriteLine(v);
            Console.ReadLine();
        }

        public static void ShowAllPlates()
        {
            while(true)
            {
                int filterBy;

                Screen.Clear();
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
                        throw new FormatException("The input is not a number");
                    }

                    if (filterBy < 1 || filterBy > 4)
                    {
                        throw new ValueOutOfRangeException(filterBy, 4, 1);
                    }

                    toShowRepairing = filterBy == 1 || filterBy == 2;
                    toShowRepaired = filterBy == 1 || filterBy == 3;
                    toShowPaid = filterBy == 1 || filterBy == 4;

                    Screen.Clear();
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

        public static void ShowAllDetails()
        {
            while (true)
            {
                try
                {
                    Screen.Clear();
                    Console.WriteLine("Please enter the required Plate Number");
                    string plate = Console.ReadLine();
                    string allDetails = GarageLogicHandler.ShowAllVehicleDetails(plate);

                    Ex02.ConsoleUtils.Screen.Clear();
                    Console.WriteLine(allDetails);
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

        public static void ChangeStatus()
        {
            while(true)
            {
                try
                {
                    Screen.Clear();
                    Console.WriteLine("Please enter the required Plate Number");
                    string plate = Console.ReadLine();
                    Console.WriteLine(
@"Please Choose a new status:
1. Repairing
2. Repaired
3. Paid");
                    string status = Console.ReadLine();
                    int statusInt;
                    bool isNumber = int.TryParse(status, out statusInt);
                    if (!isNumber)
                    {
                        throw new FormatException("The input is not a number");
                    }

                    statusInt--;
                    CustomerCard.eStatus statusType = GarageLogicHandler.IntToStateType(statusInt);
                    GarageLogicHandler.ChangeStatus(plate, statusType);
                    Console.WriteLine("Status Changed to {0}", statusType);
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

        public static void InflateWheels()
        {
            while(true)
            {
                try
                {
                    Screen.Clear();
                    Console.WriteLine("Please enter the required Plate Number");
                    string plate = Console.ReadLine();
                    GarageLogicHandler.InflateWheels(plate);
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
