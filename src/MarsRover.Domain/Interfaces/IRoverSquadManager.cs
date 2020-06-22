using MarsRover.Domain.Shared;
using System.Collections.Generic;

namespace MarsRover.Domain
{
    public interface IRoverSquadManager
    {
        IList<Rover> Rovers { get; }

        IVehicle ActiveRover { get; }

        ILandingSurface LandingSurface { get; }

        void DeployRover(int x, int y, Direction direction);
    }
}