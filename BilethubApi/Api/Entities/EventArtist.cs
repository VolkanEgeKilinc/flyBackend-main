using System.ComponentModel.DataAnnotations.Schema;

namespace BilethubApi.Api.Entities;

public class EventArtist
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public int EventId { get; set; }
    public int ArtistId { get; set; }


    public Event Event { get; set; } = null!;
    public Artist Artist { get; set; } = null!;
}