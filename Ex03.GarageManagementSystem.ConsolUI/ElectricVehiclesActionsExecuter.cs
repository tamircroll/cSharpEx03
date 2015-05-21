namespace Ex03.GarageManagementSystem.ConsolUI
{
    using System.Collections.Generic;

    public class ElectricVehiclesActionsExecuter
    {
        private static string k_MaxFuelMethodName = "MaxFuel";
        private static string k_CurFuelMethodName = "MountOfFuel";
        private static string k_FillFuelMethosName = "FuelUp";

        public static void FuelUp(Dictionary<string, CustomerCard> i_AllVehicles)
        {
        //    Fueled.eFuelType? requiredFuelType = null;
        //    float? maxFuel = null, curFuel = null;
        //    bool isInGarage, isOnFuel;
        //    Vehicle curVehicle = null;

        //    do
        //    {
        //        var plate = ConsoleHandler.GetPlateNumber();
        //        CustomerCard customerCard;
        //        isInGarage = i_AllVehicles.TryGetValue(plate, out customerCard);

        //        if (!isInGarage)
        //        {
        //            Console.WriteLine("The vehicle with plate {0} is not in the garage, please prees Enter and try again.", plate);
        //            Console.ReadLine();
        //            continue;
        //        }

        //        curVehicle = customerCard.Vehicle;
        //        if ((bool)curVehicle.IsElectric)
        //        {
        //            Console.WriteLine("The vehicle with plate {0} does not run on fuel, please prees Enter and try again.", plate);
        //            Console.ReadLine();
        //        }
        //    } while (!isInGarage || (bool)curVehicle.IsElectric);

        //    MethodInfo[] methods = curVehicle.GetType().GetMethods();
        //    foreach (var method in methods)
        //    {
        //        if (method.Name == k_MaxFuelMethodName)
        //        {
        //            maxFuel = (float)method.Invoke(curVehicle, null);
        //        }

        //        if (method.Name == k_CurFuelMethodName)
        //        {
        //            curFuel = (float)method.Invoke(curVehicle, null);
        //        }

        //        if (method.Name == k_FuelTypeMethodName)
        //        {
        //            requiredFuelType = (Fueled.eFuelType)method.Invoke(curVehicle, null);
        //        }
        //    }

        //    if (maxFuel == null || curFuel == null || requiredFuelType == null)
        //    {
        //        throw new ArgumentException(@"Could not find all methods");
        //    }

        //    Fueled.eFuelType FuelTypeToFill;
        //    do
        //    {
        //        FuelTypeToFill = ConsoleHandler.GetFuel();
        //        if (requiredFuelType != FuelTypeToFill)
        //        {
        //            Console.WriteLine("The fuel type needed is {0}, and you asked for {1}, please prees Enter and try again.", requiredFuelType,
        //                FuelTypeToFill);
        //            Console.ReadLine();
        //        }
        //    } while (requiredFuelType != FuelTypeToFill);

        //    float mountToFill;
        //    float fuelAfterAddition;
        //    do
        //    {
        //        mountToFill = ConsoleHandler.GetFuelMountToFill();
        //        fuelAfterAddition = (float)(mountToFill + curFuel);
        //        if (fuelAfterAddition > maxFuel)
        //        {
        //            Console.WriteLine("The max mount of fuel is {0} and you tried to fill up to {1}, please prees Enter and try again.",
        //                maxFuel, fuelAfterAddition);
        //            Console.ReadLine();
        //        }
        //    } while (fuelAfterAddition > maxFuel);

        //    bool isFueled = false;
        //    foreach (var method in methods)
        //    {
        //        if (method.Name == k_FillFuelMethosName)
        //        {
        //            method.Invoke(curVehicle, new object[] { mountToFill, FuelTypeToFill });
        //            Console.WriteLine("{0} Liters added and now there are {1} Liters.", mountToFill, fuelAfterAddition);
        //            Console.ReadLine();
        //            isFueled = true;
        //            break;
        //        }
        //    }

        //    if (!isFueled)
        //    {
        //        throw new ArgumentException(@"Could not find the method {0}", k_FillFuelMethosName);
        //    }
        //}



    }
}
