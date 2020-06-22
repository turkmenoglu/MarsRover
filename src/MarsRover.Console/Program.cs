using MarsRover.Application;
using MarsRover.Application.Contracts;

namespace MarsRover.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Bootstrapper.Init();

            var commandCenter = Bootstrapper.GetService<ICommandCenter>();
            commandCenter.SendCommand("5 5");
            commandCenter.SendCommand("1 2 N");
            commandCenter.SendCommand("LMLMLMLMM");
            commandCenter.SendCommand("3 3 E");
            commandCenter.SendCommand("MMRMMRMRRM");

            System.Console.ReadKey();
        }
    }
}
