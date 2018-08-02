using System;

namespace Sample.DeviceInterface
{
    public class PlcDeviceMovementArgs : EventArgs
    {
        public string DeviceName { get; set; }

        public PlcDeviceCoordinate StartCoordinate { get; set; }

        public PlcDeviceCoordinate EndCoordinate { get; set; }

        public decimal AverageVelocityMetersPerSecond { get; set; }

        public DateTime TimeRecorded { get; set; }
    }
}
