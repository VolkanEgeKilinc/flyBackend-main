using System.ComponentModel.DataAnnotations.Schema;

namespace BilethubApi.Api.Entities;

public class Country
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Title { get; set; } = null!;

    public List<City> Cities { get; set; } = null!;
}