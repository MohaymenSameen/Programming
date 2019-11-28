using System;
using System.Collections.Generic;

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
            //DisplayCourse(ReadCourse("Enter a course"));
            List<Course> report = new List<Course>();            
            DisplayReport(ReadReport(report));

            Console.ReadKey();
        }
        public PracticalGrade ReadPracticalGrade(string question)
        {
            Console.Write(question);
            int pgrade = int.Parse(Console.ReadLine());
            PracticalGrade practical = (PracticalGrade)pgrade;
            return practical;
        }
        void DisplayPracticalGrade(PracticalGrade practical)
        {
            Console.WriteLine(practical);
        }
        public Course ReadCourse(string question)
        { 
            Course course = new Course();
            int count = 0;
            Console.WriteLine(question);
            course.Name = ReadString("Name of the course: ");
            course.Grade = ReadInt("Grade for " + course.Name + ": ");            
            foreach (PracticalGrade p in Enum.GetValues(typeof(PracticalGrade)))
            {
                Console.Write("{0}. {1}   ", count, p);
                count++;
            }
            Console.WriteLine();
            course.Practical = ReadPracticalGrade("Practical grade for " + course.Name + ": ");
            return course;
        }
        void DisplayCourse(Course course)
        {
            Console.WriteLine(string.Format("{0}:{1,10}{2,10}", course.Name, course.Grade, course.Practical));
        }
        public List<Course> ReadReport(List<Course> courses)
        {
            for (int i = 0; i < 3; i++)
            {
                Course course = ReadCourse("Enter a course");
                courses.Add(course);
                Console.WriteLine();
            }
            return courses;
        }
        void DisplayReport(List<Course> courses)
        {

            bool graduated = true;
            bool cumlaude = true;
            int count = 0;            
            foreach (Course item in courses)
            {
                DisplayCourse(item);

                if (!item.Passed())
                {
                    graduated = false;
                    count++;                    
                }
                else
                {
                    graduated = true;
                }

                if (!item.CumLaude())
                {
                    cumlaude = false;
                }
                            
            }
            if (graduated==true)
            {
                Console.WriteLine("You Graduated!!");
            }
            else
            {                
                Console.WriteLine("You did not graduate, you have {0} retakes", count);
            }

            if (cumlaude==true)
            {
                Console.WriteLine("You have achieved CumLaude");
            }
            else
            {
                Console.WriteLine("You have no achieved CumLaude");
            }
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
