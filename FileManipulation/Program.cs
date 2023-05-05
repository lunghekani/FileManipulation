using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; // library that is going to be used to help us manage files
namespace FileManipulation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // . - one folder up
            // / - inside this folder
            // ~ - root directory
            string filePath = "./MOCK_DATA.csv"; 


            // StreamReader Class 
            using(StreamReader sr = new StreamReader(filePath))
            { // file is now open and ready to be read
                
                sr.ReadLine(); // reading the first line in the file

                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    
                    Console.WriteLine(line);
                    

                }

            }
            Console.ReadLine();
            // reading from a file


            // writing to a file 
        }
    }
}
