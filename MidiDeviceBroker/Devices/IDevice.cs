using MidiDeviceBroker.Devices.Controllers;
using NAudio.Midi;

namespace MidiDeviceBroker.Devices
{
    internal interface IDevice
    {
        public IControlCollection Controls { get; }
        public void OnControlChange(object? sender, ControlChangeEvent e);
        void SetControlToValue(int controlId, int value);
    }
}