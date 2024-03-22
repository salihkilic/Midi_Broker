using NAudio.Midi;
using Serilog;

namespace MidiDeviceBroker.Devices
{
    internal class BaseDevice
    {
        internal string? DeviceID { get; set; }
        internal string? DeviceName { get; set; }
        internal int DeviceIndex { get; set; }
        internal MidiIn DeviceIn { get; set; }
        internal MidiOut DeviceOut { get; set; }

        // Possible types of events we might have to deal with
        public event EventHandler? HandleNoteOffEvent;

        public event EventHandler? HandleNoteOnEvent;

        public event EventHandler? HandleKeyAfterTouchEvent;

        public event EventHandler<ControlChangeEvent>? HandleControlChangeEvent;

        public event EventHandler<PatchChangeEvent>? HandlePatchChangeEvent;

        public event EventHandler<ChannelAfterTouchEvent>? HandleChannelAfterTouchEvent;

        public event EventHandler<PitchWheelChangeEvent>? HandlePitchWheelChangeEvent;

        public event EventHandler<SysexEvent>? HandleSysexEvent;

        public event EventHandler? HandleEoxEvent;

        public event EventHandler? HandleTimingClockEvent;

        public event EventHandler? HandleStartSequenceEvent;

        public event EventHandler? HandleContinueSequenceEvent;

        public event EventHandler? HandleStopSequenceEvent;

        public event EventHandler? HandleAutoSensingEvent;

        public event EventHandler<MetaEvent>? HandleMetaEvent;

        public BaseDevice(string id, string name)
        {
            DeviceID = id;
            DeviceName = name;
            FindDevices();
            if (DeviceIn != null)
            {
                DeviceIn.MessageReceived += OnMsg;
                DeviceIn.ErrorReceived += OnError;
                DeviceIn.Start();
            }
        }

        private void FindDevices()
        {
            for (int deviceIndex = 0; deviceIndex < MidiIn.NumberOfDevices; deviceIndex++)
            {
                if (MidiIn.DeviceInfo(deviceIndex).ProductName == DeviceID)
                {
                    DeviceIn = new MidiIn(deviceIndex);
                }
            }
            for (int deviceIndex = 0; deviceIndex < MidiOut.NumberOfDevices; deviceIndex++)
            {
                if (MidiOut.DeviceInfo(deviceIndex).ProductName == DeviceID)
                {
                    DeviceOut = new MidiOut(deviceIndex);
                }
            }
            if (DeviceIn is null || DeviceOut is null)
            {
                throw new Exception($"One of the devices ({DeviceName}) could not be found for MidiOut or MidiIn. Check if the device is powered on and connected.");
            }
        }

        private void OnMsg(object sender, MidiInMessageEventArgs e)
        {
            Log.Debug($"Event Received: {e.MidiEvent.CommandCode}{Environment.NewLine}" +
                      $"Event: {e.MidiEvent}");

            // We need to check the type of event because some have to be explicity cast
            // before we can use their relevant variables.
            // As of now, we are only interested in implementing Control Changes.
            // We can implement more as soon as IDevice implements them as well.
            switch (e.MidiEvent.CommandCode)
            {
                case MidiCommandCode.NoteOff:
                    Log.Error($"This type of event ({e.MidiEvent.CommandCode}) is not yet supported");
                    break;

                case MidiCommandCode.NoteOn:
                    Log.Error($"This type of event ({e.MidiEvent.CommandCode}) is not yet supported");
                    break;

                case MidiCommandCode.KeyAfterTouch:
                    Log.Error($"This type of event ({e.MidiEvent.CommandCode}) is not yet supported");
                    break;

                case MidiCommandCode.ControlChange:
                    HandleControlChangeEvent?.Invoke(this, (ControlChangeEvent)e.MidiEvent);
                    break;

                case MidiCommandCode.PatchChange:
                    Log.Error($"This type of event ({e.MidiEvent.CommandCode}) is not yet supported");
                    break;

                case MidiCommandCode.ChannelAfterTouch:
                    Log.Error($"This type of event ({e.MidiEvent.CommandCode}) is not yet supported");
                    break;

                case MidiCommandCode.PitchWheelChange:
                    Log.Error($"This type of event ({e.MidiEvent.CommandCode}) is not yet supported");
                    break;

                case MidiCommandCode.Sysex:
                    Log.Error($"This type of event ({e.MidiEvent.CommandCode}) is not yet supported");
                    break;

                case MidiCommandCode.Eox:
                    Log.Error($"This type of event ({e.MidiEvent.CommandCode}) is not yet supported");
                    break;

                case MidiCommandCode.TimingClock:
                    Log.Error($"This type of event ({e.MidiEvent.CommandCode}) is not yet supported");
                    break;

                case MidiCommandCode.StartSequence:
                    Log.Error($"This type of event ({e.MidiEvent.CommandCode}) is not yet supported");
                    break;

                case MidiCommandCode.ContinueSequence:
                    Log.Error($"This type of event ({e.MidiEvent.CommandCode}) is not yet supported");
                    break;

                case MidiCommandCode.StopSequence:
                    Log.Error($"This type of event ({e.MidiEvent.CommandCode}) is not yet supported");
                    break;

                case MidiCommandCode.AutoSensing:
                    Log.Error($"This type of event ({e.MidiEvent.CommandCode}) is not yet supported");
                    break;

                case MidiCommandCode.MetaEvent:
                    Log.Error($"This type of event ({e.MidiEvent.CommandCode}) is not yet supported");
                    break;

                default:
                    Log.Error($"I didn't even expect this type of event ({e.MidiEvent.CommandCode}) to exist, so it's not supported");
                    break;
            }
        }

        public void OnError(object sender, MidiInMessageEventArgs e)
        {
            Log.Error(
                $"Error received @ {e.Timestamp} {Environment.NewLine}" +
                $"Raw Msg: {e.RawMessage}{Environment.NewLine}" +
                $"Event: {e.MidiEvent}{Environment.NewLine}");
        }
    }
}