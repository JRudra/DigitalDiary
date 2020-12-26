using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DigitalDiary
{
    class User
    {
        //public int Id { get; set; }
        //public string Name { get; set; }
        //public string Username { get; set; }
        //public string Password { get; set; }
        //public string DateOfBirth { get; set; }
        //public string Gender { get; set; }
        //public string BloodGroup { get; set; }
    }
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new homePage());
        }
    }
}
