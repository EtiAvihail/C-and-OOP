using System;
using System.Text;

namespace Ex03.GarageLogic
{
    public class FuelBasedCar : FuelBasedVehicle
    {
        private const float k_MaxAirPressure = 32;
        private const int k_NumberOfTires = 4;
        private const Utilities.eTypeOfFuel k_TypeOfFuel = Utilities.eTypeOfFuel.Octan98;
        private Utilities.eNumberOfDoors m_NumberOfDoors;
        private Utilities.eColor m_Color;

        public FuelBasedCar(string i_NumberOfModel, string i_NumberOfCarLicense, string i_NameOfManufacturer, float i_CurTirePressure)
            : base(i_NumberOfModel, i_NumberOfCarLicense, i_NameOfManufacturer, i_CurTirePressure, Utilities.eTypeOfFuel.Octan98, 45)
        {
            m_TireList = Utilities.LoadTireData(i_NameOfManufacturer, k_NumberOfTires, i_CurTirePressure, k_MaxAirPressure);
        }

        public override string ToString()
        {
            StringBuilder fuelBasedCarDetails = new StringBuilder();
            fuelBasedCarDetails.Append(base.ToString());
            fuelBasedCarDetails.AppendFormat(@"
Number of doors: {0}
Car color: {1} ",
m_NumberOfDoors.ToString(),
m_Color.ToString());
            fuelBasedCarDetails.Append(Environment.NewLine);

            return fuelBasedCarDetails.ToString();
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
