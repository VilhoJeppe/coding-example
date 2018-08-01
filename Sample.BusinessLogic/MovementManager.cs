using System.Linq;
using Sample.BusinessLogicInterface.Dto;
using Sample.BusinessLogicInterface.Interface;
using Sample.DatabaseEF;
using Sample.DatabaseEF.Objects;

namespace Sample.BusinessLogic
{
    public class MovementManager : ManagerBase, IMovementManager
    {
        public MovementManager(SampleDataContext sampleDataContext)
            : base(sampleDataContext)
        {
        }
        

        public void LogMovement(DeviceMovementDto movement)
        {
            var device = DataContext.Devices.FirstOrDefault(d => d.DeviceName == movement.DeviceName);

            //if device is notifying movement for the first time, persist device to database
            if (device == null)
            {
                device = new Device
                {
                    DeviceName = movement.DeviceName
                };

                DataContext.Devices.Add(device);
            }

            //save changes just for sure, maybe not needed
            var deviceId = DataContext.SaveChanges();

            device = DataContext.Devices.Find(deviceId);

            //Convert dto to db entity
            var domainObject = movement.MapDomainObject();

            //Set device dependency
            domainObject.Device = device;

            //persist movement
            DataContext.DeviceMovements.Add(domainObject);

            //Save changes
            DataContext.SaveChanges();
        }

        public DeviceMovementDto[] GetMovements()
        {
            var movements = DataContext.DeviceMovements.ToList();
            return movements.Select(s => s.MapDto()).ToArray();
        }
    }
}
