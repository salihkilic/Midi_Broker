namespace MidiDeviceBroker.Devices.Controllers
{
    internal interface IDeviceControl
    {
        string Name { get; set; }
        int ControlID { get; set; }
        int minValue { get; set; }
        int maxValue { get; set; }
        int currentValue { get; set; }
    }
}