using System;

namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {
        public float m_MaxValue;
        public float m_MinValue;

        public ValueOutOfRangeException(string i_Concept, float i_ReceivedIndex, float i_MaxValue, float i_MinValue) :
            base(string.Format(@"The index {0} of {1} is out of Range. the Range is {2} to {3}", i_ReceivedIndex,i_Concept, i_MinValue, i_MaxValue))
        {
            m_MaxValue = i_MaxValue;
            m_MinValue = i_MinValue;
        }

        public ValueOutOfRangeException(float i_ReceivedIndex, float i_MaxValue, float i_MinValue) :
            base(string.Format(@"The index {0} is out of Range. the Range is {1} to {2}", i_ReceivedIndex, i_MinValue, i_MaxValue))
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