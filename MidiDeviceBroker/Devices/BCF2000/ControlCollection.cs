using MidiDeviceBroker.Devices.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidiDeviceBroker.Devices.BCF2000
{
    internal class ControlCollection : IControlCollection
    {
        public List<int> Buttons { get; } = new() { 
            // Top row buttons on knobs 
            33, 34, 35, 36, 37, 38, 39, 40,
            // First actual button row
            65, 66, 67, 68, 69, 70, 71, 72,
            // Second row of buttons
            73, 74, 75, 76, 77, 78, 79, 80
        };

        public List<int> Faders { get; } = new()
        {
            //Top Row Knobs
            1, 2, 3, 4, 5, 6, 7, 8,
            // Bottom Row Faders
            81, 82, 83, 84, 85, 86, 87, 88
        };
    }
}
