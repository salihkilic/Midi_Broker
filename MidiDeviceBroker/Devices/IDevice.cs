using NAudio.Midi;

namespace MidiDeviceBroker.Devices
{
    internal interface IDevice
    {
        public void OnControlChange(object? sender, ControlChangeEvent e);
    }
}