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

            List<string> userInfo = new List<string>(); // creating a list to store all user info
            // StreamReader Class 
            using(StreamReader sr = new StreamReader(filePath))
            { // file is now open and ready to be read

                sr.ReadLine(); // reading the first line in the file

                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] arrUserInfo = line.Split(','); // splitting into an array
                    userInfo.Add($"Name: {arrUserInfo[1]} surname: {arrUserInfo[2]} "); 
                }

            }

            foreach (var item in userInfo)
            {
                Console.WriteLine(item);
            }



            Console.ReadLine();
            // reading from a file


            // writing to a file 
        }
    }
}
