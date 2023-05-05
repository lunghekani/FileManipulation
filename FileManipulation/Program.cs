using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; // library that is going to be used to help us manage files
using System.Runtime.InteropServices;

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
            #region Reading
            //List<string> userInfo = new List<string>(); // creating a list to store all user info
            List<User> usersList = new List<User>();    
            // StreamReader Class 
            using(StreamReader sr = new StreamReader(filePath))
            { // file is now open and ready to be read

                sr.ReadLine(); // reading the first line in the file

                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] arrUserInfo = line.Split(','); // splitting into an array

                    var user = new User
                    {
                        Id = arrUserInfo[0],
                        FirstName = arrUserInfo[1],
                        Surname = arrUserInfo[2],
                        Email = arrUserInfo[3],
                        Gender = arrUserInfo[4],
                        IpAddress = arrUserInfo[5],
                    };

                    usersList.Add(user);
                 }
                sr.Close();
            }

            foreach (var item in usersList)
            {
                if (item.Email.Contains(".edu"))
                {
                    Console.WriteLine($"{item.FirstName}, {item.Surname} has email: {item.Email}");
                }
            }
            #endregion 

            filePath = "./export.txt";
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                sw.WriteLine($"{DateTime.Now.ToString()} - Date NON edu users were logged ");

                foreach (var item in usersList)
                {
                    if (!item.Email.Contains(".edu"))
                    {
                        sw.WriteLine($"SUSPECT| \t Failed login: {item.Email}, {item.IpAddress}");
                    }
                }
                
            }
           
            using (StreamWriter sw = new StreamWriter(filePath, true))
            {
                sw.WriteLine($"{DateTime.Now.ToString()} - Date edu users were logged " );
                sw.WriteLine("\t #### \t ##### \t #### \t ##### \t #### \t ##### \t #### \t #####");
                foreach (User item in usersList)
                {
                    if (item.Email.Contains(".edu"))
                    {
                        sw.WriteLine($"{item.FirstName}, {item.Surname} has email: {item.Email}");
                    }
                }

            }






            Console.ReadLine();
    
        }



    }
    class User
    {
     
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string IpAddress { get; set; }
    }
}
