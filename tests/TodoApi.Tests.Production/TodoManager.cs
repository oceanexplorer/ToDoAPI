using System;
using System.Diagnostics;
using System.Net.Http;
using Xunit;
using FluentAssertions;
using System.Net;
using System.Threading.Tasks;

namespace TodoApi.Tests.Production
{
    public class TodoManager
    {
        [Fact]
        public async Task CallingHealthCheckReturnStatus200()
        {
            var sw = new Stopwatch();
            sw.Start();

            var duration = Environment.GetEnvironmentVariable("DURATION");
            var hostIp = Environment.GetEnvironmentVariable("HOST_IP");

            if(duration != null && duration.Length > 0)
            {
                float max;
                float.TryParse(duration, out max);

                double minutes = 0;
                int failures = 0;
                string errorMessage = "";

                while(sw.Elapsed.Minutes < max)
                {
                    var httpClient = new HttpClient();                    
                    var address = $"http://{hostIp}/";

                    httpClient.BaseAddress = new Uri(address);
                    var response = await httpClient.GetAsync("api/healthcheck");

                    if(!response.IsSuccessStatusCode)
                    {
                        failures++;
                        errorMessage = response.ReasonPhrase;
                    }
                    else if (response == null)
                    {
                        failures++;
                        errorMessage = "Got no response";
                    }  
                    else
                    {
                        response.StatusCode.Should().Be(HttpStatusCode.OK);
                    }   

                    if(sw.Elapsed.Minutes > minutes)
                    {
                        Debug.WriteLine($"{minutes} out of {max} passed");
                        minutes++;
                    }

                    if(failures > 1)
                    {
                        failures.Should().BeLessThan(1, errorMessage);
                    }               
                }
            }
            else
            {
                var httpClient = new HttpClient();                    
                var address = $"http://{hostIp}/"; 

                httpClient.BaseAddress = new Uri(address);
                var response = await httpClient.GetAsync("api/healthcheck");

                if(!response.IsSuccessStatusCode)
                {                    
                    response.IsSuccessStatusCode.Should().BeTrue();
                }
                else if (response == null)
                {
                    response.Should().NotBeNull();
                }  
                else
                {
                    response.StatusCode.Should().Be(HttpStatusCode.OK);
                }            
            }
        }
    }
}
