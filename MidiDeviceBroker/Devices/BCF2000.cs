using NAudio.Midi;

namespace MidiDeviceBroker.Devices
{
    internal class BCF2000 : BaseDevice, IDevice
    {
        public BCF2000() : base("BCF2000", "Behringer BCF2000")
        {
            // Register our functions to the events
            HandleControlChangeEvent += OnControlChange;
        }

        public void OnControlChange(object? sender, ControlChangeEvent e)
        {
            Console.WriteLine(
                $"Control change -- Controller ID: {e.Controller} -- Controller Value {e.ControllerValue} -- Channel: {e.Channel}");
        }

        public void SetControlToValue(int controller, int value)
        {
            var msg = new ControlChangeEvent(0, 1, (MidiController)controller, value);
            DeviceOut.Send(msg.GetAsShortMessage());
        }
    }
}