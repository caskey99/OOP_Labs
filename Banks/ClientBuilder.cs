using System;
using System.Collections.Generic;
using System.Text;

namespace Banks
{
    class ClientBuilder : IClient
    {
        private Client client = new Client();

        public void Reset()
        {
            client = new Client();
        }
        public ClientBuilder()
        {
            Reset();
        }
        public void EnterName(string name)
        {
            client.PropertyName = name;
        }
        public void EnterSurname(string surname)
        {
            client.PropertyName = surname;
        }
        public void EnterAddress(string address)
        {
            client.PropertyAddress = address;
        }
        public void EnterPassportNumber(int passportNumber)
        {
            client.PropertyPassportNumber = passportNumber;
        }
        public Client GetClient()
        {
            Client res = client;
            res.CheckState(res);
            Reset();
            return res;
        }
    }
}
