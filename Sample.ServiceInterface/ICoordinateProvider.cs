using System.ServiceModel;

namespace Sample.ServiceInterface
{
    [ServiceContract]
    public interface ICoordinateProvider
    {
        [OperationContract]
        DeviceMovementDc[] GetLastMovementsForDevice(string deviceName, int movementCount);
    }
}
