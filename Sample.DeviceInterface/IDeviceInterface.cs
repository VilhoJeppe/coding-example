using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.DeviceInterface
{
    public interface IDeviceInterface
    {
        event EventHandler<PlcDeviceMovementArgs> MovementRecorderd;
    }
}
