using System;

namespace Sample.BusinessLogicInterface.Dto
{
    
    public class DeviceMovementDto : BaseDto
    {
        public string DeviceName { get; set; }

        public CoordinateDto StartCoordinate { get; set; }
        
        public CoordinateDto EndCoordinate { get; set; }

        public decimal AverageVelocityMetersPerSecond { get; set; }

        public DateTime TimeRecorded { get; set; }
    }
}
