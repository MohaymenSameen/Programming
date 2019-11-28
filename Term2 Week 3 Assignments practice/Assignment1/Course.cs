using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment1
{
    class Course
    {
        public string Name;
        public int Grade;
        public PracticalGrade Practical;

        public bool Passed()
        {
            if (Grade>=55 && ((int)Practical==3 || (int)Practical==4))
            {
                return true;
            }
            return false;
        }
        public bool CumLaude()
        {
            if (Grade>=80 && (int)Practical==4)
            {
                return true;
            }
            return false;
        }
    }    
}
