using System.ComponentModel.DataAnnotations.Schema;
using BilethubApi.Api.Enum;

namespace BilethubApi.Api.Entities;

public class Event
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public int PlaceId { get; set; }
    public int OrganizerId { get; set; }
    public int GenreId { get; set; }
    public int EventCategoryId { get; set; }
    public string Image { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public DateTime Start { get; set; }
    public DateTime? Opening { get; set; }
    public DateTime End { get; set; }
    public bool HomePageVisibility { get; set; } = true;
    public bool TicketTransfer { get; set; } = true;
    public EventStatus Status { get; set; } = EventStatus.WaitingForApprovement;


    public Place Place { get; set; } = null!;
    public Organizer Organizer { get; set; } = null!;
    public Genre Genre { get; set; } = null!;
    public EventCategory EventCategory { get; set; } = null!;

    public List<Coupon> Coupons { get; set; } = null!;
    public List<EventArtist> EventArtists { get; set; } = null!;
    public List<TicketCategory> TicketCategories { get; set; } = null!;
    public List<EventLike> EventLikes { get; set; } = null!;
    public List<EventReminder> EventReminders { get; set; } = null!;
}