using Ex03.GarageLogic;
using Ex03.GarageLogic.Vehicles;

namespace Ex03.GarageManagementSystem.ConsolUI
{
    using System;

    public class GarageManager
    {
        public static void Main(string[] args)
        {


            while (true)
            {
                int choise = ConsolHandler.ChooseAction();

                switch (choise)
                {
                    case 1:
                    {
                        break;
                    }
                    case 2:
                    {
                        break;
                    }
                    case 3:
                    {
                        break;
                    }
                    case 4:
                    {
                        break;
                    }
                    case 5:
                    {
                        break;
                    }
                    case 6:
                    {
                        break;
                    }
                    case 7:
                    {
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
