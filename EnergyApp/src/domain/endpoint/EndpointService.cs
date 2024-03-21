
using System.ComponentModel.Design;

public class EndpointService
{
    private EndpointRepositoryInterface Repository { get; set; }

    public void InsertEndpoint(string SerialNumber, string MeterModelName, int Number, string FirmwareVersion, int SwitchState)
    {
        int MeterModelId;
        switch (MeterModelName)
        {
            case "NSX1P2W":
                MeterModelId = 16;
                break;
            case "NSX1P3W":
                MeterModelId = 17;
                break;
            case "NSX2P2W":
                MeterModelId = 18;
                break;
            case "NSX2P4W":
                MeterModelId = 19;
                break;
            default:
                throw new ServiceException("Invalid model: " + MeterModelName);
        }

        if (SwitchState < 0 || SwitchState > 2)
        {
            // TODO: Use enum or something
            throw new ServiceException("Invalid switch state: " + SwitchState);
        }

        Repository.InsertEndpoint(new EndpointModel(SerialNumber, MeterModelId, Number, FirmwareVersion, SwitchState));
    }

    // TODO: Implement EditEndpoint method

    // TODO: Implement DeleteEndpoint method

    // TODO: Implement FindEndpoint method

    // TODO: Implement GetAllEndpoints method

    public EndpointService(EndpointRepositoryInterface repository)
    {
        Repository = repository;
    }
}