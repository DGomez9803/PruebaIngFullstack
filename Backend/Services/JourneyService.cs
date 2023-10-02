using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Backend.Interfaces;
using Backend.Models;
using Newtonsoft.Json;
using Backend.Repositories;
using System.Linq;

namespace Backend.Services
{
    public class JourneyService : IJourney
    {
        public IRepository _db;

        public JourneyService(IRepository db)
        {
            _db = db;
        }

        public  JourneyDto  GetJourney(string origin, string destination)
        {
            List <FlightDto> flights = _db.checkFlightInfo().Result;
            return findingShortestRoute(origin, destination, flights);
        }

        /// <summary>
        /// Finds the shortest route from the given origin to the specified destination using available flights.
        /// </summary>
        /// <param name="origin">The origin of the journey.</param>
        /// <param name="destination">The destination of the journey.</param>
        /// <param name="flights">A list of FlightDto objects representing available flights.</param>
        /// <returns>A JourneyDto object representing the shortest route from origin to destination or null if no route is found.</returns>

        private JourneyDto findingShortestRoute(string origin, string destination, List<FlightDto> flights)
        {
            if (flights.Count==0)
            {
                return null;
            }
            var journeys = new List<JourneyDto>();
            List < FlightDto > possibleFlights = flights.Where(Obj => Obj.Origin != origin).ToList();
            List < FlightDto > currentFlights = flights.Where(Obj => Obj.Origin == origin).ToList();
            foreach (var flight in currentFlights)
            {
                var newFlight = flight.Clone();
                var newJourney = new JourneyDto
                {
                    Origin = origin,
                    Destination = destination,
                    Price = newFlight.Price
                };
                newJourney.Flights.Add(newFlight);
                string newOrigin = newFlight.Destination;
                List<string> visited = new List<string>();
                visited.Add(newFlight.Destination);
                findingRoutesRecursively(newOrigin, destination, possibleFlights, newJourney, journeys, visited);

            }
            if (journeys.Count == 0)
            {
                return null ;
            }
            else {
                return journeys.OrderBy(Obj => Obj.Flights.Count).First();
            }
           
        }

        /// <summary>
        /// Recursively explores possible routes from the current origin to the specified destination.
        /// </summary>
        /// <param name="origin">The current location in the journey.</param>
        /// <param name="destination">The destination location of the journey.</param>
        /// <param name="flights">A list of FlightDto objects representing available flights.</param>
        /// <param name="journey">The current journey being explored.</param>
        /// <param name="journeys">A list to store all possible journeys.</param>
        /// <param name="visited">A list to track visited destinations.</param>

        private void findingRoutesRecursively(string origin, string destination, List<FlightDto> flights, JourneyDto journey, List<JourneyDto> journeys, List<string> visited)
        {
            if (origin == destination)
            {
                journeys.Add(journey);
            }
            else { 
                List<FlightDto> PossibleFlights = flights.Where(Obj => Obj.Origin != origin).ToList();
                List<FlightDto> CurrentFlights = flights.Where(Obj => Obj.Origin == origin).ToList();
                foreach (var Flight in CurrentFlights)
                {
                    var newFlight = Flight.Clone();

                    if (!visited.Contains(newFlight.Destination) )
                    {
                        var newJourney = journey.Clone();
                        newJourney.Price += newFlight.Price;
                        newJourney.Flights.Add(newFlight);
                        string newOrigin = newFlight.Destination;
                        visited.Add(newFlight.Destination);
                        findingRoutesRecursively(newOrigin, destination, PossibleFlights, newJourney, journeys, visited);
                    }
                }
            }
        }
    }
}
