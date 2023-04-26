using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidiDeviceBroker.Devices.ControlTypes
{
    internal interface IDeviceButton: IDeviceControl
    {
        public void ClickButton();
    }
}
