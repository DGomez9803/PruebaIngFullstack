using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace TestBackend.Models
{
    public class JourneyDto
    {
        [JsonPropertyName("flights")]

        public List<FlightDto> Flights { get; set; }

        [JsonPropertyName("origin")]

        public string Origin { get; set; }
        [JsonPropertyName("destination")]

        public string Destination { get; set; }
        [JsonPropertyName("price")]

        public double Price { get; set; }

    }
}
