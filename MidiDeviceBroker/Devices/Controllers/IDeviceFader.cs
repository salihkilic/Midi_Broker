namespace MidiDeviceBroker.Devices.Controllers
{
    internal interface IDeviceFader : IDeviceControl
    {
        public void SetValue(int value);
    }
}