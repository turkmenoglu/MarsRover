using MarsRover.Domain.Shared;

namespace MarsRover.Domain
{
    public interface IVehicle
    {
        int X { get; }

        int Y { get; }

        ILandingSurface LandingSurface { get; }

        Direction Direction { get; }

        void Move(Movement movement);
    }
}