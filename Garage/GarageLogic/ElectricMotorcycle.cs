using System;
using System.Text;

namespace Ex03.GarageLogic
{
    public class ElectricMotorcycle : ElectricBasedVehicle
    {
        private const float k_MaxAirPressure = 30;
        private const int k_NumberOfTires = 2;
        private Utilities.eTypeOfLicense m_TypeOfLicense;
        private int m_EngineCapacity;

        public ElectricMotorcycle(string i_ModelName, string i_NumberOfCarLicense, string i_NameOfManufacturer, float i_CurTirePressure)
     : base(i_ModelName, i_NumberOfCarLicense, i_NameOfManufacturer, i_CurTirePressure, (float)1.8)
        {
            m_TireList = Utilities.LoadTireData(i_NameOfManufacturer, k_NumberOfTires, i_CurTirePressure, k_MaxAirPressure);
        }

        public static int CheckAndReturnEngineCapacity(string i_Input)
        {
            bool parsingCheck = false;
            int capacity = 0;

            parsingCheck = int.TryParse(i_Input, out capacity);

            if (!parsingCheck)
            {
                throw new FormatException("Error: not a number");
            }

            return capacity;
        }

        public override string ToString()
        {
            StringBuilder electricMotorcycleDetails = new StringBuilder();
            electricMotorcycleDetails.Append(base.ToString());
            electricMotorcycleDetails.AppendFormat(@"
License type: {0}
Engine capacity: {1} ",
m_TypeOfLicense.ToString(),
m_EngineCapacity);
            electricMotorcycleDetails.Append(Environment.NewLine);

            return electricMotorcycleDetails.ToString();
        }

        public Utilities.eTypeOfLicense LicenseType
        {
            get
            {
                return m_TypeOfLicense;
            }

            set
            {
                m_TypeOfLicense = value;
            }
        }

        public int EngineCapacity
        {
            get
            {
                return m_EngineCapacity;
            }

            set
            {
                m_EngineCapacity = value;
            }
        }
    }
}
