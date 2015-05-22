//using System;
//using System.Reflection;
//using System.Runtime.Remoting.Channels;
//using Ex03.GarageLogic.Exceptions;
//using Ex03.GarageLogic.Vehicles;
//using Ex03.GarageManagementSystem.ConsolUI;
//
//namespace Ex03.GarageLogic.Logic
//{
//    using System.Collections.Generic;
//
//    public class FuelVehicleLogicHandler
//    {
//        private static string k_MaxFuelMethod = "MaxFuel";
//        private static string k_CurFuelMethod = "MountOfFuel";
//        private static string k_FillFuelMethos = "FuelUp";
//        private static string k_FuelTypeMethod = "FuelType";
//        private static Dictionary<string, CustomerCard> s_AllVehicles;
//        private CustomerCard m_CustomerCard;
//        private string m_PlateNumber;
//        private Vehicle m_CurVehicle;
//        private int m_FuelToAdd;
//        private Fueled.eFuelType m_FuelType;
//        private float m_LitersOfFuelToAdd;
//
//        public FuelVehicleLogicHandler(Dictionary<string, CustomerCard> i_AllVehicles)
//        {
//            s_AllVehicles = i_AllVehicles;
//        }
//
//        public string PlateNumber
//        {
//            set
//            {
//                bool isInGarage = s_AllVehicles.TryGetValue(value, out m_CustomerCard);
//
//                if (!isInGarage)
//                {
//                    throw new ArgumentException("The car with plate {0} is not in the garage", value);
//                }
//
//                m_CurVehicle = m_CustomerCard.Vehicle;
//
//                if ((bool)m_CurVehicle.IsElectric)
//                {
//                    throw new ArgumentException("The car with plate {0} runs does not run on fuel", value);
//                }
//
//                m_PlateNumber = value;
//            }
//        }
//
//
//        public Array AllFuelTypes()
//        {
//            return Enum.GetValues(typeof (Fueled.eFuelType));
//        }
//
//        public int FuelTypeToAdd
//        {
//            set
//            {
//                Fueled.eFuelType? requiredFuelType = null;
//                MethodInfo[] methods = m_CurVehicle.GetType().GetMethods();
//                foreach (var method in methods)
//                {
//                    if (method.Name == k_FuelTypeMethod)
//                    {
//                        requiredFuelType = (Fueled.eFuelType) method.Invoke(m_CurVehicle, null);
//                    }
//                }
//
//                if (requiredFuelType == null)
//                {
//                    throw new ArgumentException("This vehicle doesn't support all fuel methods");
//                }
//
//                if (requiredFuelType != (Fueled.eFuelType)value)
//                {
//                    throw new ArgumentException(string.Format("This vehicle needs {0} and you chose {1}", (Fueled.eFuelType)requiredFuelType, 
//                        (Fueled.eFuelType)value));
//                }
//
//                if (value < 0 || value >= Enum.GetValues(typeof (Fueled.eFuelType)).Length)
//                {
//                    m_FuelType = (Fueled.eFuelType) value;
//                }
//                else
//                {
//                    throw new ValueOutOfRangeException(value, 0, Enum.GetValues(typeof(Fueled.eFuelType)).Length);
//                }
//            }
//        }
//
//        public int LitersOfFuelToAdd
//        {
//            set
//            {
//                float? curFuel = null;
//                float? maxFuel = null;
//
//                if (m_CurVehicle == null)
//                {
//                    throw new ArgumentException(
//                        "Cannot choose how much liters to add before you chose a specific vehicle");
//                }
//
//                MethodInfo[] methods = m_CurVehicle.GetType().GetMethods();
//                foreach (var method in methods)
//                {
//                    if (method.Name == k_CurFuelMethod)
//                    {
//                        curFuel = (float)method.Invoke(m_CurVehicle, null);
//                    }
//
//                    if (method.Name == k_MaxFuelMethod)
//                    {
//                        maxFuel = (float)method.Invoke(m_CurVehicle, null);
//                    }
//                }
//
//                if (curFuel == null || maxFuel == null)
//                {
//                    throw new ArgumentException("This vehicle doesn't support all fuel methods");
//                }
//
//                float afterAddition = (float) (value + curFuel);
//                if (value < 0 || afterAddition > maxFuel)
//                {
//                    throw new ValueOutOfRangeException(value, 0, (float)curFuel);
//                }
//
//                m_LitersOfFuelToAdd = afterAddition;
//            }
//        }
//
//        public void Execute
//
//
//
//
//        //public void UiFuelUp(Dictionary<string, CustomerCard> i_AllVehicles)
//        //{
//
//
//
//
//
//        //       FuelVehicleLogicHandler m_Logic = new FuelVehicleLogicHandler(i_AllVehicles);
//        //       Fueled.eFuelType? requiredFuelType = null;
//        //       float? maxFuel = null, curFuel = null;
//        //       bool isInGarage;
//        //       Vehicle curVehicle = null;
//
//        //    do
//        //    {
//        //        string plate = ConsoleHandler.GetPlateNumber();
//        //        CustomerCard customerCard;
//        //        isInGarage = i_AllVehicles.TryGetValue(plate, out customerCard);
//
//        //        if (!isInGarage)
//        //        {
//        //            Console.WriteLine("The vehicle with plate {0} is not in the garage, please prees Enter and try again.", plate);
//        //            Console.ReadLine();
//        //            continue;
//        //        }
//
//        //        curVehicle = customerCard.Vehicle;
//        //        if ((bool)curVehicle.IsElectric)
//        //        {
//        //            Console.WriteLine("The vehicle with plate {0} does not run on fuel, please prees Enter and try again.", plate);
//        //            Console.ReadLine();
//        //        }
//        //    } while (!isInGarage || (bool)curVehicle.IsElectric);
//
//        //    MethodInfo[] methods = curVehicle.GetType().GetMethods();
//        //    foreach (var method in methods)
//        //    {
//        //        if (method.Name == k_MaxFuelMethod)
//        //        {
//        //            maxFuel = (float)method.Invoke(curVehicle, null);
//        //        }
//
//        //        if (method.Name == k_CurFuelMethod)
//        //        {
//        //            curFuel = (float)method.Invoke(curVehicle, null);
//        //        }
//
//        //        if (method.Name == k_FuelTypeMethod)
//        //        {
//        //            requiredFuelType = (Fueled.eFuelType)method.Invoke(curVehicle, null);
//        //        }
//        //    }
//
//        //    if (maxFuel == null || curFuel == null || requiredFuelType == null)
//        //    {
//        //        throw new ArgumentException(@"Could not find all methods");
//        //    }
//
//        //    Fueled.eFuelType FuelTypeToFill;
//        //    do
//        //    {
//        //        FuelTypeToFill = ConsoleHandler.GetFuel();
//        //        if (requiredFuelType != FuelTypeToFill)
//        //        {
//        //            Console.WriteLine("The fuel type needed is {0}, and you asked for {1}, please prees Enter and try again.", requiredFuelType,
//        //                FuelTypeToFill);
//        //            Console.ReadLine();
//        //        }
//        //    } while (requiredFuelType != FuelTypeToFill);
//
//        //    float mountToFill;
//        //    float fuelAfterAddition;
//        //    do
//        //    {
//        //        mountToFill = ConsoleHandler.GetFuelMountToFill();
//        //        fuelAfterAddition = (float)(mountToFill + curFuel);
//        //        if (fuelAfterAddition > maxFuel)
//        //        {
//        //            Console.WriteLine("The max mount of fuel is {0} and you tried to fill up to {1}, please prees Enter and try again.",
//        //                maxFuel, fuelAfterAddition);
//        //            Console.ReadLine();
//        //        }
//        //    } while (fuelAfterAddition > maxFuel);
//
//        //    bool isFueled = false;
//        //    foreach (var method in methods)
//        //    {
//        //        if (method.Name == k_FillFuelMethos)
//        //        {
//        //            method.Invoke(curVehicle, new object[] { mountToFill, FuelTypeToFill });
//        //            Console.WriteLine("{0} Liters added and now there are {1} Liters.", mountToFill, fuelAfterAddition);
//        //            Console.ReadLine();
//        //            isFueled = true;
//        //            break;
//        //        }
//        //    }
//
//        //    if (!isFueled)
//        //    {
//        //        throw new ArgumentException(@"Could not find the method {0}", k_FillFuelMethos);
//        //    }
//        //}
//
//
//
//
//
//
//
//    }
//}
