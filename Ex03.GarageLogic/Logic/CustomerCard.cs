using Ex03.GarageLogic;

namespace Ex03.GarageManagementSystem.ConsolUI
{
    public class CustomerCard
    {
        private readonly string r_Owners;
        private readonly string r_Phone;
        private eStatus m_Status;
        private Vehicle m_Vehicle;

        public CustomerCard(string i_Owners, string i_Phone, Vehicle i_Vehicle)
        {
            r_Owners = i_Owners;
            r_Phone = i_Phone;
            m_Vehicle = i_Vehicle;
            m_Status = eStatus.Repairing;
        }

        public Vehicle Vehicle
        {
            get { return m_Vehicle; }
        }

        public eStatus Status
        {
            get { return m_Status; }
            set { m_Status = value; }
        }

        public string Owners
        {
            get { return r_Owners; }
        }

        public string Phone
        {
            get { return r_Phone; }
        }

        public override string ToString()
        {
            return string.Format(
@"{0}Owners: {1}
Phone: {2}
Status: {3}
", 
           Vehicle,
           Owners,
           Phone,
           Status);
        }

        public enum eStatus
        {
            Repairing = 0,
            Repaired = 1,
            Paid = 2
        }
    }
}
