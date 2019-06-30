using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace tests.IntegrationTests
{
    public class BasicTests : IClassFixture<WebApplicationFactory<Api.Startup>>
    {
        private readonly WebApplicationFactory<Api.Startup> _factory;

        public BasicTests(WebApplicationFactory<Api.Startup> factory)
        {
            factory = _factory;
        }

        [Fact]
        public void GetHttpRequest()
        {
            Assert.Equal(1, 1);
        }
    }
}