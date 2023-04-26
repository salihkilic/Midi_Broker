using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidiDeviceBroker.Devices.ControlTypes
{
    internal interface IDeviceControl
    {
        string Name { get; set; }
        int minValue { get; set; }
        int maxValue { get; set; }
        int currentValue { get; set; }

    }
}
