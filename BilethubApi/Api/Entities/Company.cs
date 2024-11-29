using System.ComponentModel.DataAnnotations.Schema;

namespace BilethubApi.Api.Entities;

public class Company
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Image { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string Surname { get; set; } = null!;
    public string Description { get; set; } = null!;

    public List<CompanyGenre> ArtistGenres { get; set; } = null!;
    public List<EventArtist> EventArtists { get; set; } = null!;
    public List<Company> Followers { get; set; } = null!;
    public List<CompanyComment> Comments { get; set; } = null!;
}