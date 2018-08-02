using System.Collections.Generic;
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

        public void LogMovements(List<DeviceMovementDto> movements)
        {
            foreach (var deviceMovementDto in movements)
            {
                LogMovement(deviceMovementDto);

                //Save changes
                DataContext.SaveChanges();
            }
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
        }

        public List<DeviceMovementDto> GetLastMovementsForDevice(string deviceName, int movementCount)
        {
            var movements = DataContext.DeviceMovements.Where(m => m.DeviceName == deviceName)
                .OrderBy(t => t.TimeRecorded)
                .Take(movementCount).ToList();

            return movements.Select(s => s.MapDto()).ToList();
        }
    }
}
