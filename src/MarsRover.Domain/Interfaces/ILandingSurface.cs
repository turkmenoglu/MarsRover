using MarsRover.Domain.Shared;

namespace MarsRover.Domain
{
    public interface ILandingSurface
    {
        SurfaceSize Size { get; }

        void Define(int width, int height);
    }
}