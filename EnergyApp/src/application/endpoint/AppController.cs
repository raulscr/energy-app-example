
namespace Application
{
    public class AppController
    {
        private AppObserver Observer;

        private EndpointService Service;

        public bool Exit { get; private set; }

        private string HandleOption(string option)
        {
            switch (option)
            {
                case "1":
                    (string SerialNumber, string MeterModelName, int Number, string FirmwareVersion, int SwitchState) = Observer.GetEndpointInfo();
                    Service.InsertEndpoint(SerialNumber, MeterModelName, Number, FirmwareVersion, SwitchState);
                    return "Endpoint Inserted Successfully.";
                case "2":
                    // TODO: implement option 2
                    return "Option 2 selected";
                case "3":
                    // TODO: implement option 3
                    return "Option 3 selected";
                case "4":
                    return DisplayAllEndpoints();
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

        private string DisplayAllEndpoints()
        {
            List<EndpointModel> endpoints = Service.GetAllEndpoints();

            if (!endpoints.Any())
            {
                return "No Endpoints found!";
            }

            // NOTE: concat everything here into a single string could end up using too much memory,
            // so we let the "one who will display it" handle item-by-item as it want.
            Observer.DisplayEndpoint("Serial number", "Meter Model", "Meter Number", "Firmware Version", "Switch state");
            foreach (EndpointModel item in endpoints)
            {
                Observer.DisplayEndpoint(item.EndpointSerialNumber, item.MeterModelId.ToString(),
                item.MeterNumber.ToString(), item.MeterFirmwareVersion, item.SwitchState.ToString());
            }
            return "";
        }

        public AppController(AppObserver observer)
        {
            // TODO: maybe build it all into a factory/façade
            Service = new EndpointService(new EndpointRepositoryStatic());
            Observer = observer;
            Exit = false;
        }
    }
}