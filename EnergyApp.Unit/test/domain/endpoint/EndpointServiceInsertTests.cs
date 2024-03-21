namespace EnergyApp.Test;

using Moq;
using Xunit;

public class EndpointServiceInsertTests
{
    private EndpointService Service;

    private Mock<EndpointRepositoryInterface> MockRepository;

    public EndpointServiceInsertTests(){
        MockRepository = new Mock<EndpointRepositoryInterface>();
        Service = new EndpointService(MockRepository.Object);
    }

    [Fact]
    public void ValidInsertionTest()
    {
        Service.InsertEndpoint("122A155", "NSX1P2W", 123, "2.23", 1);
        Service.InsertEndpoint("122A156", "NSX1P2W", 123, "2.23", 1);
    }

    [Fact]
    public void InvalidModelInsertionTest()
    {
        Assert.Throws<ServiceException>(() => Service.InsertEndpoint("122A155", "NSX1P5Q", 123, "2.23", 1));
    }

    [Fact]
    public void InvalidSwitchStateInsertionTest()
    {
        Assert.Throws<ServiceException>(() => Service.InsertEndpoint("122A155", "NSX1P2W", 123, "2.23", 3));
    }
}