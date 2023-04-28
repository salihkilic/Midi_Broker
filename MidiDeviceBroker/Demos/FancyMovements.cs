using MidiDeviceBroker.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidiDeviceBroker.Demos
{
    internal class FancyMovements
    {
        public static void Start(IDevice device)
        {
            // Do some fancy movements
            Random random = new Random();
            for (int i = 0; i < 200; i++)
            {
                // Set a slider
                var randomValueFader = random.Next(0, 128);
                var randomFader = device.Controls.Faders[random.Next(device.Controls.Faders.Count)];
                device.SetControlToValue(randomFader, randomValueFader);

                // Set a button
                var randomValueButton = random.Next(2);
                if (randomValueButton == 1) randomValueButton = 127;
                var randomButton = device.Controls.Buttons[random.Next(device.Controls.Buttons.Count)];
                device.SetControlToValue(randomButton, randomValueButton);
                // Give the device a little time to actually do this
                Thread.Sleep(100);
            }

            // Reset all the faders to 0
            foreach (var fader in device.Controls.Faders) device.SetControlToValue(fader, 0);

            // Reset all the buttons to off
            foreach (var button in device.Controls.Buttons) device.SetControlToValue(button, 0);
        }
    }
}
