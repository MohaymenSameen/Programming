using System;

namespace Assignment3
{
    class Program
    {
        static void Main(string[] args)
        {
            Program myprogram = new Program();
            myprogram.Start();
        }
        void Start()
        {               
            Person[] persons = new Person[3];

            for (int i = 0; i < persons.Length; i++)
            {
                persons[i] = ReadPerson();
                Console.WriteLine();
            }

            for (int i = 0; i < persons.Length; i++)
            {
                PrintPerson(persons[i]);
                Console.WriteLine();
            }

            Console.ReadKey();
        }
        public Person ReadPerson()
        {            
            Person p = new Person();
            p.FirstName = ReadString("Enter your firstname: ");
            p.LastName = ReadString("Enter your lastname: ");
            p.Age = ReadInt("Enter your age: ");
            p.City = ReadString("Enter your city: ");
            p.gender = ReadGender("Please state your gender (m or f): ");
            return p;
        }
        void PrintPerson(Person p)
        {
            Console.WriteLine("{0}  {1}   ({2}) ",p.FirstName,p.LastName,p.gender);            
            Console.WriteLine("{0} years old, {1} ",p.Age,p.City);           
        }
        public GenderType ReadGender(string question)
        {
            Console.Write(question);
            string value = Console.ReadLine();
            GenderType gender= (GenderType) Enum.Parse(typeof(GenderType),value);
            return gender;
        }
        void PrintGender(GenderType gender)
        {
            Console.WriteLine(gender);
        }
        public int ReadInt(string question)
        {
            Console.Write(question);
            string value = Console.ReadLine();
            int value1 = int.Parse(value);
            return value1;
        }
        public string ReadString(string question)
        {
            Console.Write(question);
            string sentence = Console.ReadLine();
            return sentence;
        }

    }
}
