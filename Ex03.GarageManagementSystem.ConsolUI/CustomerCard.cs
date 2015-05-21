using Ex03.GarageLogic;

namespace Ex03.GarageManagementSystem.ConsolUI
{
    using System;

    public class CustomerCard
    {
        private readonly string r_Owners;
        private readonly string r_Phone;
        private Program.eState m_State;
        private Vehicle m_Vehicle;

        public CustomerCard(string i_Owners, string i_Phone, Vehicle i_Vehicle)
        {
            r_Owners = i_Owners;
            r_Phone = i_Phone;
            m_Vehicle = i_Vehicle;
            m_State = Program.eState.Repairing;
        }

        public Vehicle Vehicle
        {
            get { return m_Vehicle; }
        }

        public Program.eState State
        {
            get { return m_State; }
            set { m_State = value; }
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
            return String.Format(
@"{0}Owners: {1}
Phone: {2}
State: {3}
", 
           Vehicle,
           Owners,
           Phone,
           State);
        }
    }
}
