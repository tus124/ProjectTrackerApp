
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using ProjectTrackerAPI;
using Xunit;


namespace ProjectTrackerAPITest;

public class MinimalApiTests : IClassFixture<WebApplicationFactory<Startup>>
{
    private readonly WebApplicationFactory<Startup> _factory;

    public MinimalApiTests(WebApplicationFactory<Startup> factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task ExecuteStoredProcedure_EndpointReturnsSuccessAndData()
    {
        // Arrange
        var dbContextMock = new Mock<DAL>();
        dbContextMock.Setup(db => db.ExecuteStoredProcedure()).ReturnsAsync(new List<DAL>
            {
                new YourModel { /* Populate with test data */ }
            });

        var client = _factory.WithWebHostBuilder(builder =>
        {
            builder.ConfigureServices(services =>
            {
                services.AddSingleton(dbContextMock.Object);
            });
        }).CreateClient();

        // Act
        var response = await client.GetAsync("/execute-stored-procedure");

        // Assert
        response.EnsureSuccessStatusCode();
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var content = await response.Content.ReadAsStringAsync();
        var result = JsonSerializer.Deserialize<List<YourModel>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        Assert.NotNull(result);
        Assert.Single(result); // Assert that the result contains one item, adjust as needed based on your test data
                               // Add more assertions as needed based on your expected data
    }
}