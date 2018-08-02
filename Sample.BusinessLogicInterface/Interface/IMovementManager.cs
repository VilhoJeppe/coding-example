using System.Collections.Generic;
using Sample.BusinessLogicInterface.Dto;

namespace Sample.BusinessLogicInterface.Interface
{
    public interface IMovementManager
    {
        void LogMovements(List<DeviceMovementDto> movement);

        List<DeviceMovementDto> GetLastMovementsForDevice(string deviceName, int movementCount);
    }
}
