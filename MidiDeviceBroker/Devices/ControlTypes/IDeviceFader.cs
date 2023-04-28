namespace MidiDeviceBroker.Devices.ControlTypes
{
    internal interface IDeviceFader : IDeviceControl
    {
        public void SetValue(int value);
    }
}