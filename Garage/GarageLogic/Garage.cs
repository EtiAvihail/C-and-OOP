using System.Collections.Generic;
using System.Text;
using System;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private readonly List<Customer> m_CustomerList = new List<Customer>();

        public bool DoesVehicleExist(string i_NumberOfCarLicense)
        {
            bool isExists = false;
            foreach (Customer curCustomer in m_CustomerList)
            {
                if (curCustomer.Vehicle.LicensePlate == i_NumberOfCarLicense)
                {
                    isExists = true;
                }
            }

            return isExists;
        }

        public void InsertNewCustomer(string i_NumberOfCarLicense, Utilities.eTypeOfVehicle i_VehicleType, string i_ModelName, string i_NameOfManufacturer, float i_CurTirePressure, string i_NameOfVehicleOwner, string i_PhoneNumber)
        {
            Vehicle createdVehicle = VehicleCreator.CreateVehicle(i_VehicleType, i_ModelName, i_NumberOfCarLicense, i_NameOfManufacturer, i_CurTirePressure);
            Customer createdCustomer = new Customer(createdVehicle, i_NameOfVehicleOwner, i_PhoneNumber);
            m_CustomerList.Add(createdCustomer);
        }

        public string GetCarsLicenseList(Utilities.eStatusOfVehicle i_StatusOfVehicle)
        {
            StringBuilder carLicenseString = new StringBuilder();
            foreach (Customer curCustomer in m_CustomerList)
            {
                if (curCustomer.Status == i_StatusOfVehicle || i_StatusOfVehicle == Utilities.eStatusOfVehicle.All)
                {
                    carLicenseString.Append(curCustomer.Vehicle.LicensePlate);
                    carLicenseString.Append(Environment.NewLine);
                }
            }

            if (carLicenseString.Length > 0)
            {
                carLicenseString.Remove(carLicenseString.Length - 1, 1);
                return carLicenseString.ToString();
            }
            else
            {
                return string.Format("There are no cars in status \"{0}\"", i_StatusOfVehicle);
            }
        }

        public void ChangeStatus(Utilities.eStatusOfVehicle i_StatusOfVehicle, string i_NumberOfCarLicense)
        {
            foreach (Customer curCustomer in m_CustomerList)
            {
                if (curCustomer.Vehicle.LicensePlate == i_NumberOfCarLicense)
                {
                    curCustomer.Status = i_StatusOfVehicle;
                }
            }
        }

        public void InflateTiresToMaximum(string i_NumberOfCarLicense)
        {
            foreach (Customer curCustomer in m_CustomerList)
            {
                if (curCustomer.Vehicle.LicensePlate == i_NumberOfCarLicense)
                {
                    curCustomer.Vehicle.InflateTiresToMaximum();
                }
            }
        }

        public void RefuelVehicle(string i_NumberOfCarLicense, float i_AmountOfFuelToAdd)
        {
            foreach (Customer curCustomer in m_CustomerList)
            {
                if (curCustomer.Vehicle.LicensePlate == i_NumberOfCarLicense)
                {
                    if (!(curCustomer.Vehicle is FuelBasedVehicle))
                    {
                        throw new Exception("Vehicle is not based on fuel");
                    }
                    else
                    {
                        (curCustomer.Vehicle as FuelBasedVehicle).AddingFuel(i_AmountOfFuelToAdd);
                    }
                }
            }
        }

        public void ChargeVehicle(string i_NumberOfCarLicense, float i_MinutesToCharge)
        {
            foreach (Customer curCustomer in m_CustomerList)
            {
                if (curCustomer.Vehicle.LicensePlate == i_NumberOfCarLicense)
                {
                    if (!(curCustomer.Vehicle is ElectricBasedVehicle))
                    {
                        throw new Exception("Vehicle is not charchable");
                    }
                    else
                    {
                        (curCustomer.Vehicle as ElectricBasedVehicle).BatteryCharging(i_MinutesToCharge);
                    }
                }
            }
        }

        public string GetAllVehicleInformation(string i_LicensePlate)
        {
            string information = string.Empty;

            foreach (Customer curCustomer in m_CustomerList)
            {
                if (curCustomer.Vehicle.LicensePlate == i_LicensePlate)
                {
                    information = curCustomer.ToString();
                }
            }

            return information;
        }

        public Vehicle GetVehicle(string i_LicensePlate)
        {
            Vehicle vehicle = null;

            foreach (Customer curCustomer in m_CustomerList)
            {
                if (curCustomer.Vehicle.LicensePlate == i_LicensePlate)
                {
                    vehicle = curCustomer.Vehicle;
                }
            }

            return vehicle;
        }

        public List<Customer> Customers
        {
            get
            {
                return m_CustomerList;
            }
        }
    }
}
