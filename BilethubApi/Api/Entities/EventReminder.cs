using System.ComponentModel.DataAnnotations.Schema;

namespace BilethubApi.Api.Entities;

public class EventReminder{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public int UserId { get; set; }
    public int EventId { get; set; }
    public DateTime Date { get; set; }

    public Event Event { get; set; } = null!;
    public User User { get; set; } = null!;
}