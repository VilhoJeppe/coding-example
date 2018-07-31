using Sample.BusinessLogicInterface.Dto;
using System.ServiceModel;


namespace Sample.BusinessLogicInterface
{
    [ServiceContract]
    public interface ILogCoordinate
    {
        [OperationContract]
        void LogMovement(DeviceMovementDto movement);

        [OperationContract]
        DeviceMovementDto[] GetMovements();
    }
}
