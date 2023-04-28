namespace MidiDeviceBroker.Devices.Controllers
{
    internal interface IDeviceButton : IDeviceControl
    {
        public void ClickButtonOn();
        public void ClickButtonOff();
        public void ClickButtonToggle();
    }
}