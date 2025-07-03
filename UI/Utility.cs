using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMApp.UI
{
    public class Utility
    {
        public static string SecretInput(string prompt)
        {
            bool isPrompt = true;
            string asterics = "";

            StringBuilder input = new StringBuilder() ;

            while (true)
            {
                if (isPrompt)
                    Console.WriteLine(prompt);


                isPrompt = false;
                    

                    ConsoleKeyInfo inputkey = Console.ReadKey(true);

                    if (inputkey.Key == ConsoleKey.Enter)
                    {
                        if(input.Length == 6)
                        {
                            break;
                        }
                        else
                        {
                            printMessage("Enter 6 Digits", false);
                            isPrompt = true;
                            input.Clear();
                            continue;
                        }

                    }

                    if (inputkey.Key == ConsoleKey.Backspace && input.Length > 0)
                    {
                        input.Remove(input.Length - 1, 1);

                    }
                    else if(inputkey.Key != ConsoleKey.Backspace)
                    {
                        input.Append(inputkey.KeyChar);
                        Console.Write(asterics + "*");
                    }
                
            }

            return input.ToString();


        }

        public static void printMessage(string msg , bool success)
        {
            if (success)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            Console.WriteLine(msg);
            Console.ResetColor();
            PressEntertoContinue();
        }


        public static string GetUserInput(string prompt)
        {
            Console.WriteLine($"Enter {prompt}");
            return Console.ReadLine();
        }


        public static void PressEntertoContinue()
        {
            Console.WriteLine("\n Press enter to continue ");
            Console.ReadLine();

        }
    }
}
