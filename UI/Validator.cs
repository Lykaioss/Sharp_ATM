﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMApp.UI
{
    public static class Validator
    {
        public static T Convert<T>( string prompt)
        {
            bool valid = false;
            string userInput;

            while (!valid)
            {
                userInput = Utility.GetUserInput(prompt);

                try
                {
                  var converter =  TypeDescriptor.GetConverter(typeof(T));
                    if(converter != null)
                    {
                        return (T)converter.ConvertFromString(userInput);            // TypeDescriptor.GetConverter(typeof(T)) - gets type converter for long store it in var 
                    }
                    else
                    {
                        return default;
                    }

                }

                catch{
                    Utility.printMessage("Invalid input try again " , false);
                }

            }
            return default;
        }
    }
}
