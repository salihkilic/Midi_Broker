using MidiDeviceBroker.Devices;
using MidiDeviceBroker.Demos;
using NAudio.Midi;
using Serilog;
using Serilog.Core;
using Serilog.Events;
using Serilog.Sinks.SystemConsole.Themes;

// Set up logger
var levelSwitch = new LoggingLevelSwitch();
levelSwitch.MinimumLevel = LogEventLevel.Error;
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.ControlledBy(levelSwitch)
    .WriteTo.Console(theme: AnsiConsoleTheme.Code)
    .CreateLogger();

// Setup device
var device = new Bcf2000Device();
var running = true;

// Menu
while (running)
{
    Console.WriteLine($"What do you want to do? {Environment.NewLine}" +
                      $"1. Do some fancy movements for testing {Environment.NewLine}" +
                      $"2. Run Debug Mode (Move sliders and knobs for message output){Environment.NewLine}" +
                      $"3. Find UI Elements {Environment.NewLine}" +
                      $"0. Exit application");

    if (int.TryParse(Console.ReadLine(), out int x))
    {
        switch (x)
        {
            case 1:     // Fancy Movements
                Console.WriteLine("Running 'Fancy Movements'...");
                FancyMovements.Start(device);
                break;
            case 2:     // Enter Debug Mode
                levelSwitch.MinimumLevel = LogEventLevel.Debug;
                Console.WriteLine($"Debug Mode: ON -- Move/Press sliders, faders and buttons to see their message.{Environment.NewLine}" +
                                  "Press any key to return to this menu...");
                Console.ReadKey();
                levelSwitch.MinimumLevel = LogEventLevel.Error;
                break;
            case 3:     // Find UI Elements
                var elements = new UIA2test();
                Console.ReadKey();
                break;
            case 0:     // Exit Application
                running = false;
                Console.WriteLine("Stopping application...");
                break;
            default:
                Console.WriteLine($"Incorrect input: {x.ToString()}, please select a number from the command list");
                break;
        }
    }
    else
    {
        Console.WriteLine("Incorrect input type, please select a number from the command list.");
    }
    Console.WriteLine($"{Environment.NewLine}");
}