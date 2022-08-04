using System.Collections.Generic;
using System.Linq;
using Core.Domain;
using Core.DomainServices;

namespace Infrastructure;

public class CoachRepository : ICoachRepository
{
    private readonly GameDbContext _context;

    public CoachRepository(GameDbContext context)
    {
        _context = context;
    }


    public IEnumerable<Coach> GetCoaches()
    {
        return _context.Coaches;
    }

    public Coach GetById(int id)
    {
        return _context.Coaches.SingleOrDefault(coach => coach.Id == id);
    }
}