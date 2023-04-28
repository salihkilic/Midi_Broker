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
var device = new Device();

// Ask the user what we're going to do
Console.WriteLine($"What do you want to do? {Environment.NewLine} " +
    $"1. Do some fancy movements for testing {Environment.NewLine}");

if (int.TryParse(Console.ReadLine(), out int x))
{
    switch (x)
    {
        case 1:
            FancyMovements(device);
            break;
        default:
            break;
    }
}
else
{
    Console.WriteLine("Input not recognised, exiting program...");
}

void FancyMovements(IDevice device) {
    // Do some fancy movements
    Random random = new Random();
    for (int i = 0; i < 200; i++)
    {
        // Set a slider
        var randomValueFader = random.Next(0, 128);
        var randomFader = device.Controls.Faders[random.Next(device.Controls.Faders.Count)];
        device.SetControlToValue(randomFader, randomValueFader);

        // Set a button
        var randomValueButton = random.Next(2);
        if (randomValueButton == 1) randomValueButton = 127;
        var randomButton = device.Controls.Buttons[random.Next(device.Controls.Buttons.Count)];
        device.SetControlToValue(randomButton, randomValueButton);
        // Give the device a little time to actually do this
        Thread.Sleep(100);
    }

    // Reset all the faders to 0
    foreach (var fader in device.Controls.Faders) device.SetControlToValue(fader, 0);

    // Reset all the buttons to off
    foreach (var button in device.Controls.Buttons) device.SetControlToValue(button, 0);
}

// Wait for user to be done
Thread.Sleep(50000);