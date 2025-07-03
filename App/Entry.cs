using ATMApp.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMApp.App
{
    internal class Entry
    {
        static void Main(string[] args)
        {
            Appscreen.Welcome();

            ATM atmApp = new();
            atmApp.InitializeData();

            atmApp.Run();

            Utility.PressEntertoContinue();
        }
    }
}
