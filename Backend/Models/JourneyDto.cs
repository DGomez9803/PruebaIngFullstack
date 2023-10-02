using System;
using System.Collections.Generic;
using System.Linq;


namespace Backend.Models
{
    public class JourneyDto
    {
        public  List<FlightDto> Flights { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public double Price { get; set; }

        public JourneyDto()
        {
            Flights = new List<FlightDto>();
        }
        public JourneyDto Clone()
        {
            return new JourneyDto() { Origin= this.Origin, Flights= this.Flights.ToList(), Destination=this.Destination,Price=this.Price };
        }
    }
}
