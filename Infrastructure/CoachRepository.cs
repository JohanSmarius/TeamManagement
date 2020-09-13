using System.Collections.Generic;
using System.Linq;
using Core.Domain;
using Core.DomainServices;

namespace Infrastructure
{
    public class CoachRepository : ICoachRepository
    {
        private List<Coach> _coaches = new List<Coach>()
        {
            new Coach() { Id = 1, Name = "Tim" }, new Coach() { Id = 2, Name = "Iris" }
        };


        public IEnumerable<Coach> GetCoaches()
        {
            return _coaches;
        }

        public Coach GetById(int id)
        {
            return _coaches.SingleOrDefault(coach => coach.Id == id);
        }
    }
}