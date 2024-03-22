using FlaUI.Core.AutomationElements;

namespace MidiDeviceBroker.Demos;
using FlaUI.Core;
using FlaUI.UIA3;
using System.Diagnostics;

public class UIA3test
{
    public UIA3test()
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
                        editItems.Add(child);
                    }
                }

                var exposureSliderValue = editItems[0].Patterns.Value.Pattern;
                var exposureSlider = editItems[0].Patterns.RangeValue;
                editItems[0].Focus();
                exposureSliderValue.SetValue("4");
                editItems[1].Focus();
                Thread.Sleep(1000);
                exposureSliderValue.SetValue("0");
                editItems[1].Focus();
                Thread.Sleep(1000);
                editItems[0].Focus();
                exposureSliderValue.SetValue("4");
                editItems[1].Focus();
                Thread.Sleep(1000);
                exposureSliderValue.SetValue("0");
                editItems[1].Focus();
                Thread.Sleep(1000);
                editItems[0].Focus();
                exposureSliderValue.SetValue("4");
                editItems[1].Focus();
                Thread.Sleep(1000);
                exposureSliderValue.SetValue("0");
                editItems[1].Focus();
                Thread.Sleep(1000);
                editItems[0].Focus();
                exposureSliderValue.SetValue("4");
                editItems[1].Focus();
                Thread.Sleep(1000);
                exposureSliderValue.SetValue("0");
                editItems[1].Focus();




            }
            else
            {
                Console.WriteLine("Element not found");
            }
            
        }
    }
}