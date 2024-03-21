
namespace Application
{
    public class AppController
    {
        private AppObserver Observer;

        public bool Exit { get; private set; }

        private string HandleOption(string option)
        {
            switch (option)
            {
                case "1":
                    // TODO: implement option 1
                    return "Option 1 selected";
                case "2":
                    // TODO: implement option 2
                    return "Option 2 selected";
                case "3":
                    // TODO: implement option 3
                    return "Option 3 selected";
                case "4":
                    // TODO: implement option 4
                    return "Option 4 selected";
                case "5":
                    // TODO: implement option 5
                    return "Option 5 selected";
                case "6":
                    if (Observer.ConfirmExit())
                    {
                        Exit = true;
                        return "Exiting the application...";
                    }
                    return "";
                default:
                    return "Invalid Option";
            }
        }

        public string ProcessOption(string option)
        {
            try
            {
                return HandleOption(option);
            }
            catch (System.Exception e)
            {
                return "Error: " + e.Message;
            }
        }

        public AppController(AppObserver observer)
        {
            Observer = observer;
            Exit = false;
        }
    }
}