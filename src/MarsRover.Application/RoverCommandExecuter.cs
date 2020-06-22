using System;
using System.Text.RegularExpressions;
using MarsRover.Application.Contracts;
using MarsRover.Domain;
using MarsRover.Domain.Shared;
using Microsoft.Extensions.DependencyInjection;

namespace MarsRover.Application
{
    public class RoverCommandExecuter : CommandExecuter
    {
        private readonly IRoverSquadManager _squadManager;

        public RoverCommandExecuter(IServiceProvider serviceProvider)
        {
            _squadManager = serviceProvider.GetService<IRoverSquadManager>();
        }

        public override Regex RegexCommandPattern => new Regex("^[LMR]+$");

        public override void ExecuteCommand(string command)
        {
            if (CheckIfActiveRoverExists(out var activeRover))
                return;

            MoveRoverByCommand(command, activeRover);
            ReportLocation(activeRover);
        }

        private static void MoveRoverByCommand(string command, IVehicle activeRover)
        {
            foreach (var order in command)
            {
                var movement = Enum.Parse<Movement>(order.ToString());
                activeRover.Move(movement);
            }
        }

        private static void ReportLocation(IVehicle activeRover)
        {
            Console.WriteLine(activeRover.ToString());
        }

        private bool CheckIfActiveRoverExists(out IVehicle activeRover)
        {
            activeRover = _squadManager.ActiveRover;
            return activeRover == null;
        }
    }
}