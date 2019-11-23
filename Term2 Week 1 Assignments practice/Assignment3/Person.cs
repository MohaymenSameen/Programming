using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment3
{
    struct Person
    {
        public string FirstName;
        public string LastName;
        public int Age;
        public string City;
        public GenderType gender;
    }
    enum GenderType
    {
        m,f
    }
}
