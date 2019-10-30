using System;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class FuelBasedVehicle : Vehicle
    {
        private static float m_MaxFuelAmount;
        protected Utilities.eTypeOfFuel m_TypeOfFuel;
        private float m_CurFuelAmount;

        internal void AddingFuel(float i_NumberOfFuelLitersToAdd)
        {
            if ((m_CurFuelAmount + i_NumberOfFuelLitersToAdd) > m_MaxFuelAmount)
            {
                throw new ValueOutOfRangeException(0, m_MaxFuelAmount, "You can't add more fuel");
            }
            else
            {
                m_CurFuelAmount += i_NumberOfFuelLitersToAdd;
                m_PercentOfEnergyLeft = (m_CurFuelAmount / m_MaxFuelAmount) * 100;
            }
        }

        protected FuelBasedVehicle(string i_NumberOfModel, string i_NumberOfCarLicense, string i_NameOfManufacturer, float i_CurTirePressure, Utilities.eTypeOfFuel i_TypeOfFuel, float i_MaxFuelAmount) : base(i_NumberOfModel, i_NumberOfCarLicense, i_NameOfManufacturer, i_CurTirePressure)
        {
            m_TypeOfFuel = i_TypeOfFuel;
            m_MaxFuelAmount = i_MaxFuelAmount;
            m_CurFuelAmount = 0;
        }

        public static float CheckAndReturnFuel(string i_Input)
        {
            bool parsingCheck = false;
            float fuel = 0;

            parsingCheck = float.TryParse(i_Input, out fuel);

            if (!parsingCheck)
            {
                throw new FormatException("Error: not a number");
            }
            else if (fuel < 0 || fuel > m_MaxFuelAmount)
            {
                throw new ValueOutOfRangeException(0, m_MaxFuelAmount);
            }

            return fuel;
        }

        public override string ToString()
        {
            StringBuilder fuelBasedVehicleDetails = new StringBuilder();
            fuelBasedVehicleDetails.Append(Environment.NewLine);
            fuelBasedVehicleDetails.Append(base.ToString());
            fuelBasedVehicleDetails.Append(Environment.NewLine);
            fuelBasedVehicleDetails.AppendFormat(@"Fuel status: {0}% left
Fuel type: {1}",
m_PercentOfEnergyLeft,
m_TypeOfFuel.ToString());

            return fuelBasedVehicleDetails.ToString();
        }

        public float CurrentFuelAmount
        {
            get
            {
                return m_CurFuelAmount;
            }

            set
            {
                m_CurFuelAmount = value;
            }
        }
    }
}
