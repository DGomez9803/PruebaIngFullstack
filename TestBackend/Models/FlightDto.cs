
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace TestBackend.Models
{
    public class FlightDto
    {
        [JsonPropertyName("origin")]

        public string Origin { get; set; }
        [JsonPropertyName("destination")]

        public string Destination { get; set; }
        [JsonPropertyName("transport")]

        public TransportDto Transport { get; set; }
        [JsonPropertyName("price")]

        public double Price { get; set; }

       
    }

}
