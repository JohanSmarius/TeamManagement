using System.Collections.Generic;
using Core.Domain;

namespace Core.DomainServices;

public interface ITeamRepository
{
    IEnumerable<Team> GetTeams();
}