using System.Runtime.Serialization;

namespace Sample.BusinessLogicInterface.Dto
{
    [DataContract]
    [KnownType(typeof(DeviceMovementDto))]
    public class BaseDto
    {
        [DataMember]
        public virtual int? Id { get; set; }

        [DataMember]
        public byte[] RowVersion { get; set; }
    }
}
