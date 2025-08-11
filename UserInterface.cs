using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace To_Do_list
{
    public static class UserInterface
    {
        public static int ShowReadMenu(string[] choices, string header = "Menu")
        {    // Added parameter. Respect backward compatibility

            Console.WriteLine($"\n {header}:");
            for (int ch = 0; ch < (int)choices.Length; ++ch)
            {

                Console.WriteLine($"\t {ch + 1}: {choices[ch]}");
            }
            Console.WriteLine($"\t 0. Exit");
            return ReadInt(0, choices.Length);
        }
        public static int ReadInt(int low, int high, bool cancel_choice_allowed = false)
        {   // Added parameter. Respect backward compatibility
            if (!cancel_choice_allowed)
                Console.WriteLine("\nEnter number in range " + low + " - " + high + ": ");
            else
                Console.WriteLine("\nEnter -1 to cancel or number in range " + low + " - " + high + ": ");

            int value;
            string sval = Console.ReadLine();
            value = int.Parse(sval);
            if (cancel_choice_allowed && value == -1)
                return value;

            if (low <= value && value <= high)
                return value;

            Console.WriteLine("ERROR: invalid number...Try again\n");
            return ReadInt(low, high);
        }
    }
}
