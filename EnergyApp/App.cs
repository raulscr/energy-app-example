
using Application;

public class App : AppObserver
{

    private AppController Controller { get; set; }

    public bool ConfirmExit()
    {
        Console.WriteLine("Do you really want to quit?");
        string? input = Console.ReadLine();
        return input == null || input.ToLower() == "y" || input.ToLower() == "yes";
    }

    public (string SerialNumber, string MeterModelName, int Number, string FirmwareVersion, int SwitchState) GetEndpointInfo()
    {
        Console.WriteLine(@"
        Please input the following information separated by comma(,):
        Endpoint Serial Number
        Meter Model
        Meter Number
        Meter Firmware Version
        Meter Switch State (0 for Disconnected, 1 for Connected and 2 for Armed)
        Example:
        122A155,NSX1P2W,222,2.22,0
        ");

        int Number, SwitchState;
        string[]? info = Console.ReadLine()?.Split(",");
        if (info == null || info.Length < 5)
        {
            throw new Exception("Some information is missing");
        }

        if (!Int32.TryParse(info[2], out Number))
        {
            throw new Exception("Meter number is not a number (" + info[2] + ")");
        }

        if (!Int32.TryParse(info[4], out SwitchState))
        {
            throw new Exception("Meter Switch State (" + info[4] + ")");
        }


        return (info[0], info[1], Number, info[3], SwitchState);
    }

    public string GetSerialNumber()
    {
        Console.WriteLine("Please input the Endpoint Serial Number");
        string? input = Console.ReadLine();
        if (input == null)
        {
            throw new Exception("Serial number can't be null");
        }
        return input;
    }

    public void DisplayEndpoint(string SerialNumber, string MeterModel, string MeterNumber, string FirmwareVersion, string SwitchState)
    {
        Console.WriteLine(String.Format("|{0,20}|{1,20}|{2,20}|{3,20}|{4,20}|", SerialNumber, MeterModel, MeterNumber, FirmwareVersion, SwitchState));
    }

    public string AvailableOptions()
    {
        return @"
            1) Insert a new endpoint\n
            2) Edit an existing endpoint\n
            3) Delete an existing endpoint\n
            4) List all endpoint\n
            5) Find an endpoint by 'Endpoint Serial Number'\n
            6) Exit\n
        ";
    }

    public void Exec()
    {
        Controller = new AppController(this);
        while (!Controller.Exit)
        {
            Console.Write(AvailableOptions());
            // Controller shall not care if the input come from a standard input or whatever
            // That's why I separated it in App and AppController
            string? input = Console.ReadLine();
            if (input != null)
            {
                Console.WriteLine(Controller.ProcessOption(input));
            }
        }
    }
}
