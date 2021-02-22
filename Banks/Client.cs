using System;
using System.Collections.Generic;
using System.Text;

namespace Banks
{
    class Client
    {
        public string Name, Surname, Address;
        public int PassportNumber;
        public List<Account> AccountsList = new List<Account>();
        public string PropertyName
        {
            set
            {
                if (value != null)
                    Name = value;
                else
                    throw new Exception("No Name!");
            }
            get { return Name; }
        }
        public string PropertySurname
        {
            set
            {
                if (value != null)
                    Surname = value;
                else
                    throw new Exception("No Surname!");
            }
            get { return Surname; }
        }
        public string PropertyAddress
        {
            set
            {
                if (value != null)
                    Address = value;
                else
                    throw new Exception("Not correct Address!");
            }
            get { return Address; }

        }
        public int PropertyPassportNumber
        {
            set
            {
                if (value != 0)
                    PassportNumber = value;
                else
                    throw new Exception("Not correct PassportNumber!");
            }
            get { return PassportNumber; }
        }
        public enum ClientState
        {
            complete,
            empty,
            questionable
        }
        public ClientState state = ClientState.empty;
        public Client() { }

        public void CheckState(Client ans)
        {
            if (ans.PassportNumber != 0 && ans.Address != null)
                ans.state = ClientState.complete;
            else
                ans.state = ClientState.questionable;
        }
    }
}
