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
            ElectricCar car2 = new ElectricCar("Toyota", "2222", Car.eColor.White, Car.eNumOfDoors.Four, 1.2f, wheel);

            GarageLogicHandler.InsertVehicle(car, "", "");
            GarageLogicHandler.InsertVehicle(car2, "Tamir", "21324354");
            
            while (true)
            {
                int choise = ChooseAction();

                switch (choise)
                {
                    case k_insertVehicle:
                    {
                        GarageUiHandler.InsertNewCar();
                        break;
                    }
                    case k_ShowAllPlates:
                    {
                        GarageUiHandler.ShowAllPlates();
                        break;
                    }
                    case k_ChangeState:
                    {
                        GarageUiHandler.ChangeStatus();
                        break;
                    }
                    case k_FillWheels:
                    {
                        GarageUiHandler.InflateWheels();
                        break;
                    }
                    case k_FuelUp:
                    {
                        FuelVehiclesUiHandler.UiFuelUp();
                        break;
                    }
                    case k_ChargeBattery:
                    {
                        ElectricVehiclesUiHandler.Charge();
                        break;
                    }
                    case k_ShowVehicleDetails:
                    {
                        GarageUiHandler.ShowAllDetails();
                        break;
                    }
                }
            }
        }

        public static int ChooseAction()
        {
            Ex02.ConsoleUtils.Screen.Clear();
            string choiseStr, msg = "Please choose the action you like to perform and press Enter:";
            char choise;

            while (true)
            {
                Console.WriteLine(String.Format(
@"{0}
1. Insert a new vehicle.
2. Show all vehicles plates numbers.
3. Change vehicle state.
4. Inflate wheels to maximum.
5. Fill fuel Tank.
6. Charge battery.
7. Show vehicle details.
", msg));

                choiseStr = Console.ReadLine();
                if (choiseStr.Length == 1)
                {
                    choise = choiseStr.ToCharArray()[0];
                    if (choise >= '1' && choise <= '7')
                    {
                        break;
                    }
                }

                Ex02.ConsoleUtils.Screen.Clear();
                msg = "invalid input, please choose again:";
            }

            return choise - '0';
        }
    }
}
