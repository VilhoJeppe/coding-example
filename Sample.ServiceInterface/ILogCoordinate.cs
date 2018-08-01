using System;
using System.ServiceModel;

namespace Sample.ServiceInterface
{
    [ServiceContract]
    public interface ILogCoordinate
    {
        [OperationContract]
        void LogMovement(DeviceMovementDc movement);

        [OperationContract]
        DeviceMovementDc[] GetMovements();
    }
}
