using System.ComponentModel.DataAnnotations.Schema;

namespace BilethubApi.Api.Entities;

public class PlaceComment{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public int UserId { get; set; }
    public int PlaceId { get; set; }
    public string Content { get; set; } = null!;
    public DateTime Date { get; set; }

    public Place Place { get; set; } = null!;
    public User User { get; set; } = null!;
}