using Ex03.GarageLogic.Logic;

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
            GarageLogicHandler logic = new GarageLogicHandler();

            Console.SetWindowSize(100, 70);
            while (true)
            {
                int choise = ChooseAction();

                switch (choise)
                {
                    case k_insertVehicle:
                    {
                        GarageUiHandler.InsertNewCarOrChangeToRepairing(logic);
                        break;
                    }
                    case k_ShowAllPlates:
                    {
                        GarageUiHandler.ShowAllPlates(logic);
                        break;
                    }
                    case k_ChangeState:
                    {
                        GarageUiHandler.ChangeStatus(logic);
                        break;
                    }
                    case k_FillWheels:
                    {
                        GarageUiHandler.InflateWheels(logic);
                        break;
                    }
                    case k_FuelUp:
                    {
                        FueledVehiclesUiHandler.UiFuelUp(logic);
                        break;
                    }
                    case k_ChargeBattery:
                    {
                        ElectricVehiclesUiHandler.Charge(logic);
                        break;
                    }
                    case k_ShowVehicleDetails:
                    {
                        GarageUiHandler.ShowAllDetails(logic);
                        break;
                    }
                }
            }
        }

        public static int ChooseAction()
        {
            Console.Clear();
            string choiseStr, msg = "Please choose the action you like to perform and press Enter:";
            char choise;

            while (true)
            {
                Console.WriteLine(String.Format(
@"{0}
1. Insert a new vehicle or cahnge an existing car to repairing state.
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

                Console.Clear();
                msg = "invalid input, please choose again:";
            }

            return choise - '0';
        }
    }
}
