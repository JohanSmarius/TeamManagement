using System.Collections.Generic;
using Core.Domain;

namespace Infrastructure;

public class PlayerSeeder
{
    public static List<Player> SeedPlayers()
    {
        return new List<Player>
        {
            new Player { Name = "Player1", PlayerNumber = 1},
            new Player { Name = "Player2", PlayerNumber = 2},
            new Player { Name = "Player3", PlayerNumber = 3, CareTakers = new List<CareTaker>()
            {
                new CareTaker { Id = 1, Name = "Parent1Player3", HasCar = true}
            }},
            new Player { Name = "Player4", PlayerNumber = 4, CareTakers = new List<CareTaker>()
            {
                new CareTaker { Id = 2, Name = "Parent1Player4", HasCar = false}
            }},
            new Player { Name = "Player5", PlayerNumber = 5},
            new Player { Name = "Player6", PlayerNumber = 6, CareTakers = new List<CareTaker>()
            {
                new CareTaker { Id = 3, Name = "Parent1Player6", HasCar = true}
            }},
            new Player { Name = "Player7", PlayerNumber = 7},
            new Player { Name = "Player8", PlayerNumber = 8},
            new Player { Name = "Player9", PlayerNumber = 9},
            new Player { Name = "Player10", PlayerNumber = 10, CareTakers = new List<CareTaker>()
            {
                new CareTaker { Id = 4, Name = "Parent1Player10", HasCar = false}
            }},
            new Player { Name = "Player11", PlayerNumber = 11},
            new Player { Name = "Player12", PlayerNumber = 12},
        };
    }
}