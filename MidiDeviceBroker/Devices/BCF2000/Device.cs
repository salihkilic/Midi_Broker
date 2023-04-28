using MidiDeviceBroker.Devices;
using MidiDeviceBroker.Devices.BCF2000;
using MidiDeviceBroker.Devices.Controllers;
using NAudio.Midi;

namespace MidiDeviceBroker.Devices
{
    internal class Device : BaseDevice, IDevice
    {
        public IControlCollection Controls {get; private set;}

        public Device() : base("BCF2000", "Behringer BCF2000")
        {
            Controls = new ControlCollection();
            // Register our functions to the events
            HandleControlChangeEvent += OnControlChange;
        }
        public void OnControlChange(object? sender, ControlChangeEvent e)
        {
            Console.WriteLine(
                $"Control change -- Controller ID: {e.Controller} -- Controller Value {e.ControllerValue} -- Channel: {e.Channel}");
        }

        public void SetControlToValue(int controlId, int value)
        {
            var msg = new ControlChangeEvent(0, 1, (MidiController)controlId, value);
            DeviceOut.Send(msg.GetAsShortMessage());
        }
    }
}