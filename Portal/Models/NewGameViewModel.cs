using System;
using System.Collections.Generic;
using Core.Domain;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Portal.Models
{
    public class NewGameViewModel
    {
        public DateTime PlayTime { get; set; }

        public DateTime? DepartureTime { get; set; }

        public bool IsHomeGame { get; set; }

        public int CoachId { get; set; }
       // public Coach Coach { get; set; }

        public int LaundryDutyId { get; set; }
        //public CareTaker CareTaker { get; set; }

        public SelectList Coaches { get; set; }

        public SelectList CareTakers { get; set; }
    }
}