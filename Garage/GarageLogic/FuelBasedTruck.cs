using System;
using System.Text;

namespace Ex03.GarageLogic
{
    public class FuelBasedTruck : FuelBasedVehicle
    {
        private const float k_MaxAirPressure = 28;
        private const int k_NumberOfTires = 12;
        private const Utilities.eTypeOfFuel k_TypeOfFuel = Utilities.eTypeOfFuel.Octan96;
        private bool m_isCarryingDangerousMaterials;
        private float m_MaximumCarryingWeight;

        public FuelBasedTruck(string i_NumberOfModel, string i_NumberOfCarLicense, string i_NameOfManufacturer, float i_CurTirePressure)
    : base(i_NumberOfModel, i_NumberOfCarLicense, i_NameOfManufacturer, i_CurTirePressure, Utilities.eTypeOfFuel.Octan96, 115)
        {
            m_TireList = Utilities.LoadTireData(i_NameOfManufacturer, k_NumberOfTires, i_CurTirePressure, k_MaxAirPressure);
        }

        public static float CheckAndReturnMaximumCarryingWeight(string i_Input)
        {
            bool parsingCheck = false;
            float weight = 0;

            parsingCheck = float.TryParse(i_Input, out weight);

            if (!parsingCheck)
            {
                throw new FormatException("Error: not a number");
            }

            return weight;
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.Append(base.ToString());
            output.AppendFormat(@"
Carry dangerous materials : {0}
Max weight: {1} ",
m_isCarryingDangerousMaterials,
m_MaximumCarryingWeight);
            output.Append(Environment.NewLine);

            return output.ToString();
        }

        public bool IsCarryingDangerousMaterials
        {
            get
            {
                return m_isCarryingDangerousMaterials;
            }

            set
            {
                m_isCarryingDangerousMaterials = value;
            }
        }

        public float MaximumCarryingWeight
        {
            get
            {
                return m_MaximumCarryingWeight;
            }

            set
            {
                m_MaximumCarryingWeight = value;
            }
        }
    }
}
