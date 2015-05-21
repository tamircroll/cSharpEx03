using System;
using System.Collections.Generic;
using Ex03.GarageLogic;
using Ex03.GarageLogic.Vehicles;

namespace Ex03.GarageManagementSystem.ConsolUI
{
    public static class GarageActionsExecuter
    {
        public static void InsertNewCar(Dictionary<string, CustomerCard> i_AllVehicles)
        {
            while (true)
            {
                string plate = ConsoleHandler.GetPlateNumber();

            }
        }

        public static void ShowAllPlates(Dictionary<string, CustomerCard> i_AllVehicles, bool i_OnlyRepairing, bool i_OnlyRepaired, bool i_OnlyPaid)
        {
            bool notAllFalse = i_OnlyRepairing || i_OnlyRepaired || i_OnlyPaid;
            Ex02.ConsoleUtils.Screen.Clear();

            if ((i_OnlyRepairing && i_OnlyRepaired) || (i_OnlyRepaired && i_OnlyPaid) || (i_OnlyRepairing && i_OnlyPaid))
            {
                throw new ArgumentException("Only one of the conditions can be true");
            }

            foreach (var vehicle in i_AllVehicles)
            {
                if (notAllFalse)
                {
                }
                else
                {
                    Console.WriteLine(vehicle.Value.ToString());
                    Console.WriteLine();
                }
            }

            Console.ReadLine();
        }

        public static void ShowPlate(Dictionary<string, CustomerCard> i_AllVehicles)
        {
            string plate = ConsoleHandler.GetPlateNumber();
            CustomerCard desieredCard;
            if (i_AllVehicles.ContainsKey(plate))
            {
                Ex02.ConsoleUtils.Screen.Clear();
                i_AllVehicles.TryGetValue(plate, out desieredCard);
                Console.WriteLine(desieredCard);
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("This car is not in the Garage");
                Console.ReadLine();
            }
        }

        public static void FuelUp(Dictionary<string, CustomerCard> i_AllVehicles)
        {
            string plate = ConsoleHandler.GetPlateNumber();
            Fueled.eFuelType fuel = ConsoleHandler.GetFuel();
            float i_MountToFill = ConsoleHandler.GetFuelMountToFill();
            CustomerCard customerCard;
            bool isInGarage = i_AllVehicles.TryGetValue(plate, out customerCard);

            if (isInGarage)
            {
                if (!(bool)customerCard.Vehicle.IsElectric)
                {
                    Console.Write(customerCard.Vehicle.IsElectric);
                    Console.ReadLine();

                    foreach (var vehicle in VehicleCreator<Vehicle>.SupportedVehicles)
                    {
                        if (customerCard.Vehicle is vehicle)
                        {
                        }
                    }
                    
                }
                else
                {
                    //TODO: Throw Exception
                }
            }
        }
    }
}