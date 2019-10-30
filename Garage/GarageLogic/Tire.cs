using System.Text;

namespace Ex03.GarageLogic
{
    public class Tire
    {
        private string m_NameOfManufacturer;
        private float m_CurTirePressure;
        private float m_MaxTirePressure;

        public void InflateTire(int i_AmountOfGasToAdd)
        {
            if (m_CurTirePressure + i_AmountOfGasToAdd > m_MaxTirePressure)
            {
                throw new ValueOutOfRangeException(0, m_MaxTirePressure, "Tire Pressure is too high");
            }
            else
            {
                m_CurTirePressure += m_CurTirePressure + i_AmountOfGasToAdd;
            }
        }

        public Tire(string i_NameOfManufacturer, float i_CurTirePressure, int i_MaxTirePressure)
        {
            m_NameOfManufacturer = i_NameOfManufacturer;
            m_MaxTirePressure = i_MaxTirePressure;
            m_CurTirePressure = i_CurTirePressure;
        }

        public void InflateTireToMaximum()
        {
            m_CurTirePressure = m_MaxTirePressure;
        }

        public string ToString(int i_NumberOfTire)
        {
            StringBuilder tireDetails = new StringBuilder();
            tireDetails.AppendFormat("Tire {0} : ", i_NumberOfTire);
            tireDetails.AppendFormat(@"Air Pressure: {0}
Manufacturer: {1}",
m_CurTirePressure,
m_NameOfManufacturer);

            return tireDetails.ToString();
        }
    }
}
