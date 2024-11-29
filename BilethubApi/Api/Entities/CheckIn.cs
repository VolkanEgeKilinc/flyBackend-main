using System.ComponentModel.DataAnnotations.Schema;

namespace BilethubApi.Api.Entities;

public class District
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public int CityId { get; set; }
    public string Title { get; set; } = null!;

    public City City { get; set; } = null!;
}