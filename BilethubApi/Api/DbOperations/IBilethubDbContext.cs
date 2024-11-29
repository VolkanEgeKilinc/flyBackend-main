using BilethubApi.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace BilethubApi.Api.DbOperations;

public interface IBilethubDbContext
{

    public DbSet<User> Users { get; set; }
    public DbSet<Company> Company { get; set; }
    public DbSet<CompanyGenre> CompanyGenres { get; set; }
    public DbSet<Company> CompanyFollowers { get; set; }
    public DbSet<CompanyComment> CompanyComments { get; set; }
    public DbSet<Event> Events { get; set; }
    public DbSet<EventCategory> EventCategories { get; set; }
    public DbSet<EventArtist> EventArtists { get; set; }
    public DbSet<EventLike> EventLikes { get; set; }
    public DbSet<EventReminder> EventReminders { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Organizer> Organizers { get; set; }
    public DbSet<Place> Places { get; set; }
    public DbSet<PlaceGenre> PlaceGenres { get; set; }
    public DbSet<PlaceFollower> PlaceFollowers { get; set; }
    public DbSet<PlaceComment> PlaceComments { get; set; }
    public DbSet<Ticket> Tickets { get; set; }
    public DbSet<TicketCategory> TicketCategories { get; set; }
    public DbSet<Coupon> Coupons { get; set; }
    public DbSet<District> Districts { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<Country> Countries { get; set; }
    object FlyComments { get; set; }

    int SaveChanges();

}