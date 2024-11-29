using System.ComponentModel.DataAnnotations.Schema;

namespace BilethubApi.Api.Entities;

public class CompanyGenre
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public int ArtistId { get; set; }
    public int GenreId { get; set; }


    public Genre Genre { get; set; } = null!;
    public Company Artist { get; set; } = null!;
}