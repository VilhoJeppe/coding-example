using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Sample.DatabaseEF.Generics;

namespace Sample.DatabaseEF.Objects
{
    public class Device : EntityBase
    {
        //Not null device name to database
        [Required]
        public string DeviceName { get; set; }

        public List<DeviceMovement> Movements { get; set; }
    }
}
