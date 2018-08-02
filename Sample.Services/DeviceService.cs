using System;
using System.ServiceModel;
using Sample.BusinessLogic;
using Sample.DeviceInterface;
using Sample.ServiceInterface;
using Topshelf;

namespace Sample.Services
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, MaxItemsInObjectGraph = int.MaxValue)]
    public class DeviceService : ServiceControl
    {
        private readonly IDeviceInterface _deviceInterface;

        public DeviceService(IDeviceInterface deviceInterface)
        {
            _deviceInterface = deviceInterface;
        }

        private void MovementRecorderd(object sender, PlcDeviceMovementArgs e)
        {
            var proxy = GetPersistingProxy();

            try
            {
                proxy.LogMovement(e.MapDataContract());
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        public ILogCoordinate GetPersistingProxy()
        {
            throw new NotImplementedException();
        }

        public bool Start(HostControl hostControl)
        {
            if(_deviceInterface == null)
                throw new NullReferenceException("Device interface");

            _deviceInterface.MovementRecorderd += MovementRecorderd;

            return true;
        }

        public bool Stop(HostControl hostControl)
        {
           _deviceInterface.MovementRecorderd -= MovementRecorderd;
            
            return true;
        }
    }
}
