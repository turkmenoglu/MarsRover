using System.Text.RegularExpressions;

namespace MarsRover.Application.Contracts
{
    public interface ICommandExecuter
    {
        Regex RegexCommandPattern { get; }
        void ExecuteCommand(string command);
        bool MatchCommand(string command);
    }
}