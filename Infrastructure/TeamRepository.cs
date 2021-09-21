using System;
using System.Collections.Generic;
using Core.Domain;
using Core.DomainServices;

namespace Infrastructure
{
    public class TeamRepository : ITeamRepository
    {
        private readonly GameDbContext _context;

        public TeamRepository(GameDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        
        public IEnumerable<Team> GetTeams()
        {
            return _context.Teams;
        }

    }
}