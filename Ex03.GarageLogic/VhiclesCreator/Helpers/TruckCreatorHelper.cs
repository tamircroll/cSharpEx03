using System;

namespace Ex03.GarageLogic.VhicleCreator
{
    public class TruckCreatorHelper
    {
        public static void SetCarryWeight(string i_CarryWeightStr, out float o_CarryWeight)
        {
            bool isNumber = float.TryParse(i_CarryWeightStr, out o_CarryWeight);
            if (!isNumber)
            {
                throw new FormatException("The engine input is not a number");
            }
        }

        public static bool GetDangerousMaterials(string i_DangerousStr)
        {
            if (i_DangerousStr != "1" && i_DangerousStr != "2")
            {
                throw new FormatException("The input for Dangerous matirials is not a number in the range");
            }

            return i_DangerousStr == "1";
        }
    }
}