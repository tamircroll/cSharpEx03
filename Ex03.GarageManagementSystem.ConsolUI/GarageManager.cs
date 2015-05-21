﻿using System.Collections.Generic;
using Ex03.GarageLogic;
using Ex03.GarageLogic.Vehicles;

namespace Ex03.GarageManagementSystem.ConsolUI
{
    using System;

    public class GarageManager
    {
        private const int k_insertVehicle = 1,
            k_ShowAllPlates = 2,
            k_ChangeState = 3,
            k_FillWheels = 4,
            k_FuelUp = 5,
            k_ChargeBattery = 6,
            k_ShowVehicleDetails = 7;

        public static void Main(string[] args)
        {
            Dictionary<string, CustomerCard> allVehicles = new Dictionary<string, CustomerCard>();



            Wheel wheel = new Wheel("hob", 4f, 7f);

            List<Wheel> wheels = new List<Wheel>(){wheel, wheel};

            FueledCar car = new FueledCar("Toyota", "59-985-68", Car.eColor.Green, Car.eNumOfDoors.Three, 40, wheels);
            ElectricCar car2 = new ElectricCar("Toyota", "51-415-68", Car.eColor.White, Car.eNumOfDoors.Four, 54, wheels);

            CustomerCard cust1 = new CustomerCard("Yossi", "054-9565986", car);
            CustomerCard cust2 = new CustomerCard("Tamir", "21324354", car2);

            allVehicles.Add(car.PlateNumber, cust1);
            allVehicles.Add(car2.PlateNumber, cust2);

            while (true)
            {
                int choise = ConsoleHandler.ChooseAction();

                switch (choise)
                {
                    case k_insertVehicle:
                    {
                        GarageActionsExecuter.InsertNewCar(allVehicles);
                        break;
                    }
                    case k_ShowAllPlates:
                    {
                        GarageActionsExecuter.ShowAllPlates(allVehicles, false, false, false);
                        break;
                    }
                    case k_ChangeState:
                    {
                        break;
                    }
                    case k_FillWheels:
                    {
                        break;
                    }
                    case k_FuelUp:
                    {
                        GarageActionsExecuter.FuelUp();
                        break;
                    }
                    case k_ChargeBattery:
                    {
                        break;
                    }
                    case k_ShowVehicleDetails:
                    {
                        GarageActionsExecuter.ShowPlate(allVehicles);
                        break;
                    }
                }
            }


            //Wheel wheel = new Wheel("hob", 4f, 7f);
            //FueledCar car = new FueledCar("Toyota", "59-985-68", Car.eColor.Green, Car.eNumOfDoors.Three, 40, null);
            //ElectricCar car2 = new ElectricCar("Toyota", "59-985-68", Car.eColor.White, Car.eNumOfDoors.Four, 54, null);

            //Console.WriteLine(car.ToString());
            //Console.WriteLine(car2.ToString());
            //Console.ReadLine();
        }

        public enum eState
        {
            Repairing = 0,
            Repaired = 1,
            Paid = 2
        }
    }
}
