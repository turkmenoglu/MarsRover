namespace MarsRover.Application.Contracts
{
    public interface ICommandCenter
    {
        void SendCommand(string command);
    }
}