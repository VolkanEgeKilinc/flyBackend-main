using BilethubApi.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace BilethubApi.Api.DbOperations;

public class BilethubDbContext : DbContext
{
    public BilethubDbContext(DbContextOptions<BilethubDbContext> options) : base(options) { }


    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Company> Company { get; set; } = null!;
    public DbSet<CompanyGenre> CompanyGenres { get; set; } = null!;
    public DbSet<CompanyFollowers> CompanyFollowers { get; set; } = null!;
    public DbSet<CompanyComment> CompanyComments { get; set; } = null!;
    public DbSet<Event> Events { get; set; } = null!;
    public DbSet<EventCategory> EventCategories { get; set; } = null!;
    public DbSet<EventArtist> EventArtists { get; set; } = null!;
    public DbSet<EventLike> EventLikes { get; set; } = null!;
    public DbSet<EventReminder> EventReminders { get; set; } = null!;
    public DbSet<Genre> Genres { get; set; } = null!;
    public DbSet<Organizer> Organizers { get; set; } = null!;
    public DbSet<Place> Places { get; set; } = null!;
    public DbSet<PlaceGenre> PlaceGenres { get; set; } = null!;
    public DbSet<PlaceFollower> PlaceFollowers { get; set; } = null!;
    public DbSet<PlaceComment> PlaceComments { get; set; } = null!;
    public DbSet<Ticket> Tickets { get; set; } = null!;
    public DbSet<TicketCategory> TicketCategories { get; set; } = null!;
    public DbSet<Coupon> Coupons { get; set; } = null!;
    public DbSet<District> Districts { get; set; } = null!;
    public DbSet<City> Cities { get; set; } = null!;
    public DbSet<Country> Countries { get; set; } = null!;

    public override int SaveChanges()
    {
        return base.SaveChanges();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // modelBuilder.Entity<EventArtist>()
        //     .HasKey(bc => new { bc.EventId, bc.ArtistId });
        // modelBuilder.Entity<EventArtist>()
        //     .HasOne(bc => bc.Event)
        //     .WithMany(b => b.Artists)
        //     .HasForeignKey(bc => bc.EventId);
        // modelBuilder.Entity<EventArtist>()
        //     .HasOne(bc => bc.Artist)
        //     .WithMany(c => c.Events)
        //     .HasForeignKey(bc => bc.ArtistId);
    }
}