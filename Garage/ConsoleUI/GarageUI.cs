using System;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class GarageUI
    {
        private const string k_ExceptionInvalidEmptyOrNullInput = "Error: Empty vehicle number";
        private const string k_ExceptionNumberOutOfRange = "Error: Answer out of range";
        private const string k_ExceptionWrongFormat = "Error: Wrong format";
        private const string k_ExceptionVehicleDoesNotExist = "Error: Vehicle does not exist";
        private const string k_BackToMenueMessage = "Press Enter to get back to menu";
        private Garage m_Garage = new Garage();

        public void StartGarage()
        {
            do
            {
                getAndExecutetUsersRequest();
            }
            while (true);
        }

        private void getAndExecutetUsersRequest()
        {
            Console.Clear();

            string optionalOperationsMessage = string.Format(@"What would you like to do(enter the option number):
1. Insert a new vehicle into the garage
2. Display a list of license numbers currently in the garage
3. Change a certain vehicle’s status
4. Inflate tires to maximum
5. Refuel a fuel-based vehicle
6. Charge an electric-based vehicle
7. Display vehicle information");
            Console.WriteLine(optionalOperationsMessage);
            string userChoice;
            int choiceNumber;
            bool loop = true;

            do
            {
                try
                {
                    userChoice = Console.ReadLine();

                    if (!int.TryParse(userChoice, out choiceNumber))
                    {
                        throw new FormatException();
                    }

                    switch (choiceNumber)
                    {
                        case (int)Utilities.eOptionalOperations.InsertNewVehicle:
                            insertNewVehicle();
                            loop = false;
                            break;
                        case (int)Utilities.eOptionalOperations.DisplayListOfLicenseNumbers:
                            showExistingLicenseList();
                            loop = false;
                            break;
                        case (int)Utilities.eOptionalOperations.ChangeVehicleStatus:
                            changeStatusOfVehicle();
                            loop = false;
                            break;
                        case (int)Utilities.eOptionalOperations.InflateTiresToMaximum:
                            inflateTiresToMaximum();
                            loop = false;
                            break;
                        case (int)Utilities.eOptionalOperations.RefuelAFuelBasedVehicle:
                            refuelvehicle();
                            loop = false;
                            break;
                        case (int)Utilities.eOptionalOperations.ChargeanElectricBasedVehicle:
                            chargeAnElectricBasedVehicle();
                            loop = false;
                            break;
                        case (int)Utilities.eOptionalOperations.DisplayVehicleInformation:
                            displayVehicleInformation();
                            loop = false;
                            break;
                        default:
                            throw new ValueOutOfRangeException(1, Enum.GetNames(typeof(Utilities.eOptionalOperations)).Length, k_ExceptionNumberOutOfRange);
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine(k_ExceptionWrongFormat);
                    continue;
                }
                catch (ValueOutOfRangeException)
                {
                    Console.WriteLine(k_ExceptionNumberOutOfRange);
                    continue;
                }
            }
            while (loop);
        }

        private void insertNewVehicle()
        {
            string licensePlate = getLicensePlateNumber();
            bool vehicleExist = m_Garage.DoesVehicleExist(licensePlate);
            Utilities.eTypeOfVehicle vehicleType = Utilities.eTypeOfVehicle.ElectricCar;
            bool loop = true;

            if (!vehicleExist)
            {
                Console.Clear();
                do
                {
                    try
                    {
                        vehicleType = Utilities.AskForSpecificVehicleDetailes(Utilities.eTypeOfVehicle.ElectricCar, "What is the type of vecihle?(type option number)");
                        loop = false;
                    }
                    catch (ValueOutOfRangeException exception)
                    {
                        Console.WriteLine(exception.Message);
                        continue;
                    }
                }
                while (loop);

                Console.Clear();
                Console.WriteLine("Enter owner name:");
                string name = Console.ReadLine();
                Console.Clear();
                Console.WriteLine("Enter owner phone number:");
                string PhoneNumber = Console.ReadLine();
                Console.Clear();
                Console.WriteLine("Enter vehicle model:");
                string model = Console.ReadLine();
                Console.Clear();
                Console.WriteLine("Enter tire company name:");
                string tireCompany = Console.ReadLine();
                Console.Clear();
                float currentTirePressure = getCurrentTirePressure(vehicleType);
                Console.Clear();
                m_Garage.InsertNewCustomer(licensePlate, vehicleType, model, tireCompany, currentTirePressure, name, PhoneNumber);
                getSpecificVehicleInformtion(m_Garage.GetVehicle(licensePlate));
                Console.Clear();
                Console.WriteLine("The vehicle was entered successfully");
                Console.WriteLine(k_BackToMenueMessage);
                Console.ReadLine();
            }
            else
            {
                Console.Clear();
                m_Garage.ChangeStatus(Utilities.eStatusOfVehicle.Repair, licensePlate);
                Console.WriteLine("The vehicle already exist in the garage, status was changed to in-repaire");
                Console.WriteLine(k_BackToMenueMessage);
                Console.ReadLine();
            }
        }

        private void showExistingLicenseList()
        {
            Utilities.eStatusOfVehicle status;
            string vehiclesList;
            if (m_Garage.Customers.Count == 0)
            {
                Console.Clear();
                Console.WriteLine("No vehicles in the garage");
            }
            else
            {
                status = Utilities.AskForSpecificVehicleDetailes(Utilities.eStatusOfVehicle.All, "Choose staus:(type option number)");
                vehiclesList = m_Garage.GetCarsLicenseList(status);
                Console.Clear();
                Console.WriteLine(string.Format("Vehicles List in status {0}:", status.ToString()));
                Console.WriteLine(vehiclesList);
            }

            Console.WriteLine(k_BackToMenueMessage);
            Console.ReadLine();
        }

        private void changeStatusOfVehicle()
        {
            string licensePlate;
            Utilities.eStatusOfVehicle status;
            licensePlate = checkIfVehicleExists();

            while (!m_Garage.DoesVehicleExist(licensePlate))
            {
                Console.WriteLine(k_ExceptionVehicleDoesNotExist);
                licensePlate = getLicensePlateNumber();
            }

            Console.Clear();
            status = Utilities.AskForSpecificVehicleDetailes(Utilities.eStatusOfVehicle.All, "Choose staus:(type option number)");

            Console.Clear();
            m_Garage.ChangeStatus(status, licensePlate);
            Console.Clear();
            Console.WriteLine("Status was changed successfully");
            Console.WriteLine(k_BackToMenueMessage);
            Console.ReadLine();
        }

        private void inflateTiresToMaximum()
        {
            string licensePlate;
            licensePlate = getLicensePlateNumber();

            while (!m_Garage.DoesVehicleExist(licensePlate))
            {
                Console.WriteLine(k_ExceptionVehicleDoesNotExist);
                licensePlate = getLicensePlateNumber();
            }

            m_Garage.InflateTiresToMaximum(licensePlate);
            Console.Clear();
            Console.WriteLine("Tires were inflated successfully");
            Console.WriteLine(k_BackToMenueMessage);
            Console.ReadLine();
        }

        private void refuelvehicle()
        {
            string licensePlate = checkIfVehicleExists();
            float energyToAdd = getAmountOfEnergy();

            while (!m_Garage.DoesVehicleExist(licensePlate))
            {
                Console.WriteLine(k_ExceptionVehicleDoesNotExist);
                licensePlate = getLicensePlateNumber();
            }

            try
            {
                m_Garage.RefuelVehicle(licensePlate, energyToAdd);
                Console.Clear();
                Console.WriteLine("Vehicle wes refuled successfully");
                Console.WriteLine(k_BackToMenueMessage);
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }

        private float getAmountOfEnergy()
        {
            string energyToAddStr;
            float energyToAddInt;

            Console.Clear();
            Console.WriteLine("How much energy do you want to add to the vehicle?(in hours for electric vehicle, liters for fuel)");
            energyToAddStr = Console.ReadLine();

            if (!float.TryParse(energyToAddStr, out energyToAddInt))
            {
                throw new FormatException(k_ExceptionWrongFormat);
            }

            return energyToAddInt;
        }

        private void chargeAnElectricBasedVehicle()
        {
            string licensePlate = checkIfVehicleExists();
            float energyToAdd = getAmountOfEnergy();
            try
            {
                m_Garage.ChargeVehicle(licensePlate, energyToAdd);
                Console.Clear();
                Console.WriteLine("Vehicle wes charged successfully");
                Console.WriteLine(k_BackToMenueMessage);
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }

        private void displayVehicleInformation()
        {
            string licensePlate = checkIfVehicleExists();

            while (!m_Garage.DoesVehicleExist(licensePlate))
            {
                Console.WriteLine(k_ExceptionVehicleDoesNotExist);
                licensePlate = getLicensePlateNumber();
            }

            Console.WriteLine(m_Garage.GetAllVehicleInformation(licensePlate));
            Console.WriteLine(k_BackToMenueMessage);
            Console.ReadLine();
        }

        private void checkString(string i_UserInput)
        {
            if (string.IsNullOrEmpty(i_UserInput))
            {
                throw new ArgumentNullException(k_ExceptionInvalidEmptyOrNullInput);
            }
        }

        private string getLicensePlateNumber()
        {
            string licensePlateNumber = string.Empty;
            bool loop = true;
            Console.Clear();
            Console.WriteLine("Enter the vehicle license Plate Number");

            do
            {
                try
                {
                    licensePlateNumber = Console.ReadLine().Trim();
                    checkString(licensePlateNumber);
                    loop = false;
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine(k_ExceptionInvalidEmptyOrNullInput);
                    Console.WriteLine("please type again:");
                    continue;
                }
            }
            while (loop);

            return licensePlateNumber;
        }

        private void getSpecificVehicleInformtion(Vehicle i_Vehicle)
        {
            bool loop = true;
            do
            {
                try
                {
                    Utilities.GetSpecificVehicleInformtion(i_Vehicle);
                    loop = false;
                }
                catch (ValueOutOfRangeException)
                {
                    Console.WriteLine(k_ExceptionNumberOutOfRange);
                    Console.ReadLine();
                    continue;
                }
                catch (FormatException)
                {
                    Console.WriteLine(k_ExceptionWrongFormat);
                    Console.ReadLine();
                    continue;
                }
            }
            while (loop);
        }

        private string checkIfVehicleExists()
        {
            string licensePlate = getLicensePlateNumber();

            while (!m_Garage.DoesVehicleExist(licensePlate))
            {
                Console.WriteLine(k_ExceptionVehicleDoesNotExist);
                Console.ReadLine();
                licensePlate = getLicensePlateNumber();
            }

            return licensePlate;
        }

        private float getCurrentTirePressure(Utilities.eTypeOfVehicle i_Type)
        {
            float airPressure = 0;
            bool loop = true;
            Console.Clear();
            Console.WriteLine("What is the current tire pressure?");
            string input = Console.ReadLine();

            do
            {
                try
                {
                    airPressure = Utilities.GetCurrentAirPressure(i_Type, input);
                    loop = false;
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                    continue;
                }
            }
            while (loop);

            return airPressure;
        }
    }
}
