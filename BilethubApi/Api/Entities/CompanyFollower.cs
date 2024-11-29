using System.ComponentModel.DataAnnotations.Schema;

namespace BilethubApi.Api.Entities;

public class CompanyFollowers
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public int UserId { get; set; }
    public int CompanyId { get; set; }
    public DateTime Date { get; set; }

    public CompanyComment Company { get; set; } = null!;
    public User User { get; set; } = null!;
}