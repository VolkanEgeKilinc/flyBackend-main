using System.ComponentModel.DataAnnotations.Schema;

namespace BilethubApi.Api.Entities;

public class EventCategory
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public bool Status { get; set; }


    public List<Event> Events { get; set; } = null!;
}