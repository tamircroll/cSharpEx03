using System.Collections.Generic;
using Ex03.GarageLogic;
using Ex03.GarageLogic.Logic;
using Ex03.GarageLogic.Vehicles;

namespace Ex03.GarageManagementSystem.ConsolUI
{
    using System;

    public class Program
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
            FueledCar car = new FueledCar("Toyota", "1111", Car.eColor.Green, Car.eNumOfDoors.Three, 10, wheel);
            ElectricCar car2 = new ElectricCar("Toyota", "2222", Car.eColor.White, Car.eNumOfDoors.Four, 10, wheel);

            GarageLogicHandler.InsertVehicle(car, "", "");
            GarageLogicHandler.InsertVehicle(car2, "Tamir", "21324354");

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
                        FuelVehiclesUiHandler.UiFuelUp(allVehicles);
                        break;
                    }
                    case k_ChargeBattery:
                    {
                        ElectricVehiclesActionsExecuter.FuelUp(allVehicles);
                        break;
                    }
                    case k_ShowVehicleDetails:
                    {
                        GarageActionsExecuter.ShowPlate(allVehicles);
                        break;
                    }
                }
            }
        }

        public enum eState
        {
            Repairing = 0,
            Repaired = 1,
            Paid = 2
        }
    }
}
