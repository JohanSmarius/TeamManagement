using System;
using System.Collections.Generic;

namespace Core.Domain
{
    public class Game
    {
        /// <summary>
        /// The starting time of the time (includes the date of the game)
        /// The playtime can be considered to be the identifying attribute for this class.
        /// No two games can happen at the same time.
        /// </summary>
        public DateTime PlayTime { get; set; }


        private DateTime _departureTime;
        /// <summary>
        /// Only necessary for not home games.
        /// Only the time part is relevant. The date part should always be
        /// the same as the playtime.
        /// </summary>
        public DateTime DepartureTime 
        {
            get 
            {
                return _departureTime;
            }
            set
            {
                if (!IsHomeGame)
                {
                    _departureTime = value;
                }
                else
                {
                    throw new InvalidOperationException();
                }
            }
        }

        /// <summary>
        /// Home game?
        /// </summary>
        public bool IsHomeGame { get; set; }

        /// <summary>
        /// The primary coach for the game. Other coaches may assist,
        /// but are not kept track of in this system.
        /// </summary>
        public Coach Coach { get; set; }

        public List<IPerson> PeopleInvolved { get; set; }

        public CareTaker LaundryDuty { get; set; }

        public Game(DateTime playTime, bool isHomeGame)
        {
            IsHomeGame = isHomeGame;
            PlayTime = playTime;
        }

        public int GetTotalScore()
        {
            var totalScore = 0;

            foreach (var person in PeopleInvolved)
            {
                if (person is Player player)
                {
                    totalScore += player.TotalScore;
                }
            }

            return totalScore;
        }
    }
}
