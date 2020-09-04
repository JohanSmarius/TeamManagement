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
                new Game(new DateTime(2020, 09, 12, 13, 00, 00), false)
                {
                    Id = 1,
                    Opponent = new Opponent { Name = "Team 1"},
                    DepartureTime = new DateTime(2020, 09, 12, 11, 30, 00)
                },
                new Game(new DateTime(2020, 09, 19, 13, 00, 00), false)
                {
                    Id = 2,
                    Opponent = new Opponent { Name = "Team 1"},
                    DepartureTime = new DateTime(2020, 09, 19, 11, 05, 00)
                },
                new Game(new DateTime(2020, 09, 20, 13, 00, 00), true)
                {
                    Id = 3,
                    Opponent = new Opponent { Name = "Team 2"}
                },
                new Game(new DateTime(2020, 09, 26, 13, 00, 00), false)
                {
                    Id = 4,
                    Opponent = new Opponent { Name = "Team 2"},
                    Drivers = new List<CareTaker>()
                    {
                        new CareTaker { Name = "Parent1Player6", HasCar = true},
                        new CareTaker { Name = "Parent1Player3", HasCar = true}
                    }
                },
                new Game(new DateTime(2020, 09, 27, 13, 00, 00), false)
                {
                    Id = 5,
                    Opponent = new Opponent { Name = "Team 3"},
                    DepartureTime = new DateTime(2020, 09, 19, 10, 30, 00)
                },
                new Game(new DateTime(2020, 10, 03, 13, 00, 00), true)
                {
                    Id = 6,
                    Opponent = new Opponent { Name = "Team 3"}, 
                    LaundryDuty = new CareTaker { Name = "Parent1Player4", HasCar = false}
                },
                new Game(new DateTime(2020, 10, 04, 13, 00, 00), false)
                {
                    Id = 7,
                    Opponent = new Opponent { Name = "Team 4"}
                },
                new Game(new DateTime(2020, 10, 10, 13, 00, 00), false)
                {
                    Id = 8,
                    Opponent = new Opponent { Name = "Team 5"}
                },
                new Game(new DateTime(2020, 10, 11, 13, 00, 00), true)
                {
                    Id = 9,
                    Opponent = new Opponent { Name = "Team 5"}
                },
                new Game(new DateTime(2020, 10, 17, 13, 00, 00), false)
                {
                    Id = 10,
                    Opponent = new Opponent { Name = "Team 4"}
                },
                new Game(new DateTime(2020, 10, 18, 13, 00, 00), true)
                {
                    Id = 11,
                    Opponent = new Opponent { Name = "Team 6"}
                },
                new Game(new DateTime(2020, 10, 24, 13, 00, 00), false)
                {
                    Id = 12,
                    Opponent = new Opponent { Name = "Team 6"}
                },
                new Game(new DateTime(2020, 10, 25, 13, 00, 00), true)
                {
                    Id = 13,
                    Opponent = new Opponent { Name = "Team 4"}
                }
            };

            foreach (var game in games)
            {
                game.Players = PlayerSeeder.SeedPlayers();
            }

            return games;
        }



    }
}