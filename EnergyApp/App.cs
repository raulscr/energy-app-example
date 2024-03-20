
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
