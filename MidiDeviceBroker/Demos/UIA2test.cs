using FlaUI.Core.AutomationElements;

namespace MidiDeviceBroker.Demos;
using FlaUI.Core;
using FlaUI.Core.Input;
using FlaUI.UIA3;
using System.Diagnostics;

public class UIA2test
{
    public UIA2test()
    {
        string processName = "CaptureOne"; 
        var automation = new UIA3Automation();
        var process = Process.GetProcessesByName(processName).FirstOrDefault();
        if (process != null)
        {
            Console.WriteLine($"Found Capture One in Process ID: {process.Id}");
            var app = Application.Attach(process.Id);
            
            string elementName = "ExposureToolView";
            var window = app.GetMainWindow(automation);
            var yourElement = window.FindFirstDescendant(cf => cf.ByClassName(elementName));

            if (yourElement != null)
            {
                Console.WriteLine($"Found element with type: {yourElement.ControlType}");
                var children = yourElement.FindAllDescendants();
                var editItems = new List<AutomationElement>();
                foreach (var child in children)
                {
                    Console.WriteLine($"Type: {child.ControlType} -- ID: {child.AutomationId} -- {child.ClassName}");
                    if (child.ControlType.ToString() == "Edit")
                    {

                        Console.WriteLine($"Rangevalue is supported {child.Patterns.Value}");
                        // Get the RangeValuePattern
                        var valuePattern = child.Patterns.Value.Pattern;
                        
                        child.Focus();
                        valuePattern.SetValue("-100");
                        Keyboard.Press(FlaUI.Core.WindowsAPI.VirtualKeyShort.RETURN);
                        Thread.Sleep(1000);
                        valuePattern.SetValue("100");
                        Keyboard.Press(FlaUI.Core.WindowsAPI.VirtualKeyShort.RETURN);
                        Thread.Sleep(1000);
                        valuePattern.SetValue("0");
                        Keyboard.Press(FlaUI.Core.WindowsAPI.VirtualKeyShort.RETURN);
                        Thread.Sleep(1000);
                    }
                }

            }
            else
            {
                Console.WriteLine("Element not found");
            }
            
        }
    }
}