using System;
using System.Text;

namespace Ex03.GarageLogic
{
    public class FuelBasedMotorcycle : FuelBasedVehicle
    {
        private const Utilities.eTypeOfFuel k_TypeOfFuel = Utilities.eTypeOfFuel.Octan96;
        private const int k_NumberOfTires = 2;
        private const float k_MaxAirPressure = 30;
        private Utilities.eTypeOfLicense m_TypeOfLicense;
        private int m_EngineCapacity;

        public FuelBasedMotorcycle(string i_NumberOfModel, string i_NumberOfCarLicense, string i_NameOfManufacturer, float i_CurTirePressure)
        : base(i_NumberOfModel, i_NumberOfCarLicense, i_NameOfManufacturer, i_CurTirePressure, Utilities.eTypeOfFuel.Octan96, 6)
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
            StringBuilder fuelBasedMotorcycleDetails = new StringBuilder();
            fuelBasedMotorcycleDetails.Append(base.ToString());
            fuelBasedMotorcycleDetails.AppendFormat(@"
License type: {0}
Engine capacity: {1} ",
m_TypeOfLicense.ToString(),
m_EngineCapacity);
            fuelBasedMotorcycleDetails.Append(Environment.NewLine);

            return fuelBasedMotorcycleDetails.ToString();
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
