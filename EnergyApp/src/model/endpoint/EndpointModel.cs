

// Generaly it's not a good idea to use the same model between all layers
// (e.g.: repository, domain, etc...) but I'll do it to avoid losing time
public class EndpointModel
{
    public string EndpointSerialNumber { get; set; }
    public int MeterModelId { get; set; }
    public int MeterNumber { get; set; }
    public string MeterFirmwareVersion { get; set; }
    public int SwitchState { get; set; }

    public EndpointModel(string endpointSerialNumber = "", int meterModelId = 0, int meterNumber = 0, string meterFirmwareVersion = "", int switchState = 0)
    {
        EndpointSerialNumber = endpointSerialNumber;
        MeterFirmwareVersion = meterFirmwareVersion;
        MeterModelId = meterModelId;
        MeterNumber = meterNumber;
        SwitchState = switchState;
    }
}
