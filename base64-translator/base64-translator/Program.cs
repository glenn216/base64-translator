#region MIT License
/*
    Copyright 2021 Glenn Alon

    Permission is hereby granted, free of charge, to any person obtaining a copy
    of this software and associated documentation files (the "Software"), to deal
    in the Software without restriction, including without limitation the rights
    to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
    copies of the Software, and to permit persons to whom the Software is
    furnished to do so, subject to the following conditions:

    The above copyright notice and this permission notice shall be included in all
    copies or substantial portions of the Software.

    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
    IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
    FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
    AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
    LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
    OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace base64_translator
{
    class Program
    {
        [DllImport("User32.dll", CharSet = CharSet.Unicode)]
        public static extern int MessageBox(IntPtr h, string m, string c, int type);

        private static string base64input, base64output, textinput, textoutput, Input, input;
        public static string Base64Output, TextOutput;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "<Pending>")]
        static void Main(string[] args)
        {
            Console.Title = "Base64 Translator v1.0";

            Console.WriteLine("Base64 Translator v1.0");
            Console.WriteLine("Copyright (c) 2021 Glenn Alon");
            Console.WriteLine(Convert.ToString(null));
        Start:
            base64input  =    null;
            base64output =    null;
            Base64Output =    null;
            textinput    =    null;
            textoutput   =    null;
            TextOutput   =    null;
            Input        =    null;

            Console.WriteLine("[A] Encode text to base64.");
            Console.WriteLine("[B] Decode base64 to text.");
            Console.WriteLine("[C] Exit");
            Console.Write("    Input: ");
            input = Console.ReadLine();

            if (input == "A" || input == "a")
            {              
                Console.Write("    Text: ");
                textinput = Console.ReadLine();

                Console.Write("    Output: ");
                byte[] tmp = Encoding.Unicode.GetBytes(textinput);
                base64output = Convert.ToBase64String(tmp);
                Console.WriteLine(base64output);

            Point:
                Console.WriteLine("     [1] Copy to clipboard");
                Console.WriteLine("     [2] Continue");
                Console.WriteLine("     [3] Exit");
                Console.Write("         Input: ");
                Input = Console.ReadLine();

                if (Input == "1")
                {
                    Base64Output = base64output;
                    Clipboard.SetText(Base64Output);
                    MessageBox((IntPtr)0, "Output is copied to clipboard.", "", 0);
                }
                else if (Input == "2")
                {
                    Console.WriteLine(Convert.ToString(null));
                    goto Start;
                }
                else if (Input == "3")
                {
                    Environment.Exit(1);
                }
                else
                {
                    Console.WriteLine(Convert.ToString(null));
                    goto Point;
                }

                Console.WriteLine(Convert.ToString(null));
                goto Start;
            }
            else if (input == "B" || input == "b")
            {
                Console.Write("    Base64: ");
                base64input = Console.ReadLine();

                Console.Write("    Output: ");
                textoutput = Encoding.UTF8.GetString(Convert.FromBase64String(base64input));
                Console.WriteLine(textoutput);

            Point:
                Console.WriteLine("     [1] Copy to clipboard");
                Console.WriteLine("     [2] Continue");
                Console.WriteLine("     [3] Exit");
                Console.Write("         Input: ");
                Input = Console.ReadLine();

                if (Input == "1")
                {
                    TextOutput = textoutput;
                    Clipboard.SetText(TextOutput);
                    MessageBox((IntPtr)0, "Output is copied to clipboard.", "", 0);
                }
                else if (Input == "2")
                {
                    Console.WriteLine(Convert.ToString(null));
                    goto Start;
                }
                else if (Input == "3")
                {
                    Environment.Exit(1);
                }
                else
                {
                    Console.WriteLine(Convert.ToString(null));
                    goto Point;
                }

                Console.WriteLine(Convert.ToString(null));
                goto Start;
            }
            else if (input == "C" || input == "c")
            {
                Environment.Exit(1);
            }
            else
            {
                Console.WriteLine(Convert.ToString(null));
                goto Start;
            }
        }
    }
}
