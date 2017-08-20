using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using TodoApi;
using Xunit;
using FluentAssertions;

namespace ToDoApi.Tests.Integration
{
    public class TodoApiFacts
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public TodoApiFacts()
        {
            // Arrange
            _server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            _client = _server.CreateClient();
        }
        
        [Fact]
        public async void ReturnTodo()
        {
            // Act
            var response = await _client.GetAsync("/api/todo");

            // Assert
            response.StatusCode.Should().Be(200);
            
        }
    }
}
