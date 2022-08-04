using System.Collections.Generic;
using Core.Domain;

namespace Core.DomainServices;

public interface IPlayerRepository
{
    IEnumerable<Player> GetPlayers();
}