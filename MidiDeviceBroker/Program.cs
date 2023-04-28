using MidiDeviceBroker.Devices;
using NAudio.Midi;
using Serilog;
using Serilog.Sinks.SystemConsole.Themes;

// Set up logger
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console(theme: AnsiConsoleTheme.Code)
    .CreateLogger();

// Setup the device
var device = new BCF2000();

// Do some fancy movements
Random random = new Random();
for (int i = 0; i < 3; i++)
{
    // Setting Sliders to random positions
    for (int controlId = 81; controlId < 89; controlId++)
    {
        device.SetControlToValue(controlId, random.Next(0, 127));
        Thread.Sleep(100);
    }
    // Setting Knobs to random positions
    for (int controlId = 1; controlId < 9; controlId++)
    {
        device.SetControlToValue(controlId, random.Next(0, 127));
        Thread.Sleep(10);
    }
}
// Resetting Sliders to half position
for (int controlId = 81; controlId < 89; controlId++)
{
    device.SetControlToValue(controlId, 64);
    Thread.Sleep(100);
}
// Resetting Knobs to half position
for (int controlId = 1; controlId < 9; controlId++)
{
    device.SetControlToValue(controlId, 1);
    Thread.Sleep(100);
}

for (int device1 = 0; device1 < MidiOut.NumberOfDevices; device1++)
{
    Console.WriteLine(MidiOut.DeviceInfo(device1).ProductName);
}

// Wait for user to be done
Thread.Sleep(50000);