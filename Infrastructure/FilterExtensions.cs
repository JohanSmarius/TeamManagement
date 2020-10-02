using System;
using System.Collections.Generic;
using Core.Domain;

namespace Infrastructure
{
    public static class FilterExtensions
    {
        public static IEnumerable<Game> FilterGames(this IEnumerable<Game> games, Func<Game, bool> filterExpressie)
        {
            foreach (var game in games)
            {
                if (filterExpressie(game))
                {
                    yield return game;
                }
            }
        }
    }
}
