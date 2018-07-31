using System.Runtime.Serialization;

namespace Sample.BusinessLogicInterface.Dto
{
    [DataContract]
    public class DeviceMovementDto : BaseDto
    {
        [DataMember]
        public CoordinateDto StartCoordinate { get; set; }
        
        [DataMember]
        public CoordinateDto EndCoordinate { get; set; }
    }
}
