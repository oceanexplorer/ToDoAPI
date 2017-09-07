using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using TodoApi;
using Xunit;
using FluentAssertions;
using System.Net;
using TodoApi.Models;
using System.Text;
using Newtonsoft.Json;
using System.Net.Http.Headers;

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

            var todoItem = new TodoItem("Collect the children from school", false);
            var jsonString = JsonConvert.SerializeObject(todoItem);            

            _client.PostAsync("/api/todo", new StringContent(jsonString, Encoding.UTF8)).Wait();
        }
        
        [Fact]
        public async void ReturnTodo()
        {
            // Act
            var response = await _client.GetAsync("/api/todo");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);                   
        }        
    }
}
