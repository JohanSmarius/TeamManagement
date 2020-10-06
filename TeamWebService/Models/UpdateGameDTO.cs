using System;
using System.ComponentModel.DataAnnotations;

namespace TeamWebService.Models
{
    /// <summary>
    ///    Playtime and ishomegame cannot be changed.
    /// </summary>
    public class UpdateGameDTO
    {
        public int Id { get; set; }
        
        public DateTime? DepartureTime { get; set; }

        public int? CoachId { get; set; }

        public int? LaundryDutyId { get; set; }

        [Required]
        public string Opponent { get; set; }
    }
}