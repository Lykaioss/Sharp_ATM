using ATMApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMApp.UI
{
    internal static  class Appscreen
    {

        internal static void Welcome()
        {
            Console.Clear();
            Console.Title = "ATM app";
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine(" Enter your ATM Card ");

            Utility.PressEntertoContinue();
        }

        internal static UserAccount UserLoginForm()
        {
            UserAccount tempUserAccount = new UserAccount();
            tempUserAccount.CardNumber = Validator.Convert<long>("your card number");
            tempUserAccount.CardPin = Convert.ToInt32(Utility.SecretInput("Enter your Card Pin "));
            return tempUserAccount;
        }

        internal static void LoginProgress()
        {
            Console.WriteLine("\nChecking card number and pin");
            int timer = 10;
            for (int i = 0; i < timer; i++)
            {
                Console.Write(" . ");
                Thread.Sleep(200);
            }
            Console.Clear();
        }

        internal static void PrintLockScreen()
        {
            Console.Clear();
            Utility.printMessage("Your Account is Locked  " , true );
            Utility.PressEntertoContinue();
            Environment.Exit(1);
        }







    }
}
