using System;

namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {
        public float MaxValue { get; set; }
        public float MinValue { get; set; }

        public ValueOutOfRangeException(float i_ReceivedIndex, float i_MaxValue, float i_MinValue) :
            base(string.Format(@"The index {0} is out of Range. the Range is {1}", i_ReceivedIndex, i_MaxValue))
        {
            MaxValue = i_MaxValue;
            MinValue = i_MinValue;
        }
    }
}