using MarsRover.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MarsRover.Application
{
    public class CommandCenter : ICommandCenter
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IEnumerable<CommandExecuter> _commandExecuters;
        public CommandCenter(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;

            if (_commandExecuters == null)
            {
                _commandExecuters = GetCommandExecuters();
            }
        }

        public void SendCommand(string command)
        {
            var executer = _commandExecuters.SingleOrDefault(x => x.MatchCommand(command));
            executer?.ExecuteCommand(command);
        }

        private IEnumerable<CommandExecuter> GetCommandExecuters()
        {
            return Assembly.GetExecutingAssembly()
                .DefinedTypes
                .Where(type => type.IsSubclassOf(typeof(CommandExecuter)) && !type.IsAbstract)
                .Select(x => Activator.CreateInstance(x, _serviceProvider) as CommandExecuter)
                .ToList();
        }
    }
}