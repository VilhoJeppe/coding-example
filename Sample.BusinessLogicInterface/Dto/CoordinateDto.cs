using System.Runtime.Serialization;

namespace Sample.BusinessLogicInterface.Dto
{
    [DataContract]
    public class CoordinateDto
    {
        [DataMember]
        public int X { get; set; }

        [DataMember]
        public int Y { get; set; }

        [DataMember]
        public int Z { get; set; }
    }
}
