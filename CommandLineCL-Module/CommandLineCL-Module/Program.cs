using System;
using CommandLineRun_Module;

namespace CommandLineCL_Module
{
    class Program
    {
        private static frmCommandLineRun objFrmCommandLineRun;

        static void Main(string[] args)
        {
            var objShellOutput = new clsShellOutput();

            objFrmCommandLineRun = new frmCommandLineRun(args, objShellOutput);
            if (string.IsNullOrEmpty(objShellOutput.ErrorText))
            {
                Console.WriteLine(objShellOutput.OutputText);
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine(objShellOutput.OutputText);
                Environment.Exit(-1);
            }
            
        }
    }
}
