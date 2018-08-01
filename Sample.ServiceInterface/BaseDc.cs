using System.Runtime.Serialization;

namespace Sample.ServiceInterface
{
    [DataContract]
    [KnownType(typeof(DeviceMovementDc))]
    public class BaseDc
    {
        [DataMember]
        public virtual int? Id { get; set; }

        [DataMember]
        public byte[] RowVersion { get; set; }
    }
}
