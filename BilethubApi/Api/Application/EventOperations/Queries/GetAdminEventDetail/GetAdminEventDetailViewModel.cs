using BilethubApi.Api.Application.ArtistOperations.Queries.GetArtists;
using BilethubApi.Api.Common.Model;
using BilethubApi.Api.Enum;

namespace BilethubApi.Api.Application.EventOperations.Queries.GetAdminEventDetail;

public class GetAdminEventDetailViewModel
{
    public int Id { get; set; }
    public int GenreId { get; set; }
    public int EventCategoryId { get; set; }
    public string Image { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Genre { get; set; } = null!;
    public string Price { get; set; } = null!;
    public DateTime Start { get; set; }
    public DateTime? Opening { get; set; }
    public DateTime End { get; set; }
    public EventStatus Status { get; set; }
    public int Views { get; set; }
    public int CreatedCoupon { get; set; }
    public int TicketsSold { get; set; }
    public int TotalTickets { get; set; }
    public int GuestCount { get; set; }
    public bool HomePageVisibility { get; set; }
    public bool TicketTransfer { get; set; }

    public PlaceSubModel Place { get; set; } = null!;
    public List<int> Artists { get; set; } = null!;
    public List<Object> Guests { get; set; } = null!;
    public List<Object> Coupons { get; set; } = null!;
}