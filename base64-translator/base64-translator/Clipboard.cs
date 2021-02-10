using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace base64_translator
{
    class Clipboard
    {
        public static void SetText(string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("Attempt to set clipboard with null");
            }

            Process clipboardExecutable = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    RedirectStandardInput = true,
                    FileName = @"clip",
                    UseShellExecute = false,
                }
            };
            _ = clipboardExecutable.Start();

            clipboardExecutable.StandardInput.Write(value);
            clipboardExecutable.StandardInput.Close();

            return;
        }
    }
}
