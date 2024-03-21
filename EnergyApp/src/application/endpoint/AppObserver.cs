

public interface AppObserver
{
    public bool ConfirmExit();

    public string GetSerialNumber();

    public (string SerialNumber, string MeterModelName, int Number, string FirmwareVersion, int SwitchState) GetEndpointInfo();

    public void DisplayEndpoint(string SerialNumber, string MeterModel, string MeterNumber, string FirmwareVersion, string SwitchState);
}