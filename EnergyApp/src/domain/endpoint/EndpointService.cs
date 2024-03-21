public class EndpointService
{
    private EndpointRepositoryInterface Repository { get; set; }

    // TODO: maybe the endpoint model should be created outside, and just the verifications handled here...
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

    // I'll avoid using the same method as above, because it's a different funcionality (domain).
    // Some day the business may change to only one of the methods, then we may have a bug.
    public void EditEndpoint(string SerialNumber, string MeterModelName, int Number, string FirmwareVersion, int SwitchState)
    {
        // But this conversion could really be a generic map somewhere else...
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

        Repository.UpdateEndpointBySerialNumber(new EndpointModel(SerialNumber, MeterModelId, Number, FirmwareVersion, SwitchState));
    }

    public bool DeleteEndpoint(string serialNumber)
    {
        return Repository.RemoveEndpointBySerialNumber(serialNumber);
    }

    public EndpointModel FindEndpoint(string SerialNumber)
    {
        return Repository.FindEndpointBySerialNumber(SerialNumber);
    }

    public List<EndpointModel> GetAllEndpoints()
    {
        return Repository.FindAllEndpoints();
    }

    public EndpointService(EndpointRepositoryInterface repository)
    {
        Repository = repository;
    }
}