using System;
using System.Collections.Generic;
using Core.Domain;

namespace Portal.Models
{
    public class GamesViewModel
    {
        public DateTime PlayTime { get; set; }

        public DateTime? DepartureTime { get; set; }

        public bool IsHomeGame { get; set; }

        public Coach Coach { get; set; }

        public string Drivers { get; set; }

        public CareTaker LaundryDuty { get; set; }

        public Opponent Opponent { get; set; }
    }
}