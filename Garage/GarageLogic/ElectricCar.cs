using System;
using System.Text;

namespace Ex03.GarageLogic
{
    public class ElectricCar : ElectricBasedVehicle
    {
        private const float k_MaxAirPressure = 32;
        private const int k_NumberOfTires = 4;
        private Utilities.eColor m_Color;
        private Utilities.eNumberOfDoors m_NumberOfDoors;

        public ElectricCar(string i_ModelName, string i_NumberOfCarLicense, string i_NameOfManufacturer, float i_CurTirePressure)
            : base(i_ModelName, i_NumberOfCarLicense, i_NameOfManufacturer, i_CurTirePressure, (float)3.2)
        {
            m_TireList = Utilities.LoadTireData(i_NameOfManufacturer, k_NumberOfTires, i_CurTirePressure, k_MaxAirPressure);
        }

        public override string ToString()
        {
            StringBuilder electricCarDetails = new StringBuilder();
            electricCarDetails.Append(base.ToString());
            electricCarDetails.AppendFormat(string.Format(@"
Number of doors: {0}
Car color: {1} ",
m_NumberOfDoors.ToString(),
m_Color.ToString()));
            electricCarDetails.Append(Environment.NewLine);

            return electricCarDetails.ToString();
        }

        public Utilities.eColor Color
        {
            get
            {
                return m_Color;
            }

            set
            {
                m_Color = value;
            }
        }

        public Utilities.eNumberOfDoors DoorsNumber
        {
            get
            {
                return m_NumberOfDoors;
            }

            set
            {
                m_NumberOfDoors = value;
            }
        }
    }
}
