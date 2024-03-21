public class EndpointRepositoryStatic : EndpointRepositoryInterface
{

    private List<EndpointModel> registredEndpoints { get; set; }
    public EndpointModel FindEndpointBySerialNumber(string serialNumber)
    {
        EndpointModel? result = registredEndpoints.Find(endpoint => endpoint.EndpointSerialNumber == serialNumber);
        if (result == null)
        {
            throw new RepositoryException("Endpoint with serial number " + serialNumber + " not found");
        }

        return result;
    }
    public void UpdateEndpointBySerialNumber(EndpointModel model)
    {
        int index = registredEndpoints.FindIndex(endpoint => endpoint.EndpointSerialNumber == model.EndpointSerialNumber);
        if (index == -1)
        {
            throw new RepositoryException("Endpoint with serial number " + model.EndpointSerialNumber + " not found");
        }

        registredEndpoints[index] = model;
    }
    public void InsertEndpoint(EndpointModel model)
    {
        EndpointModel? result = registredEndpoints.Find(endpoint => endpoint.EndpointSerialNumber == model.EndpointSerialNumber);
        if (result != null)
        {
            throw new RepositoryException("Endpoint with serial number " + model.EndpointSerialNumber + " already exists");
        }

        registredEndpoints.Add(model);
    }
    public bool RemoveEndpointBySerialNumber(string serialNumber)
    {
        int index = registredEndpoints.FindIndex(endpoint => endpoint.EndpointSerialNumber == serialNumber);
        if (index == -1)
        {
            return false;
        }
        registredEndpoints.RemoveAt(index);
        return true;
    }


    public List<EndpointModel> FindAllEndpoints()
    {
        return registredEndpoints;
    }

    public EndpointRepositoryStatic()
    {
        registredEndpoints = new List<EndpointModel>();
    }
}