using System;
using System.Collections.Generic;
using Ex03.GarageLogic;
using Ex03.GarageLogic.Logic;
using Ex03.GarageLogic.Logic.VhicleCreator;

namespace Ex03.GarageManagementSystem.ConsolUI
{
    public static class GarageUiHandler
    {
        public static void InsertNewCarOrChangeToRepairing(GarageLogicHandler i_Logic)
        {
            while (true)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("Please Enter plate number:");
                    string plate = Console.ReadLine();
                    if (i_Logic.isInGarage(plate))
                    {
                        i_Logic.ChangeStatus(plate, CustomerCard.eStatus.Repairing);
                        Console.Clear();
                        Console.WriteLine("Car with plate {0} changed to 'Repairing' state", plate);
                    }
                    else
                    {
                        Console.WriteLine("Please choose the type of car you want to insert:");
                        foreach (KeyValuePair<int, string> vehicle in VehicleCreatorFactory.SupportedVehicles)
                        {
                            Console.WriteLine("{0}. {1}", vehicle.Key, vehicle.Value);
                        }

                        string vehicleIndexStr = Console.ReadLine();
                        int vehicleIndex;

                        bool isNumber = int.TryParse(vehicleIndexStr, out vehicleIndex);

                        if (!isNumber)
                        {
                            throw new ArgumentException("The input is not a number");
                        }

                        VehicleCreator vehicleCreator = VehicleCreatorFactory.Create(vehicleIndex);
                        List<string> paramsQuestions = new List<string>(vehicleCreator.ParamsDic.Keys);

                        foreach (string param in paramsQuestions)
                        {
                            if (param == VehicleCreator.k_PlateNumber)
                            {
                                vehicleCreator.ParamsDic[param] = plate;
                            }
                            else
                            {
                                Console.WriteLine("Please Choose {0}", param);
                                vehicleCreator.ParamsDic[param] = Console.ReadLine();
                            }
                        }

                        CustomerCard customerCard = vehicleCreator.InsertVehicle();
                        Console.Clear();
                        i_Logic.InsertCustomerCard(customerCard);
                        Console.WriteLine("Vehicle added");
                    }

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

        public static void ShowAllPlates(GarageLogicHandler i_Logic)
        {
            while(true)
            {
                int filterBy;

                Console.Clear();
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
                        throw new ValueOutOfRangeException(filterBy, 1, 4);
                    }

                    toShowRepairing = filterBy == 1 || filterBy == 2;
                    toShowRepaired = filterBy == 1 || filterBy == 3;
                    toShowPaid = filterBy == 1 || filterBy == 4;

                    Console.Clear();
                    Console.WriteLine(i_Logic.showPlates(toShowRepairing, toShowRepaired, toShowPaid));
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

        public static void ShowAllDetails(GarageLogicHandler i_Logic)
        {
            while (true)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("Please enter the required Plate Number");
                    string plate = Console.ReadLine();
                    string allDetails = i_Logic.ShowAllVehicleDetails(plate);

                    Console.Clear();
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

        public static void ChangeStatus(GarageLogicHandler i_Logic)
        {
            while(true)
            {
                try
                {
                    Console.Clear();
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

                    CustomerCard.eStatus statusType = i_Logic.IntToStateType(statusInt);
                    i_Logic.ChangeStatus(plate, statusType);
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

        public static void InflateWheels(GarageLogicHandler i_Logic)
        {
            while(true)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("Please enter the required Plate Number");
                    string plate = Console.ReadLine();
                    i_Logic.InflateWheels(plate);
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
