using Sample.BusinessLogicInterface.Dto;
using Sample.DeviceInterface;
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
                AverageVelocityMetersPerSecond = dataContract.AverageVelocityMetersPerSecond,
                TimeRecorded = dataContract.TimeRecorded
            };

        public static DeviceMovementDc MapDataContract(this DeviceMovementDto dto)
            => new DeviceMovementDc
            {
                DeviceName = dto.DeviceName,
                StartCoordinate = dto.StartCoordinate.MapDataContract(),
                EndCoordinate = dto.EndCoordinate.MapDataContract(),
                AverageVelocityMetersPerSecond = dto.AverageVelocityMetersPerSecond,
                TimeRecorded = dto.TimeRecorded
            };

        public static CoordinateDc MapDataContract(this CoordinateDto dto)
            => new CoordinateDc
            {
                X = dto.X,
                Y = dto.Y,
                Z = dto.Z
            };

        public static CoordinateDc MapDataContract(this PlcDeviceCoordinate plcCoordinate)
            => new CoordinateDc
            {
                X = plcCoordinate.X,
                Y = plcCoordinate.Y,
                Z = plcCoordinate.Z
            };

        public static DeviceMovementDc MapDataContract(this PlcDeviceMovementArgs plcMovement)
            => new DeviceMovementDc
            {
                DeviceName = plcMovement.DeviceName,
                StartCoordinate = plcMovement.StartCoordinate.MapDataContract(),
                EndCoordinate = plcMovement.EndCoordinate.MapDataContract(),
                AverageVelocityMetersPerSecond = plcMovement.AverageVelocityMetersPerSecond,
                TimeRecorded = plcMovement.TimeRecorded
            };
    }
}
