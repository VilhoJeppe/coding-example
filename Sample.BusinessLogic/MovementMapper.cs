using Sample.BusinessLogicInterface.Dto;
using Sample.DatabaseEF.Objects;

namespace Sample.BusinessLogic
{
    public static class MovementMapper
    {
        public static CoordinateDto MapDto(this Coordinate domainObject)
            => new CoordinateDto
            {
                X = domainObject.X,
                Y = domainObject.Y,
                Z = domainObject.X
            };

        public static DeviceMovementDto MapDto(this DeviceMovement domainObject)
            => new DeviceMovementDto
            {
                DeviceName = domainObject.DeviceName,
                StartCoordinate = domainObject.StartCoordinate.MapDto(),
                EndCoordinate = domainObject.EndCoordinate.MapDto(),
                AverageVelocityMetersPerSecond = domainObject.AverageVelocityMetersPerSecond
            };

        public static DeviceMovement MapDomainObject(this DeviceMovementDto dto)
            => new DeviceMovement
            {
                DeviceName = dto.DeviceName,
                StartCoordinate = dto.StartCoordinate.MapDomainObject(),
                EndCoordinate = dto.EndCoordinate.MapDomainObject(),
                AverageVelocityMetersPerSecond = dto.AverageVelocityMetersPerSecond
            };

        public static Coordinate MapDomainObject(this CoordinateDto dto)
            => new Coordinate
            {
                X = dto.X,
                Y = dto.Y,
                Z = dto.Z
            };
    }
}
