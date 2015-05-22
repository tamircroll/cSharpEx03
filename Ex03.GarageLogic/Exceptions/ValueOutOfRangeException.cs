using System;

namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {
        public float m_MaxValue;
        public float m_MinValue;

        public ValueOutOfRangeException(float i_ReceivedIndex, float i_MaxValue, float i_MinValue) :
            base(string.Format(@"The index {0} is out of Range. the Range is {1}", i_ReceivedIndex, i_MaxValue))
        {
            m_MaxValue = i_MaxValue;
            m_MinValue = i_MinValue;
        }

        public ValueOutOfRangeException(int i_ReceivedIndex, int i_MaxValue, int i_MinValue) :
            base(string.Format(@"The index {0} is out of Range. the Range is {1}", i_ReceivedIndex, i_MaxValue))
        {
            m_MaxValue = i_MaxValue;
            m_MinValue = i_MinValue;
        }


        public float MaxValue
        {
            get { return m_MaxValue; }
        }

        public float MinValue
        {
            get { return m_MinValue; }
        }
    }
}