using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using ApiAiBlazorLab.Services;
using System.Text.Json;

namespace ApiAiBlazorLab.Tests
{
    public class CatFactServiceTests
    {
        [Fact]
        public async Task GetRandomFact_ReturnsFact()
        {
            var json = "{\"fact\":\"Cats sleep 16 hours a day.\",\"length\":32}";

            var client = new HttpClient(new FakeHandler(json));

            var service = new CatFactService(client);

            var result = await service.GetRandomFactAsync();

            Assert.Equal("Cats sleep 16 hours a day.", result);
        }

        [Fact]
        public async Task GetRandomFact_MissingFactProperty_Fallback()
        {
            var json = "{\"\":\"Cats sleep 16 hours a day.\",\"length\":32}";

            var client = new HttpClient(new FakeHandler(json));

            var service = new CatFactService(client);

            var result = await service.GetRandomFactAsync();

            Assert.Equal("No cat fact received.", result);
        }

        [Fact]
        public async Task GetRandomFact_NullJSON_Fallback()
        {
            var json = "null";

            var client = new HttpClient(new FakeHandler(json));

            var service = new CatFactService(client);

            var result = await service.GetRandomFactAsync();

            Assert.Equal("No cat fact received.", result);
        }

        [Fact]
        public async Task GetRandomFact_InvalidJSON_ThrowsException()
        {
            var json = "{fact:Cats sleep for 16 hours a day.}";

            var client = new HttpClient(new FakeHandler(json));

            var service = new CatFactService(client);

            await Assert.ThrowsAsync<System.Text.Json.JsonException>(async () => await service.GetRandomFactAsync());
        }
    }
}
