using TestBackend.Models;
using FluentAssertions;
using System;
using System.Net;
using System.Net.Http;
using Xunit;

namespace TestBackend
{
    public class JourneyControllerTest : TestBuilder
    {
        
        [Fact]
        public void GetJourneyError()
        {
            var origin = "SSS";
            var destination = "MZL";
            HttpResponseMessage response = null;
            try
            {
                response = this.testClient.GetAsync($"api/Journey/GetJourney/{origin}/{destination}").Result;
                response.EnsureSuccessStatusCode();
            }
            catch (Exception)
            {
                response.StatusCode.Should().Be(HttpStatusCode.NoContent);
            }
           
        }

        [Fact]
        public void GetJourneySuccess()
        {
            var origin = "BOG";
            var destination = "MZL";
            var response = this.testClient.GetAsync($"api/Journey/GetJourney/{origin}/{destination}").Result;
            response.EnsureSuccessStatusCode();
            var responseContent = response.Content.ReadAsStringAsync().Result;
            var responseLoad = System.Text.Json.JsonSerializer.Deserialize<JourneyDto>(responseContent);
            responseLoad.Flights.Count.Should().Be(2);
            responseLoad.Flights[0].Destination.Should().Be("CTG");
            responseLoad.Price.Should().Be(400);           

        }
    }
}
