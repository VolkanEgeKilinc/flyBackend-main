using AutoMapper;
using BilethubApi.Api.Application.EventOperations.Queries.GetEvents;
using BilethubApi.Api.Application.EventOperations.Commands.CreateEvent;
using BilethubApi.Api.Application.UserOperations.Commands.CreateUser;
using BilethubApi.Api.Entities;
using BilethubApi.Api.Application.EventOperations.Queries.GetEventDetail;
using BilethubApi.Api.Application.EventOperations.Queries.GetSuggestedEvents;
using BilethubApi.Api.Common.Model;
using BilethubApi.Api.Application.PlaceOperations.Commands.CreatePlace;
using BilethubApi.Api.Application.PlaceOperations.Queries.GetPlaces;
using BilethubApi.Api.Application.PlaceOperations.Queries.GetPlaceDetail;
using NetTopologySuite.Geometries;
using BilethubApi.Api.Application.ArtistOperations.Queries.GetArtists;
using BilethubApi.Api.Application.ArtistOperations.Queries.GetArtistDetail;
using BilethubApi.Api.Application.GenreOperations.Commands.CreateGenre;
using BilethubApi.Api.Application.GenreOperations.Queries.GetGenres;
using BilethubApi.Api.Application.OrganizerOperations.Queries.GetOrganizers;
using BilethubApi.Api.Application.PlaceGenreOperations.Commands.CreatePlaceGenre;
using BilethubApi.Api.Application.PlaceGenreOperations.Queries.GetPlaceGenres;
using BilethubApi.Api.Application.TicketCategoryOperations.Commands.CreateTicketCategory;
using BilethubApi.Api.Application.TicketCategoryOperations.Queries.GetTicketCategories;
using BilethubApi.Api.Application.TicketCategoryOperations.Queries.GetEventTicketCategories;
using BilethubApi.Api.Application.TicketCategoryOperations.Queries.GetAdminEventTicketCategories;
using BilethubApi.Api.Application.TicketOperations.Commands.CreateTicket;
using BilethubApi.Api.Application.TicketOperations.Queries.GetTicketsByEvent;
using BilethubApi.Api.Application.TicketOperations.Queries.GetTicketsByUser;
using BilethubApi.Api.Application.TicketOperations.Queries.GetTicketByToken;
using BilethubApi.Api.Application.PlaceCommentOperations.Queries.GetPlaceComments;
using BilethubApi.Api.Application.UserOperations.Queries.GetUserDetail;
using BilethubApi.Api.Application.ArtistCommentOperations.Queries.GetArtistComments;
using BilethubApi.Api.Application.ArtistFollowerOperations.Queries.GetArtistFollowers;
using BilethubApi.Api.Application.PlaceFollowerOperations.Queries.GetPlaceFollowers;
using BilethubApi.Api.Application.CouponOperations.Commands.CreateCoupon;
using BilethubApi.Api.Application.CouponOperations.Commands.UpdateCoupon;
using BilethubApi.Api.Application.SearchOperations.Queries.GetSearch;
using BilethubApi.Api.Enum;
using BilethubApi.Api.Application.EventOperations.Queries.GetAdminEventDetail;
using BilethubApi.Api.Application.EventCategoryOperations.Commands.CreateEventCategory;
using BilethubApi.Api.Application.EventCategoryOperations.Queries.GetEventCategories;
using BilethubApi.Api.Application.EventOperations.Queries.GetUpcomingEvents;
using BilethubApi.Api.Application.UserOperations.Queries.GetUsersBySearch;
using BilethubApi.Api.Application.TicketOperations.Commands.CreateGuestTicket;
using BilethubApi.Api.Application.TicketOperations.Queries.GetGuestTickets;
using BilethubApi.Api.Application.CouponOperations.Queries.GetCouponsByEvent;

namespace BilethubApi.Api.Common;

public class MappingProfile : Profile
{

    public MappingProfile()
    {
        // USER
        CreateMap<CreateUserModel, User>();
        CreateMap<User, GetUserDetailViewModel>();
        CreateMap<User, GetUsersBySearchViewModel>();
        // .ForMember(dest => dest.Image, opt => opt.MapFrom(src => ApiConstants.ProfileImageUrlPath + src.Image))
        // .ForMember(dest => dest.CoverImage, opt => opt.MapFrom(src => ApiConstants.CoverImageUrlPath + src.CoverImage));
        // CreateMap<User, UsersViewModel>();

        // PLACE
        CreateMap<CreatePlaceModel, Place>();
        CreateMap<Place, PlaceSubModel>();
        CreateMap<Place, GetPlacesViewModel>()
            .ForMember(dest => dest.PlaceGenre, opt => opt.MapFrom(src => src.PlaceGenre.Title))
            .ForMember(dest => dest.District, opt => opt.MapFrom(src => src.District.Title))
            .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City.Title));
        CreateMap<Place, GetPlaceDetailViewModel>()
            .ForMember(dest => dest.PlaceGenre, opt => opt.MapFrom(src => src.PlaceGenre.Title))
            .ForMember(dest => dest.FollowersCount, opt => opt.MapFrom(src => src.Followers.Count))
            .ForMember(dest => dest.CommentsCount, opt => opt.MapFrom(src => src.Comments.Count))
            .ForMember(dest => dest.District, opt => opt.MapFrom(src => src.District.Title))
            .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City.Title))
            .ForMember(dest => dest.Comments, opt => opt.MapFrom(src => src.Comments.TakeLast(1)))
            .ForMember(dest => dest.Events, opt => opt.MapFrom(src => src.Events.TakeLast(5)));

        // PLACE GENRE
        CreateMap<CreatePlaceGenreModel, PlaceGenre>();
        CreateMap<PlaceGenre, GetPlaceGenresViewModel>();

        // PLACE COMMENT
        CreateMap<PlaceComment, GetPlaceCommentsViewModel>()
            .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.User.Name} {src.User.Surname}"))
            .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.User.Image));

        // PLACE FOLLOWER
        CreateMap<PlaceFollower, GetPlaceFollowersViewModel>()
            .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.User.Name} {src.User.Surname}"))
            .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.User.Image));

        // ARTIST
        CreateMap<Artist, ArtistSubModel>();
        CreateMap<Artist, GetArtistsViewModel>()
            .ForMember(dest => dest.Genres, opt => opt.MapFrom(src => src.ArtistGenres.Select(g => g.Genre.Title)));
        CreateMap<Artist, GetArtistDetailViewModel>()
            .ForMember(dest => dest.Genres, opt => opt.MapFrom(src => src.ArtistGenres.Select(g => g.Genre.Title)))
            .ForMember(dest => dest.FollowersCount, opt => opt.MapFrom(src => src.Followers.Count))
            .ForMember(dest => dest.CommentsCount, opt => opt.MapFrom(src => src.Comments.Count))
            .ForMember(dest => dest.Comments, opt => opt.MapFrom(src => src.Comments.TakeLast(1)))
            .ForMember(dest => dest.Events, opt => opt.MapFrom(src => src.EventArtists.TakeLast(5).Select(a => a.Event)));

        // ARTIST COMMENT
        CreateMap<ArtistComment, GetArtistCommentsViewModel>()
            .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.User.Name} {src.User.Surname}"))
            .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.User.Image));

        // ARTIST FOLLOWER
        CreateMap<ArtistFollower, GetArtistFollowersViewModel>()
            .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.User.Name} {src.User.Surname}"))
            .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.User.Image));

        // ORGANIZER
        CreateMap<Organizer, GetOrganizersViewModel>()
            .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.User.Image))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.User.Name))
            .ForMember(dest => dest.Surname, opt => opt.MapFrom(src => src.User.Surname));


        // GENRE
        CreateMap<CreateGenreModel, Genre>();
        CreateMap<Genre, GetGenresViewModel>();

        // EVENT CATEGORY
        CreateMap<CreateEventCategoryModel, EventCategory>();
        CreateMap<EventCategory, GetEventCategoriesViewModel>();

        // EVENT
        CreateMap<CreateEventModel, Event>();
        CreateMap<Event, GetSuggestedEventsViewModel>()
            .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Title))
            .ForMember(dest => dest.Place, opt => opt.MapFrom(src => src.Place.Title))
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.TicketCategories.Count() == 0 ? "0" : $"{src.TicketCategories.Select(x => x.Price).Min()} - {src.TicketCategories.Select(x => x.Price).Max()}"));
        CreateMap<Event, GetUpcomingEventsViewModel>()
            .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Title))
            .ForMember(dest => dest.Place, opt => opt.MapFrom(src => src.Place.Title))
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.TicketCategories.Count() == 0 ? "0" : $"{src.TicketCategories.Select(x => x.Price).Min()} - {src.TicketCategories.Select(x => x.Price).Max()}"));
        CreateMap<Event, GetEventsViewModel>()
            .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Title))
            .ForMember(dest => dest.Place, opt => opt.MapFrom(src => src.Place.Title))
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.TicketCategories.Count() == 0 ? "0" : $"{src.TicketCategories.Select(x => x.Price).Min()} - {src.TicketCategories.Select(x => x.Price).Max()}"));
        CreateMap<Event, GetEventDetailViewModel>()
            .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Title))
            .ForMember(dest => dest.Place, opt => opt.MapFrom(src => src.Place))
            .ForMember(dest => dest.Organizer, opt => opt.MapFrom(src => src.Organizer))
            .ForMember(dest => dest.Artists, opt => opt.MapFrom(src => src.EventArtists.Select(x => x.Artist)))
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.TicketCategories.Count() == 0 ? "0" : $"{src.TicketCategories.Select(x => x.Price).Min()} - {src.TicketCategories.Select(x => x.Price).Max()}"));
        CreateMap<Event, GetAdminEventDetailViewModel>()
            .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Title))
            .ForMember(dest => dest.Place, opt => opt.MapFrom(src => src.Place))
            .ForMember(dest => dest.Artists, opt => opt.MapFrom(src => src.EventArtists.Select(x => x.ArtistId)))
            .ForMember(dest => dest.Views, opt => opt.MapFrom(src => 5))
            .ForMember(dest => dest.CreatedCoupon, opt => opt.MapFrom(src => src.Coupons.Count))
            .ForMember(dest => dest.GuestCount, opt => opt.MapFrom(src => src.TicketCategories.SelectMany(tc => tc.Tickets).ToList().Where(ticket => ticket.Type == TicketType.Guest).Count()))
            .ForMember(dest => dest.Guests, opt => opt.MapFrom(src => src.TicketCategories.SelectMany(tc => tc.Tickets).ToList().Where(ticket => ticket.Type == TicketType.Guest).Take(5).Select(ticket => new
            {
                Id = ticket.UserId,
                TicketId = ticket.Id,
                Name = ticket.User.Name,
                Surname = ticket.User.Surname,
                Date = ticket.Date
            })))
            .ForMember(dest => dest.TicketsSold, opt => opt.MapFrom(src => src.TicketCategories.Select(tc => tc.Tickets.Where(ticket => ticket.Status == TicketStatus.Paid).Count()).Sum()))
            .ForMember(dest => dest.TotalTickets, opt => opt.MapFrom(src => src.TicketCategories.Select(tc => tc.Quota).Sum()))
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => $"{src.TicketCategories.Select(x => x.Price).Min()} - {src.TicketCategories.Select(x => x.Price).Max()}"));

        // COMMON
        CreateMap<Point, LocationModel>()
            .ForMember(dest => dest.Longitude, opt => opt.MapFrom(src => src.X))
            .ForMember(dest => dest.Latitude, opt => opt.MapFrom(src => src.Y));
        CreateMap<LocationModel, Point>()
            .ForMember(dest => dest.X, opt => opt.MapFrom(src => src.Longitude))
            .ForMember(dest => dest.Y, opt => opt.MapFrom(src => src.Latitude));

        // TICKET
        CreateMap<CreateTicketModel, Ticket>();
        CreateMap<CreateGuestTicketModel, Ticket>();
        CreateMap<Ticket, GetTicketsByEventTicketViewModel>()
            .ForMember(dest => dest.Owner, opt => opt.MapFrom(src => $"{src.User.Name} {src.User.Surname}"));
        CreateMap<Ticket, GetTicketsByUserViewModel>()
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.TicketCategory.Event.Title))
            .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.TicketCategory.Event.Place.Address))
            .ForMember(dest => dest.Place, opt => opt.MapFrom(src => src.TicketCategory.Event.Place.Title))
            .ForMember(dest => dest.District, opt => opt.MapFrom(src => src.TicketCategory.Event.Place.District.Title))
            .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.TicketCategory.Event.Place.City.Title))
            .ForMember(dest => dest.Start, opt => opt.MapFrom(src => src.TicketCategory.Event.Start))
            .ForMember(dest => dest.End, opt => opt.MapFrom(src => src.TicketCategory.Event.End));
        CreateMap<Ticket, GetTicketByTokenViewModel>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.User.Name))
            .ForMember(dest => dest.Surname, opt => opt.MapFrom(src => src.User.Surname))
            .ForMember(dest => dest.TicketCategory, opt => opt.MapFrom(src => src.TicketCategory.Title));
        CreateMap<Ticket, GetGuestTicketsViewModel>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.UserId))
            .ForMember(dest => dest.TicketId, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.User.Name))
            .ForMember(dest => dest.Surname, opt => opt.MapFrom(src => src.User.Surname))
            .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date));

        // TICKET CATEGORY
        CreateMap<CreateTicketCategoryModel, TicketCategory>();
        CreateMap<TicketCategory, GetTicketCategoriesViewModel>()
            .ForMember(dest => dest.Available, opt => opt.MapFrom(src => src.Quota - src.Tickets.Count));
        CreateMap<TicketCategory, GetEventTicketCategoriesViewModel>()
            .ForMember(dest => dest.Available, opt => opt.MapFrom(src => src.Quota - src.Tickets.Count));
        CreateMap<TicketCategory, GetAdminEventTicketCategoriesViewModel>()
            .ForMember(dest => dest.Available, opt => opt.MapFrom(src => src.Quota - src.Tickets.Count));

        // COUPON
        CreateMap<CreateCouponModel, Coupon>();
        CreateMap<UpdateCouponModel, Coupon>();
        CreateMap<Coupon, GetCouponsByEventViewModel>()
            .ForMember(dest => dest.Used, opt => opt.MapFrom(src => src.Tickets.Count))
            .ForMember(dest => dest.TotalDiscount, opt => opt.MapFrom(src => src.Tickets.Where(t => t.CouponId != null).Select(t => t.Coupon!.DiscountType == DiscountType.Amount ? t.Coupon.Discount : t.Price / 100 * t.Coupon.Discount)))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status ? src.Date > DateTime.Now : false));

        // SEARCH
        CreateMap<Event, GetSearchViewModel>()
            .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Title))
            .ForMember(dest => dest.Type, opt => opt.MapFrom(src => SearchType.Event));

        CreateMap<Place, GetSearchViewModel>()
            .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.PlaceGenre.Title))
            .ForMember(dest => dest.Type, opt => opt.MapFrom(src => SearchType.Place));

        CreateMap<Artist, GetSearchViewModel>()
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => $"{src.Name} {src.Surname}"))
            .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => string.Join(",", src.ArtistGenres.Select(g => g.Genre.Title))))
            .ForMember(dest => dest.Type, opt => opt.MapFrom(src => SearchType.Artist));

        // CreateMap<Organizer, GetSearchViewModel>()
        //     .ForMember(dest => dest.Title, opt => opt.MapFrom(src => $"{src.User.Name} {src.User.Surname}"))
        //     .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => ""))
        //     .ForMember(dest => dest.Type, opt => opt.MapFrom(src => SearchType.Organizer));
    }
}