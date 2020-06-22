using System.Text.RegularExpressions;

namespace MarsRover.Application.Contracts
{
    public abstract class CommandExecuter : ICommandExecuter
    {
        public abstract Regex RegexCommandPattern { get; }

        public abstract void ExecuteCommand(string command);

        public bool MatchCommand(string command)
        {
            return RegexCommandPattern.IsMatch(command);
        }
    }
}