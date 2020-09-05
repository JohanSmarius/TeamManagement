﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        public int LaundryDutyId { get; set; }

        [Required]
        public string Opponent { get; set; }
    }
}