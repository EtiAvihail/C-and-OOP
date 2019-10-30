namespace Ex03.GarageLogic
{
    public class Customer
    {
        private string m_NameOfVehicleOwner;
        private string m_PhoneNumber;
        private Vehicle m_Vehicle;
        private Utilities.eStatusOfVehicle m_VehicleStatus;

        public Customer(Vehicle i_Vehicle, string i_name, string i_PhoneNumber)
        {
            m_NameOfVehicleOwner = i_name;
            m_PhoneNumber = i_PhoneNumber;
            m_Vehicle = i_Vehicle;
            m_VehicleStatus = Utilities.eStatusOfVehicle.Repair;
        }

        public string PhoneNumber
        {
            get
            {
                return m_PhoneNumber;
            }
        }

        public string Name
        {
            get
            {
                return m_NameOfVehicleOwner;
            }
        }

        public Vehicle Vehicle
        {
            get
            {
                return m_Vehicle;
            }
        }

        public Utilities.eStatusOfVehicle Status
        {
            get
            {
                return m_VehicleStatus;
            }

            set
            {
                m_VehicleStatus = value;
            }
        }

        public override string ToString()
        {
            System.Text.StringBuilder details = new System.Text.StringBuilder();
            details.AppendFormat(@"Customer name: {0}
Phone number: {1}
License plate number: {2}
Model Name: {3}
Status of vehicle: {4}",
m_NameOfVehicleOwner,
m_PhoneNumber,
m_Vehicle.LicensePlate,
m_Vehicle.Model,
m_VehicleStatus.ToString());
            details.Append(System.Environment.NewLine);
            details.Append(m_Vehicle.ToString());

            return details.ToString();
        }
    }
}
