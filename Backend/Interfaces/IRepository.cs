using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;

namespace Backend.Interfaces
{
    public interface IRepository
    {
        Task<List<FlightDto>> checkFlightInfo( );
    }
}