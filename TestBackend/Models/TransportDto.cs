


using System.Text.Json.Serialization;

namespace TestBackend.Models
{
    public class TransportDto
    {
        [JsonPropertyName("flightCarrier")]

        public string FlightCarrier { get; set; }
        [JsonPropertyName("flightNumber")]

        public string FlightNumber { get; set; }
    }
}
