using System;

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
            int value = ReadInt("Enter a number: ");
            Console.WriteLine("You entered the number {0}", value);

            int age = ReadInt("Enter your age: ",0,120);
            Console.WriteLine("The age you entered is {0}", age);

            string name = ReadString("Enter your name: ");
            Console.WriteLine("Nice meeting you {0}", name);
            
            Console.ReadKey();
        }
        public int ReadInt(string question)
        {
            Console.Write(question);
            string value = Console.ReadLine();
            int value1 = int.Parse(value);
            return value1;
        }
        public int ReadInt(string question, int min, int max)
        {
            int value = ReadInt(question);            
            while (value>max || value<min)
            {
                value = ReadInt(question);
            }
            return value;
        }
        public string ReadString(string question)
        {
            Console.Write(question);
            string sentence = Console.ReadLine();
            return sentence;
        }
    }
}
