using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        protected string m_ModelName;
        protected string m_NumberOfCarLicense;
        protected float m_PercentOfEnergyLeft;
        protected List<Tire> m_TireList;

        protected Vehicle(string i_ModelName, string i_NumberOfCarLicense, string i_NameOfManufacturer, float i_CurTirePressure)
        {
            m_ModelName = i_ModelName;
            m_NumberOfCarLicense = i_NumberOfCarLicense;
            m_PercentOfEnergyLeft = 100;
        }

        internal void InflateTiresToMaximum()
        {
            foreach (Tire curTire in m_TireList)
            {
                curTire.InflateTireToMaximum();
            }
        }

        public static float CheckValidationOfCurrentPressure(string i_Input, float i_MaxAirPressure, string i_ExceptionMessage)
        {
            float airPressure;
            bool parsingCheck = float.TryParse(i_Input, out airPressure);

            if (!parsingCheck)
            {
                throw new FormatException(i_ExceptionMessage);
            }
            else if (airPressure < 0 || airPressure > i_MaxAirPressure)
            {
                throw new ValueOutOfRangeException(0, i_MaxAirPressure);
            }

            return airPressure;
        }

        public override string ToString()
        {
            StringBuilder vehicleDetails = new StringBuilder();
            vehicleDetails.Append("List Of tires: ");
            vehicleDetails.Append(Environment.NewLine);
            int numberOfTire = 0;
            foreach (Tire curTire in m_TireList)
            {
                vehicleDetails.Append(curTire.ToString(numberOfTire));
                numberOfTire++;
                vehicleDetails.Append(Environment.NewLine);
            }

            return vehicleDetails.ToString();
        }

        public string Model
        {
            get
            {
                return m_ModelName;
            }
        }

        public string LicensePlate
        {
            get
            {
                return m_NumberOfCarLicense;
            }
        }
    }
}
