using System;

namespace Ex03.GarageManagementSystem.ConsolUI
{
    public static class ConsolHandler
    {
        public static int ChooseAction()
        {
            Ex02.ConsoleUtils.Screen.Clear();
            string choiseStr, msg = "Please choose the action you like to perform and press Enter:";
            char choise = '0';

            while (true)
            {
                Console.WriteLine(String.Format(
@"{0}
1. Insert a new vehicle.
2. Show all vehicles plates numbers.
3. Change vehicle state.
4. Fill wheels to maximum
5. Fill full Fuel Tank.
6. Charge battery to maximum.
7. Show veihcle details.
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