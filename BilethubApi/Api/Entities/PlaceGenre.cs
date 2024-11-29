using System.ComponentModel.DataAnnotations.Schema;

namespace BilethubApi.Api.Entities;

public class PlaceGenre{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Title { get; set; } = null!;

    public List<Place> Places { get; set; } = null!;
}