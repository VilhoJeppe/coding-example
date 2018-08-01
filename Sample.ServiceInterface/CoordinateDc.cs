using System.Runtime.Serialization;

namespace Sample.ServiceInterface
{
    [DataContract]
    public class CoordinateDc
    {
        [DataMember]
        public int X { get; set; }

        [DataMember]
        public int Y { get; set; }

        [DataMember]
        public int Z { get; set; }
    }
}
