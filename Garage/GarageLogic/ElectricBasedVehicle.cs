using System.Text;
using System;

namespace Ex03.GarageLogic
{
    public abstract class ElectricBasedVehicle : Vehicle
    {
        private static float m_MaxBatteryTime;
        private float m_CurBatteryTime;

        internal void BatteryCharging(float i_NumberOfHoursToAdd)
        {
            if ((m_CurBatteryTime + i_NumberOfHoursToAdd) > m_MaxBatteryTime)
            {
                throw new ValueOutOfRangeException(0, m_MaxBatteryTime, "You can't add more time");
            }
            else
            {
                m_CurBatteryTime += i_NumberOfHoursToAdd;
                m_PercentOfEnergyLeft = (m_CurBatteryTime / m_MaxBatteryTime) * 100;
            }
        }

        protected ElectricBasedVehicle(string i_ModelName, string i_NumberOfCarLicense, string i_NameOfManufacturer, float i_CurTirePressure, float i_MaxBatteryTime) : base(i_ModelName, i_NumberOfCarLicense, i_NameOfManufacturer, i_CurTirePressure)
        {
            m_MaxBatteryTime = i_MaxBatteryTime;
            m_CurBatteryTime = 0;
        }

        public override string ToString()
        {
            StringBuilder electricityBasedVehicleDetails = new StringBuilder();
            electricityBasedVehicleDetails.Append(Environment.NewLine);
            electricityBasedVehicleDetails.Append(base.ToString());
            electricityBasedVehicleDetails.Append(Environment.NewLine);
            electricityBasedVehicleDetails.AppendFormat("Battery Status: {0}% left", m_PercentOfEnergyLeft);

            return electricityBasedVehicleDetails.ToString();
        }

        public static float CheckAndReturnEnergyTime(string i_Input)
        {
            bool parsingCheck = false;
            float energy = 0;

            parsingCheck = float.TryParse(i_Input, out energy);

            if (!parsingCheck)
            {
                throw new FormatException("Error: not a number");
            }
            else if (energy < 0 || energy > m_MaxBatteryTime)
            {
                throw new ValueOutOfRangeException(0, m_MaxBatteryTime);
            }

            return energy;
        }

        public float CurrentEnergyTime
        {
            get
            {
                return m_CurBatteryTime;
            }

            set
            {
                m_CurBatteryTime = value;
            }
        }
    }
}
