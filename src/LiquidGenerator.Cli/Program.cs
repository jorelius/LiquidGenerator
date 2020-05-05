using System;
using PowerArgs;

namespace LiquidGenerator.Cli
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine();
                Args.InvokeAction<Controller>(args);
            }
            catch (ArgException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ArgUsage.GenerateUsageFromTemplate<Controller>());
            }
        }
    }
}
