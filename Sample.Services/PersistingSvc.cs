using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Timers;
using Sample.BusinessLogic;
using Sample.BusinessLogicInterface.Interface;
using Sample.ServiceInterface;
using Topshelf;
using Timer = System.Timers.Timer;

namespace Sample.Services
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, MaxItemsInObjectGraph = int.MaxValue)]
    public class PersistingSvc : ServiceControl, ILogCoordinate
    {
        private readonly IMovementManager _movementManager;
        private Timer _timer;
        private readonly object _lock;
        private readonly List<DeviceMovementDc> _movements;

        public PersistingSvc(IMovementManager movementManager)
        {
            _movementManager = movementManager;
            _movements = new List<DeviceMovementDc>();

            _lock = new object();
            _timer = new Timer(3000);
            _timer.Elapsed += TimerOnElapsed;
            _timer.Start();
        }


        private void TimerOnElapsed(object sender, ElapsedEventArgs e)
        {
            _timer.Stop();
            Speculate();
           _timer.Start();
        }

        private void Speculate()
        {
            Console.WriteLine("Later on ");

            var ids = new List<int>();

            lock (_lock)
            {
                foreach (var deviceMovementDc in _movements)
                {
                    _movementManager.LogMovement(deviceMovementDc.MapDto());
                }

                _movements.Clear();
            }
        }

        #region ILogCoordinate

        public void LogMovement(DeviceMovementDc movement)
        {
            try
            {
                lock (_lock)
                {
                    _movements.Add(movement);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public DeviceMovementDc[] GetMovements()
        {
            try
            {
                var movements = _movementManager.GetMovements();
                return movements.Select(s => s.MapDataContract()).ToArray();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        #endregion

        #region ServiceControl

        public bool Start(HostControl hostControl)
        {
            if (_movementManager == null)
                throw new NullReferenceException($"IMovementManager not set.");
            
            return true;
        }

        public bool Stop(HostControl hostControl)
        {
            _timer.Elapsed -= TimerOnElapsed;
            _timer = null;

            return true;
        }

        #endregion
    }
}
