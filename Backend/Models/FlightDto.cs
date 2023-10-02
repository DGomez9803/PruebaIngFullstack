
using Newtonsoft.Json;

namespace Backend.Models
{
    public class FlightDto
    {
        public string Origin { get; set; }

        public string Destination { get; set; }

        public TransportDto Transport { get; set; }

        public double Price { get; set; }

        [JsonConstructor]
        public FlightDto(string departureStation, string arrivalStation, string flightCarrier, string flightNumber, double price)
        {
            Origin = departureStation;
            Destination = arrivalStation;
            Price = price;
            Transport = new TransportDto() { FlightCarrier = flightCarrier, FlightNumber = flightNumber }; 
        }
        public FlightDto Clone()
        {
            return new FlightDto(this.Origin, this.Destination, this.Transport.FlightCarrier, this.Transport.FlightNumber, this.Price) ;
        }
    }

}
