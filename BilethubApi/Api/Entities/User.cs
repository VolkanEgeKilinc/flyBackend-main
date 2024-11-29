using System.ComponentModel.DataAnnotations.Schema;
using BilethubApi.Api.Enum;

namespace BilethubApi.Api.Entities;

public class User
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string? Image { get; set; }
    public string? CoverImage { get; set; }
    public string Job { get; set; } = null!;
    public string Bio { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string Surname { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public Gender Gender { get; set; }
    public bool Status { get; set; } = true;
    public string? RefreshToken { get; set; } = null!;
    public DateTime? RefreshTokenExpireDate { get; set; }

    public Organizer? Organizer { get; set; }
    public List<Coupon> Coupons { get; set; } = null!;
    public List<Ticket> Tickets { get; set; } = null!;
    public List<EventLike> EventLikes { get; set; } = null!;
    public List<PlaceFollower> PlaceFollowers { get; set; } = null!;
    public List<PlaceComment> PlaceComments { get; set; } = null!;
}