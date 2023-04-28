using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidiDeviceBroker.Devices.Controllers
{
    internal interface IControlCollection
    {
        public List<int> Buttons { get;}
        public List<int> Faders { get;}
    }
}
