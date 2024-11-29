using System.ComponentModel.DataAnnotations.Schema;

namespace BilethubApi.Api.Entities;

public class Organizer
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public int UserId { get; set; }
    // public string Image { get; set; } = null!;
    // public string Name { get; set; } = null!;
    // public string Surname { get; set; } = null!;

    public User User { get; set; } = null!;
    public List<Event> Events { get; set; } = null!;
}