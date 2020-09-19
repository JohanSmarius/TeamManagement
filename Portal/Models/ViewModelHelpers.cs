using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Domain;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.Extensions.Primitives;

namespace Portal.Models
{
    public static class ViewModelHelpers
    {
        public static List<GamesViewModel> ToViewModel(this IEnumerable<Game> games)
        {
            var result = new List<GamesViewModel>();

            foreach (var game in games)
            {
                result.Add(game.ToViewModel());
            }

            return result;
        }

        public static GamesViewModel ToViewModel(this Game game)
        {
            var result =  new GamesViewModel
            {
                PlayTime = game.PlayTime,
                DepartureTime = game.DepartureTime,
                Coach = game.Coach,
                LaundryDuty = game.LaundryDuty,
                Opponent = game.Opponent,
                IsHomeGame = game.IsHomeGame
            };

            if (game.Drivers != null)
            {
                var stringToBuild = new StringBuilder();

                for (var i = 0; i < game.Drivers.Count; i++)
                {
                    stringToBuild.Append(game.Drivers.ElementAt(i).Name);

                    // Put a ; between the drivers
                    if (i < game.Drivers.Count - 1)
                    {
                        stringToBuild.Append(";");
                    }
                }

                result.Drivers = stringToBuild.ToString();
            }

            return result;
        }
    }
}