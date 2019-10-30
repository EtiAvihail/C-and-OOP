using System;

namespace Ex03.GarageLogic
{
    internal class VehicleCreator
    {
        public static Vehicle CreateVehicle(Utilities.eTypeOfVehicle i_VehicleType, string i_ModelName, string i_NumberOfCarLicense, string i_NameOfManufacturer, float i_CurTirePressure)
        {
            Vehicle createdVehicle = null;

            switch (i_VehicleType)
            {
                case Utilities.eTypeOfVehicle.ElectricCar:
                    {
                        createdVehicle = new ElectricCar(i_ModelName, i_NumberOfCarLicense, i_NameOfManufacturer, i_CurTirePressure);
                        break;
                    }

                case Utilities.eTypeOfVehicle.ElectricMotorcycle:
                    {
                        createdVehicle = new ElectricMotorcycle(i_ModelName, i_NumberOfCarLicense, i_NameOfManufacturer, i_CurTirePressure);
                        break;
                    }

                case Utilities.eTypeOfVehicle.FuelBasedCar:
                    {
                        createdVehicle = new FuelBasedCar(i_ModelName, i_NumberOfCarLicense, i_NameOfManufacturer, i_CurTirePressure);
                        break;
                    }

                case Utilities.eTypeOfVehicle.FuelBasedMotorcycle:
                    {
                        createdVehicle = new FuelBasedMotorcycle(i_ModelName, i_NumberOfCarLicense, i_NameOfManufacturer, i_CurTirePressure);
                        break;
                    }

                case Utilities.eTypeOfVehicle.FuelBasedTruck:
                    {
                        createdVehicle = new FuelBasedTruck(i_ModelName, i_NumberOfCarLicense, i_NameOfManufacturer, i_CurTirePressure);
                        break;
                    }

                default:
                    {
                        throw new ArgumentException("Please enter a valid vehicle");
                    }
            }

            return createdVehicle;
        }
    }
}
