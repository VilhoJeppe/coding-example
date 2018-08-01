using System.Linq;
using Sample.BusinessLogicInterface.Dto;
using Sample.BusinessLogicInterface.Interface;
using Sample.DatabaseEF;
using Sample.DatabaseEF.Objects;

namespace Sample.BusinessLogic
{
    public class MovementManager : IMovementManager
    {
        private readonly SampleDataContext _sampleDataContext;

        public MovementManager(SampleDataContext sampleDataContext)
        {
            _sampleDataContext = sampleDataContext;
        }

        public void LogMovement(DeviceMovementDto movement)
        {
            var device = _sampleDataContext.Devices.FirstOrDefault(d => d.DeviceName == movement.DeviceName);

            //if device is notifying movement for the first time, persist device to database
            if (device == null)
            {
                device = new Device
                {
                    DeviceName = movement.DeviceName
                };

                _sampleDataContext.Devices.Add(device);
            }

            //save changes just for sure, maybe not needed
            var deviceId = _sampleDataContext.SaveChanges();

            device = _sampleDataContext.Devices.Find(deviceId);

            //Convert dto to db entity
            var domainObject = movement.MapDomainObject();

            //Set device dependency
            domainObject.Device = device;

            //persist movement
             _sampleDataContext.DeviceMovements.Add(domainObject);

            //Save changes
            _sampleDataContext.SaveChanges();
        }

        public DeviceMovementDto[] GetMovements()
        {
            var movements = _sampleDataContext.DeviceMovements.ToList();
            return movements.Select(s => s.MapDto()).ToArray();
        }
    }
}
