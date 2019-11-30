using System;
using System.IO;
using System.Text.RegularExpressions;

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
            Console.Write("Enter a word: ");
            string word = Console.ReadLine().ToLower();
            SearchWordInFile("tweets.txt", word);

            Console.ReadKey();
        }
        public bool WordInLine(string line, string word)
        {
            if (line.ToLower().Contains(word.ToLower()))
            {
                return true;
            }
            return false;
        }
        public int SearchWordInFile(string filename, string word)
        {
            StreamReader reader = new StreamReader(filename);
            string line = "";
            int count = 0;

            while (!reader.EndOfStream)
            {
                line = reader.ReadLine();              

                if (WordInLine(line,word))
                {
                    Console.WriteLine();
                    DisplayWordInLine(line, word);
                    count++;
                }                
            }
            Console.WriteLine();
            Console.WriteLine("Number of line containing the word: {0}", count);
            reader.Close();
            return count;
        }
        void DisplayWordInLine(string line, string word)
        {
            int start = line.ToLower().IndexOf(word.ToLower());
            string beginning = line.Substring(0, start);          
            string newword = line.Substring(start, word.Length);
            line = line.Substring(start + word.Length);
            Console.Write(beginning);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(newword);
            Console.ResetColor();
            Console.WriteLine(line);
        }
    }
}
