using Sample.BusinessLogicInterface.Dto;
using Sample.ServiceInterface;

namespace Sample.BusinessLogic
{
    public static class MovementMapper
    {
        public static CoordinateDto MapDto(this CoordinateDc dataContract)
            => new CoordinateDto
            {
                X = dataContract.X,
                Y = dataContract.Y,
                Z = dataContract.X
            };

        public static DeviceMovementDto MapDto(this DeviceMovementDc dataContract)
            => new DeviceMovementDto
            {
                DeviceName = dataContract.DeviceName,
                StartCoordinate = dataContract.StartCoordinate.MapDto(),
                EndCoordinate = dataContract.EndCoordinate.MapDto(),
                AverageVelocityMetersPerSecond = dataContract.AverageVelocityMetersPerSecond
            };

        public static DeviceMovementDc MapDataContract(this DeviceMovementDto dto)
            => new DeviceMovementDc
            {
                DeviceName = dto.DeviceName,
                StartCoordinate = dto.StartCoordinate.MapDataContract(),
                EndCoordinate = dto.EndCoordinate.MapDataContract(),
                AverageVelocityMetersPerSecond = dto.AverageVelocityMetersPerSecond
            };

        public static CoordinateDc MapDataContract(this CoordinateDto dto)
            => new CoordinateDc
            {
                X = dto.X,
                Y = dto.Y,
                Z = dto.Z
            };
    }
}
