using Sample.BusinessLogicInterface.Dto;

namespace Sample.BusinessLogicInterface.Interface
{
    public interface IMovementManager
    {
        void LogMovement(DeviceMovementDto movement);

        DeviceMovementDto[] GetMovements();
    }
}
