using Ex03.GarageLogic.Vehicles;

namespace Ex03.GarageLogic.VhicleCreator
{
    using System;
    using System.Text;

    public static class CarCreatorHelper
    {
        public static string SetColorsField()
        {
            StringBuilder str = new StringBuilder();

            str.Append(string.Format("Color:{0}", Environment.NewLine));
            foreach(Car.eColor color in Enum.GetValues(typeof(Car.eColor)))
            {
                str.Append(string.Format("{0}. {1}{2}", (int) color, color, Environment.NewLine));
            }

            return str.ToString();
        }

        public static string SetNumOfDoorsField()
        {
            StringBuilder str = new StringBuilder();

            str.Append(string.Format("Number of doors:{0}", Environment.NewLine));
            foreach(Car.eNumOfDoors numOfDoors in Enum.GetValues(typeof(Car.eNumOfDoors)))
            {
                str.Append(string.Format("{0}. {1}{2}", (int) numOfDoors, numOfDoors, Environment.NewLine));
            }

            return str.ToString();
        }

        public static Car.eNumOfDoors GetNumOfDoorsStr(string i_NumOfDoorsStr)
        {
            int numOfDoorsInt;

            bool isNumber = int.TryParse(i_NumOfDoorsStr, out numOfDoorsInt);
            if (!isNumber)
            {
                throw new FormatException("The numbers of doors input is not a number");
            }

            if(numOfDoorsInt < 1
                || numOfDoorsInt > Enum.GetValues(typeof(Car.eNumOfDoors)).Length)
            {
                throw new ValueOutOfRangeException(
                    "number of doors",
                    numOfDoorsInt, 
                    Enum.GetValues(typeof(Car.eNumOfDoors)).Length,1 );
            }

            return (Car.eNumOfDoors) numOfDoorsInt;
        }

        public static Car.eColor GetColorStr(string i_ColorsStr)
        {
            int colorInt;
            bool isNumber = int.TryParse(i_ColorsStr, out colorInt);
            if (!isNumber)
            {
                throw new FormatException("The numbers of doors input was not a number");
            }

            if (colorInt < 1 || colorInt > Enum.GetValues(typeof(Car.eColor)).Length)
            {
                throw new ValueOutOfRangeException("Color", colorInt, 1, Enum.GetValues(typeof(Car.eColor)).Length);
            }

            return (Car.eColor) colorInt;
        }
    }
}
