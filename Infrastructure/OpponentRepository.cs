using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Domain;
using Core.DomainServices;

namespace Infrastructure
{
    public class OpponentRepository : IOpponentRepository
    {
        private readonly GameDbContext _context;

    }
}