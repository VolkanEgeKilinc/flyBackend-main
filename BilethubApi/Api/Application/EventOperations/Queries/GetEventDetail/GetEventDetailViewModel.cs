using BilethubApi.Api.Application.ArtistOperations.Queries.GetArtists;
using BilethubApi.Api.Application.OrganizerOperations.Queries.GetOrganizers;
using BilethubApi.Api.Application.TicketCategoryOperations.Queries.GetEventTicketCategories;
using BilethubApi.Api.Common.Model;
using BilethubApi.Api.Enum;

namespace BilethubApi.Api.Application.EventOperations.Queries.GetEventDetail;

public class GetEventDetailViewModel
{
    public int Id { get; set; }
    public string Image { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Genre { get; set; } = null!;
    public string Price { get; set; } = null!;
    public DateTime Start { get; set; }
    public DateTime? Opening { get; set; }
    public DateTime End { get; set; }
    public int Likes { get; set; }
    public bool HasReminder { get; set; }
    public EventStatus Status { get; set; }

    public PlaceSubModel Place { get; set; } = null!;
    public GetOrganizersViewModel Organizer { get; set; } = null!;
    public List<GetArtistsViewModel> Artists { get; set; } = null!;
    public List<GetEventTicketCategoriesViewModel> TicketCategories { get; set; } = null!;
}