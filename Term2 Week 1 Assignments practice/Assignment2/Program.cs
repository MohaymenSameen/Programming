using System;

namespace Assignment2
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
            PrintMonth(Month.January);

            PrintMonths();
            Console.WriteLine();
            Console.WriteLine();


            Month month = ReadMonth("Enter a month: ");
           PrintMonth(month);

            Console.ReadKey();
        }
        void PrintMonth(Month month)
        {
            Console.WriteLine(month);
        }
        void PrintMonths()
        {
            int count = 1;
            for (Month i = Month.January; i <= Month.December; i++)
            {
                Console.Write(string.Format(" {0,4}.  ",count));
                PrintMonth(i);
                count++;
            }
        }
        public Month ReadMonth(string question)
        {
            int value = 0;       
            
            while(1>value || value>12)
            {
                Console.Write(question);
                value = int.Parse(Console.ReadLine());
                Month month = (Month)value;

                if (!Enum.IsDefined(typeof(Month),month))
                {
                    Console.WriteLine("Sorry {0} is not a valid value", value);
                }
                else
                {
                    Console.WriteLine("{0} => {1}", value, month);
                }
            }
            return (Month)value;
        }
    }
}
