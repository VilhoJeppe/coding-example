using System.Runtime.Serialization;

namespace Sample.ServiceInterface
{
    [DataContract]
    public class DeviceMovementDc : BaseDc
    {
        [DataMember]
        public string DeviceName { get; set; }

        [DataMember]
        public CoordinateDc StartCoordinate { get; set; }
        
        [DataMember]
        public CoordinateDc EndCoordinate { get; set; }

        [DataMember]
        public decimal AverageVelocityMetersPerSecond { get; set; }
    }
}
