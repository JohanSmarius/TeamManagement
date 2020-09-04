using System;
using System.Collections.Generic;
using Core.Domain;

namespace Infrastructure
{
    public class GameSeeder
    {
        public static List<Game> SeedGames()
        {
            var games =  new List<Game>
            {
                new Game(new DateTime(2020, 09, 12, 13, 00, 00), false),
                new Game(new DateTime(2020, 09, 19, 13, 00, 00), false),
                new Game(new DateTime(2020, 09, 20, 13, 00, 00), true),
                new Game(new DateTime(2020, 09, 26, 13, 00, 00), false),
                new Game(new DateTime(2020, 09, 27, 13, 00, 00), false),
                new Game(new DateTime(2020, 10, 03, 13, 00, 00), true),
                new Game(new DateTime(2020, 10, 04, 13, 00, 00), false),
                new Game(new DateTime(2020, 10, 10, 13, 00, 00), false),
                new Game(new DateTime(2020, 10, 11, 13, 00, 00), true),
                new Game(new DateTime(2020, 10, 17, 13, 00, 00), false),
                new Game(new DateTime(2020, 10, 18, 13, 00, 00), true),
                new Game(new DateTime(2020, 10, 24, 13, 00, 00), false),
                new Game(new DateTime(2020, 10, 25, 13, 00, 00), true)
            };

            foreach (var game in games)
            {
                game.Players = PlayerSeeder.SeedPlayers();
            }

            return games;
        }



    }
}