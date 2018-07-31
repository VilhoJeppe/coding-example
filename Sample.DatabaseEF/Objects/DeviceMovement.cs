using Sample.DatabaseEF.Generics;

namespace Sample.DatabaseEF.Objects
{
    public class DeviceMovement : EntityBase
    {
        public Coordinate StartCoordinate { get; set; }

        public Coordinate EndCoordinate { get; set; }
    }
}
