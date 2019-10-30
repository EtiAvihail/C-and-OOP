using System.Collections.Generic;
using System;
using System.Text;

namespace Ex03.GarageLogic
{
    public static class Utilities
    {
        public enum eTypeOfVehicle
        {
            ElectricCar = 1,
            ElectricMotorcycle,
            FuelBasedCar,
            FuelBasedMotorcycle,
            FuelBasedTruck
        }

        public enum eTypeOfLicense
        {
            A = 1,
            A1,
            B1,
            B2
        }

        public enum eColor
        {
            Gray = 1,
            Blue,
            White,
            Black
        }

        public enum eTypeOfFuel
        {
            Soler = 1,
            Octan95,
            Octan96,
            Octan98
        }

        public enum eNumberOfDoors
        {
            Two = 1,
            Three,
            Four,
            Five
        }

        public enum eStatusOfVehicle
        {
            Repair = 1,
            Fixed,
            Paid,
            All
        }

        public enum eOptionalOperations
        {
            InsertNewVehicle = 1,
            DisplayListOfLicenseNumbers,
            ChangeVehicleStatus,
            InflateTiresToMaximum,
            RefuelAFuelBasedVehicle,
            ChargeanElectricBasedVehicle,
            DisplayVehicleInformation
        }

        public static List<Tire> LoadTireData(string i_NameOfManufacturer, int i_NumberOfTires, float i_CurTirePressure, float i_MaxAirPressure)
        {
            if (i_CurTirePressure > i_MaxAirPressure || i_CurTirePressure < 0)
            {
                throw new ValueOutOfRangeException(0, i_MaxAirPressure, "Initial Pressure is invalid");
            }

            List<Tire> TireList = new List<Tire>(i_NumberOfTires);
            for (int i = 0; i < i_NumberOfTires; i++)
            {
                TireList.Add(new Tire(i_NameOfManufacturer, i_CurTirePressure, (int)i_MaxAirPressure));
            }

            return TireList;
        }

        public static T AskForSpecificVehicleDetailes<T>(T i_TypeOfEnum, string i_Question)
        {
            T answer;
            StringBuilder options = new StringBuilder(string.Format("{0}{1}", i_Question, Environment.NewLine));
            int optionNumber = 1;

            foreach (T enumAnswer in Enum.GetValues(typeof(T)))
            {
                options.AppendFormat("{0}. {1}{2}", optionNumber, enumAnswer.ToString(), Environment.NewLine);
                optionNumber++;
            }

            Console.Clear();
            Console.Write(options);

            int answerInt;

            string answerStr = Console.ReadLine();

            if (!int.TryParse(answerStr, out answerInt))
            {
                throw new FormatException("Error: wrong Format");
            }
            else if (Enum.IsDefined(typeof(T), answerInt))
            {
                answer = (T)(object)answerInt;
            }
            else
            {
                throw new ValueOutOfRangeException(1, Enum.GetValues(typeof(T)).Length);
            }

            return answer;
        }

        public static float GetCurrentAirPressure(eTypeOfVehicle i_Type, string i_Input)
        {
            float airPressure = 0;
            switch (i_Type)
            {
                case eTypeOfVehicle.ElectricCar:
                    airPressure = Vehicle.CheckValidationOfCurrentPressure(i_Input, (float)32, "wrong pressure");
                    break;
                case eTypeOfVehicle.ElectricMotorcycle:
                    airPressure = Vehicle.CheckValidationOfCurrentPressure(i_Input, (float)30, "wrong pressure");
                    break;
                case eTypeOfVehicle.FuelBasedCar:
                    airPressure = Vehicle.CheckValidationOfCurrentPressure(i_Input, (float)32, "wrong pressure");
                    break;
                case eTypeOfVehicle.FuelBasedMotorcycle:
                    airPressure = Vehicle.CheckValidationOfCurrentPressure(i_Input, (float)30, "wrong pressure");
                    break;
                default:
                    airPressure = Vehicle.CheckValidationOfCurrentPressure(i_Input, (float)28, "wrong pressure");
                    break;
            }

            return airPressure;
        }

        public static void GetSpecificVehicleInformtion(Vehicle i_Vehicle)
        {
            if (i_Vehicle is ElectricCar)
            {
                (i_Vehicle as ElectricCar).Color = Utilities.AskForSpecificVehicleDetailes(Utilities.eColor.Black, "what is the color of the vehicle?(type option number)");
                Console.Clear();
                (i_Vehicle as ElectricCar).DoorsNumber = Utilities.AskForSpecificVehicleDetailes(Utilities.eNumberOfDoors.Five, "How many doors? (type option number)");
                Console.Clear();
                Console.WriteLine("What is the current battery time?");
                string energy = Console.ReadLine();
                (i_Vehicle as ElectricCar).CurrentEnergyTime = ElectricBasedVehicle.CheckAndReturnEnergyTime(energy);
            }
            else if (i_Vehicle is FuelBasedCar)
            {
                (i_Vehicle as FuelBasedCar).Color = Utilities.AskForSpecificVehicleDetailes(Utilities.eColor.Black, "what is the color of the vehicle?");
                Console.Clear();
                (i_Vehicle as FuelBasedCar).DoorsNumber = Utilities.AskForSpecificVehicleDetailes(Utilities.eNumberOfDoors.Five, "How many doors? (type option number)");
                Console.Clear();
                Console.WriteLine("What is the current fuel amount?");
                string fuel = Console.ReadLine();
                (i_Vehicle as FuelBasedCar).CurrentFuelAmount = FuelBasedVehicle.CheckAndReturnFuel(fuel);
            }
            else if (i_Vehicle is ElectricMotorcycle)
            {
                (i_Vehicle as ElectricMotorcycle).LicenseType = Utilities.AskForSpecificVehicleDetailes(Utilities.eTypeOfLicense.A, "what is the license type?(type option number)");
                Console.Clear();
                Console.WriteLine("what is the engine max capacity?(type a number)");
                string capacity = Console.ReadLine();
                Console.Clear();
                (i_Vehicle as ElectricMotorcycle).EngineCapacity = ElectricMotorcycle.CheckAndReturnEngineCapacity(capacity);
                Console.Clear();
                Console.WriteLine("What is the current battery time?");
                string energy = Console.ReadLine();
                (i_Vehicle as ElectricMotorcycle).CurrentEnergyTime = ElectricBasedVehicle.CheckAndReturnEnergyTime(energy);
            }
            else if (i_Vehicle is FuelBasedMotorcycle)
            {
                (i_Vehicle as FuelBasedMotorcycle).LicenseType = Utilities.AskForSpecificVehicleDetailes(Utilities.eTypeOfLicense.A, "what is the license type?(type option number)");
                Console.Clear();
                Console.WriteLine("what is the engine max capacity?(type a number)");
                string capacity = Console.ReadLine();
                (i_Vehicle as FuelBasedMotorcycle).EngineCapacity = FuelBasedMotorcycle.CheckAndReturnEngineCapacity(capacity);
                Console.Clear();
                Console.WriteLine("What is the current fuel amount?");
                string fuel = Console.ReadLine();
                (i_Vehicle as FuelBasedMotorcycle).CurrentFuelAmount = FuelBasedVehicle.CheckAndReturnFuel(fuel);
            }
            else if (i_Vehicle is FuelBasedTruck)
            {
                Console.WriteLine("Is it carrying dangerous materials? type \"yes\" or \"no\"");
                string carrying = Console.ReadLine();

                while (carrying != "yes" && carrying != "no")
                {
                    Console.WriteLine("Wrong format, type \"yes\" or \"no\"");
                    carrying = Console.ReadLine();
                }

                (i_Vehicle as FuelBasedTruck).IsCarryingDangerousMaterials = carrying == "yes";
                Console.Clear();
                Console.WriteLine("what is it's maximum carrying weight (in kg)?");
                string maxWeight = Console.ReadLine();
                (i_Vehicle as FuelBasedTruck).MaximumCarryingWeight = FuelBasedTruck.CheckAndReturnMaximumCarryingWeight(maxWeight);
                Console.Clear();
                Console.WriteLine("What is the current fuel amount?");
                string fuel = Console.ReadLine();
                (i_Vehicle as FuelBasedTruck).CurrentFuelAmount = FuelBasedVehicle.CheckAndReturnFuel(fuel);
            }
        }
    }
}