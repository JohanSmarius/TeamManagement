using System;
using System.ComponentModel.DataAnnotations;

namespace TeamWebService.Models
{
    public class UpdatedGameDTO
    {
        public int Id { get; set; }

        public DateTime PlayTime { get; set; }

        public bool IsHomeGame { get; set; }

        public DateTime? DepartureTime { get; set; }

        public int? CoachId { get; set; }

        public int? LaundryDutyId { get; set; }

        [Required]
        public string Opponent { get; set; }
    }
}