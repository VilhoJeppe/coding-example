using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;
using Sample.DatabaseEF.Generics;

namespace Sample.DatabaseEF.Objects
{
    public class DeviceMovement : EntityBase
    {
        public string DeviceName { get; set; }

        public Coordinate StartCoordinate { get; set; }

        public Coordinate EndCoordinate { get; set; }

        public decimal AverageVelocityMetersPerSecond { get; set; }

        public DateTime TimeRecorded { get; set; }

        /// <summary>
        /// This dependency is only needed, if we create database with EF initializer as I have been doing in the beginning of project recently
        /// It makes sure that table Movement gets not nullable foreign key to table Device.
        /// </summary>
        [Required] 
        public Device Device { get; set; }
    }
}
