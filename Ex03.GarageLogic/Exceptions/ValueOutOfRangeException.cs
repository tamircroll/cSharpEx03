using System;

namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {
        public ValueOutOfRangeException(float i_ReceivedIndex, float i_MaxValue) :
            base(string.Format(@"The index {0} is out of Range. the Range is {1}", i_ReceivedIndex, i_MaxValue))
        {
        }
    }
}