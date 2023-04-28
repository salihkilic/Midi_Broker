namespace MidiDeviceBroker.Devices.ControlTypes
{
    internal interface IDeviceKnob : IDeviceControl
    {
        public void SetValue(int value);
    }
}