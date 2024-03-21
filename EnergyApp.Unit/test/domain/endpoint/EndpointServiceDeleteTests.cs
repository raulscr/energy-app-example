namespace EnergyApp.Test;

using Moq;
using Xunit;

public class EndpointServiceDeleteTests
{
    private EndpointService Service;

    private Mock<EndpointRepositoryInterface> MockRepository;

    public EndpointServiceDeleteTests(){
        MockRepository = new Mock<EndpointRepositoryInterface>();
        Service = new EndpointService(MockRepository.Object);
    }

    [Fact]
    public void DeleteExistentEndpointTest()
    {
        MockRepository.Setup(m => m.RemoveEndpointBySerialNumber(It.IsAny<string>())).Returns(true);
        Assert.True(Service.DeleteEndpoint("122A155"));
    }

    [Fact]
    public void DeleteInexistentEndpointTest()
    {
        MockRepository.Setup(m => m.RemoveEndpointBySerialNumber(It.IsAny<string>())).Returns(false);
        Assert.False(Service.DeleteEndpoint("122A155"));
    }
}