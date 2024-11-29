using System.ComponentModel.DataAnnotations.Schema;

namespace BilethubApi.Api.Entities;

public class City
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public int CountryId { get; set; }
    public string Title { get; set; } = null!;

    public Country Country { get; set; } = null!;

    public List<District> Districts { get; set; } = null!;
}