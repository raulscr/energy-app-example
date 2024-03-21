
public interface EndpointRepositoryInterface
{
    public EndpointModel FindEndpointBySerialNumber(string serialNumber);
    public void UpdateEndpointBySerialNumber(EndpointModel model);
    public void InsertEndpoint(EndpointModel model);
    public bool RemoveEndpointBySerialNumber(string serialNumber);

    public List<EndpointModel> FindAllEndpoints();
}