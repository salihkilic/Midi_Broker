using MidiDeviceBroker.Devices;
using MidiDeviceBroker.Demos;
using NAudio.Midi;
using Serilog;
using Serilog.Sinks.SystemConsole.Themes;

// Set up logger
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console(theme: AnsiConsoleTheme.Code)
    .CreateLogger();

// Setup the device
var device = new Device();

// Ask the user what we're going to do
Console.WriteLine($"What do you want to do? {Environment.NewLine} " +
    $"1. Do some fancy movements for testing {Environment.NewLine}");

if (int.TryParse(Console.ReadLine(), out int x))
{
    switch (x)
    {
        case 1:
            FancyMovements.Start(device);
            break;
        default:
            break;
    }
}
else
{
    Console.WriteLine("Input not recognised, exiting program...");
}

// Wait for user to be done
Thread.Sleep(50000);