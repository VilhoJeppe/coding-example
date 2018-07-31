using Sample.BusinessLogicInterface;
using Sample.BusinessLogicInterface.Dto;
using Sample.DatabaseEF;
using Sample.DatabaseEF.Objects;

namespace Sample.BusinessLogic
{
    public class MovementManager : ILogCoordinate
    {
        private readonly SampleDataContext _sampleDataContext;

        public MovementManager(SampleDataContext sampleDataContext)
        {
            _sampleDataContext = sampleDataContext;
        }

        public void LogMovement(DeviceMovementDto movement)
        {
            var movement = new DeviceMovement
            {
                
            }
        }

        public DeviceMovementDto[] GetMovements()
        {
            throw new System.NotImplementedException();
        }
    }
}
