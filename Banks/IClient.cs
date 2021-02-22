using System;
using System.Collections.Generic;
using System.Text;

namespace Banks
{
    interface IClient
    {
        void EnterName(string name);
        void EnterSurname(string surname);
        void EnterAddress(string address);
        void EnterPassportNumber(int passportNumber);
    }
}
