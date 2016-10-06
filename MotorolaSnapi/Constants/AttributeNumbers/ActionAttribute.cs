using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motorola.Snapi.Constants.AttributeNumbers
{
    internal enum ActionAttribute : ushort
    {
        BeeperLED = 6000,
        ParameterDefaults = 6001,
        ParameterBuffer = 6002,
        BeepOnNextBootup = 6003,
        Reboot = 6004,
        HostTriggerSession = 6005
    }
}
