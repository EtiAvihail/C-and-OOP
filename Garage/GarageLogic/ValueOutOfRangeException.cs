using System;

namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {
        private float m_MaximumValue;
        private float m_MinimumValue;
        private string m_ErrorMessage;

        public ValueOutOfRangeException(float i_MinimumValue, float i_MaximumValue, string i_ErrorMessage = "Error: value out of the range")
        {
            m_MaximumValue = i_MaximumValue;
            m_MinimumValue = i_MinimumValue;
            m_ErrorMessage = string.Format("{0}{1}",
                i_ErrorMessage,
                Environment.NewLine);
        }
    }
}
