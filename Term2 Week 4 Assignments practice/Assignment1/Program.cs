using System;
using System.IO;

namespace Assignment1
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
            Console.Write("Enter your name: ");
            string person = Console.ReadLine();

            if (File.Exists("" + person + ".txt"))
            {
                Console.WriteLine("Nice to meet you again "+person+"!");
                Console.WriteLine("We have the following information about you " + person + "!");
                ReadPerson(""+person + ".txt");
            }
            else
            {
                Console.WriteLine("Welcome "+person+"");
                WritePerson(ReadPerson(), "" + person + ".txt");
                Console.WriteLine("Your data is written to file. ");
            }
            Console.ReadKey();
        }
        public Person ReadPerson()
        {
            Person p = new Person();            
            p.Name = ReadString("Enter your Name: ");
            p.City = ReadString("Enter your City: ");
            p.Age = ReadInt("Enter your age: ");
            return p;
        }
        /*void DisplayPerson(Person p)
        {
            Console.WriteLine(string.Format("Name: {0,2}", p.Name));
            Console.WriteLine(string.Format("City: {0,2}", p.City));
            Console.WriteLine(string.Format("Age: {0,2}", p.Age));
        }*/
        void WritePerson(Person p, string filename)
        {
            StreamWriter writer = new StreamWriter(filename);           

            writer.WriteLine(p.Name);
            writer.WriteLine(p.City);
            writer.WriteLine(p.Age);

            writer.Close();             
        }
        public Person ReadPerson(string filename)
        {            
            StreamReader reader = new StreamReader(filename);
            Person p = new Person();

            while (!reader.EndOfStream)
            {
                p.Name = reader.ReadLine();                
                p.City = reader.ReadLine();
                p.Age = int.Parse(reader.ReadLine());

                Console.WriteLine(string.Format("Name: {0,2}", p.Name));
                Console.WriteLine(string.Format("City: {0,2}", p.City));
                Console.WriteLine(string.Format("Age: {0,2}", p.Age));
            }
            reader.Close();

            return p;
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
