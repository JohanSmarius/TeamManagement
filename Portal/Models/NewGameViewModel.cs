using System.ComponentModel.DataAnnotations;

namespace Portal.Models;

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