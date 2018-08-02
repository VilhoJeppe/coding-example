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
    //Multiple thread access to service and make WCF quotas larger. 
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, MaxItemsInObjectGraph = int.MaxValue)]
    public class PersistingSvc : ServiceControl, ILogCoordinate, ICoordinateProvider
    {
        //Injected with Ninject
        private readonly IMovementManager _movementManager;

        //Timer for poller method
        private Timer _timer;
        
        private readonly object _lock;

        //Internal collection of movements
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

        //Poller method called evey 5 seconds.
        private void Speculate()
        {
            Console.WriteLine("Later on ");

            //Lock internal collection
            lock (_lock)
            {
               _movementManager.LogMovements(_movements.Select(m => m.MapDto()).ToList());

                _movements.Clear();
            }
        }

        #region ILogCoordinate

        public void LogMovement(DeviceMovementDc movement)
        {
            //Always try-catch on WCF calls on both receiving and sending end 
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

        public DeviceMovementDc[] GetLastMovementsForDevice(string deviceName, int movementCount)
        {
            try
            {
                var movements = _movementManager.GetLastMovementsForDevice(deviceName, movementCount);
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

            //This is only here so that SampleDataContextInitializer creates the database on startup. Did not have time to investigate how to do this with configuration,
            //which would be the right way
            var movements = _movementManager.GetLastMovementsForDevice("Loader1", 200);
            
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
