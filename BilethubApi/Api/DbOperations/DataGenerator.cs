using BilethubApi.Api.Entities;
using BilethubApi.Api.Enum;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite.Geometries;

namespace BilethubApi.Api.DbOperations;

public class DataGenerator
{

    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new BilethubDbContext(serviceProvider.GetRequiredService<DbContextOptions<BilethubDbContext>>()))
        {
            if (context.Users.Any())
                return;

            context.Countries.Add(new Country
            {
                Title = "Türkiye"
            });

            context.Cities.AddRange(
                new City
                {
                    CountryId = 1,
                    Title = "İzmir"
                },
                new City
                {
                    CountryId = 1,
                    Title = "Muğla"
                }
            );

            context.Districts.AddRange(
                new District
                {
                    CityId = 1,
                    Title = "Bornova"
                },
                new District
                {
                    CityId = 1,
                    Title = "Buca"
                },
                new District
                {
                    CityId = 2,
                    Title = "Bodrum"
                },
                new District
                {
                    CityId = 2,
                    Title = "Marmaris"
                }
            );

            context.Users.Add(new User
            {
                Image = "",
                CoverImage = "",
                Job = "Mobile Application Developer",
                Bio = "This is how we do!",
                Email = "volkan@gmail.com",
                Password = "4780h64h",
                Name = "VOLKAN EGE KILINÇ",
                Surname = "Balcılar",
                Phone = "5382577453",
                Gender = Gender.Male,
            });

            context.PlaceGenres.AddRange(
                new PlaceGenre
                {
                    Title = "izmir"
                },
                new PlaceGenre
                {
                    Title = "ADNAN MENDERES HAVALİMANI"
                }
            );

            context.Places.AddRange(
                new Place
                {
                    PlaceGenreId = 1,
                     Image = "https://www.jpg",
                    Title = "İtalya Direkt Uçuş",
                    Description = "",
                    CityId = 1,
                    CountryId = 1,
                    Address = "",
                    Location = new Point(0, 0)
                },
                new Place
                {
                    PlaceGenreId = 1,
                    Image = "https://www.jpg",
                    Title = "İtalya Direkt Uçuş",
                    Description = "",
                    DistrictId = 2,
                    CityId = 2,
                    CountryId = 1,
                    Address = "",
                    Location = new Point(0, 0)
                }
            );


            context.PlaceFollowers.AddRange(
                new PlaceFollower
                {
                    UserId = 1,
                    PlaceId = 1,
                    Date = DateTime.Now
                },
                new PlaceFollower
                {
                    UserId = 1,
                    PlaceId = 2,
                    Date = DateTime.Now
                }
            );

            context.PlaceComments.AddRange(
               new PlaceComment
               {
                   UserId = 1,
                   PlaceId = 1,
                   Content = "Harika ",
                   Date = DateTime.Now
               },
               new PlaceComment
               {
                   UserId = 1,
                   PlaceId = 2,
                   Content = "Güzel",
                   Date = DateTime.Now
               }
           );

            context.Organizers.AddRange(
                new Organizer
                {
                    UserId = 1
                    // Image = "https://cdn.armut.com/UserPics/tr:w-80,h-80/67078a2c-1198-489e-8565-50d5ede04e65.jpeg",
                    // Name = "Ertan",
                    // Surname = "Öztürk",
                }
                // ,new Organizer
                // {
                //     Image = "https://cdn.armut.com/UserPics/tr:w-80,h-80/af5f6f07-ab6f-4e5f-bfaa-60d5c282bf4f.jpeg",
                //     Name = "Zehra",
                //     Surname = "Mordag",
                // }
            );

            context.Genres.AddRange(
                new Genre
                {
                    Title = "ROME",
                    Status = true
                },
                new Genre
                {
                    Title = "PARIS",
                    Status = true
                }
            );

            context.EventCategories.AddRange(
                new EventCategory
                {
                    Title = "ITALY",
                    Status = true
                },
                new EventCategory
                {
                    Title = "IZMIR",
                    Status = true
                }
            );

            context.Company.AddRange(
               new Company
               {
                   Image = "",
                   Name = "PEGASUS",
                   Surname = "",
                   Description = ""
               },
               new Company
               {
                   Image = "",
                   Name = "THY",
                   Surname = "",
                   Description = "."
               }
           );

       
            context.Events.AddRange(
                new Event
                {
                    PlaceId = 1,
                    OrganizerId = 1,
                    GenreId = 2,
                    EventCategoryId = 1,
                    Image = "",
                    Title = "",
                    Description = ".",
                    Opening = DateTime.Now.AddDays(0),
                    Start = DateTime.Now.AddDays(0).AddHours(1),
                    End = DateTime.Now.AddDays(0).AddHours(5),
                    Status = EventStatus.Approved
                },
                new Event
                {
                    PlaceId = 2,
                    OrganizerId = 1,
                    GenreId = 2,
                    EventCategoryId = 2,
                    Image = "",
                    Title = "",
                    Description = "",
                    Opening = DateTime.Now.AddDays(0),
                    Start = DateTime.Now.AddDays(5).AddHours(3),
                    End = DateTime.Now.AddDays(5).AddHours(7),
                    Status = EventStatus.Approved
                }
            );

            context.EventArtists.AddRange(
                new EventArtist
                {
                    ArtistId = 1,
                    EventId = 1
                },
                new EventArtist
                {
                    ArtistId = 2,
                    EventId = 1
                },
                new EventArtist
                {
                    ArtistId = 1,
                    EventId = 2
                },
                new EventArtist
                {
                    ArtistId = 2,
                    EventId = 2
                }
            );

            context.TicketCategories.AddRange(
                new TicketCategory
                {
                    EventId = 1,
                    Title = "VIP",
                    Quota = 100,
                    Price = 55,
                    Status = true
                },
                new TicketCategory
                {
                    EventId = 1,
                    Title = "Koltuk",
                    Quota = 50,
                    Price = 90,
                    Status = true
                },
                new TicketCategory
                {
                    EventId = 2,
                    Title = "EKONOMI",
                    Quota = 300,
                    Price = 55,
                    Status = true
                },
                new TicketCategory
                {
                    EventId = 2,
                    Title = "Koltuk",
                    Quota = 100,
                    Price = 90
                }
            );

            context.Tickets.AddRange(
                new Ticket
                {
                    UserId = 1,
                    TicketCategoryId = 1,
                    Token = "03EBFC2D40DB30128BCCFCEA3AA3E32ABD00335D2054F06631F31FE711A3BE58",
                    Date = DateTime.Now,
                    Price = 55,
                    Status = TicketStatus.Paid,
                    Type = TicketType.Payment,
                    CouponId = 2
                },
                new Ticket
                {
                    UserId = 1,
                    TicketCategoryId = 2,
                    Token = "17F8AF97AD4A7F7639A4C9171D5185CBAFB85462877A4746C21BDB0A4F940CA0",
                    Date = DateTime.Now,
                    Price = 55,
                    Status = TicketStatus.Paid,
                    Type = TicketType.Payment,
                    CouponId = 1
                },
                new Ticket
                {
                    UserId = 1,
                    TicketCategoryId = 2,
                    Token = "17F8AF97AD4A7F7639A4C9171D5185CBAFB85462877A4746C21BDB0A4F940CA0",
                    Date = DateTime.Now,
                    Price = 55,
                    Status = TicketStatus.Paid,
                    Type = TicketType.Payment,
                    CouponId = 1
                }
            );

            context.Coupons.AddRange(
                new Coupon
                {
                    EventId = 1,
                    Title = "Yeni Yıl Kuponu",
                    Code = "YENIYIL",
                    Quota = 100,
                    Date = DateTime.Now.AddDays(15),
                    Discount = 10,
                    DiscountType = DiscountType.Percentage
                },
                new Coupon
                {
                    EventId = 1,
                    Title = "Hoşgeldin Kuponu",
                    Code = "HOSGELDIN",
                    Quota = 100,
                    Date = DateTime.Now.AddDays(10),
                    Discount = 20,
                    DiscountType = DiscountType.Amount,
                    Status = false
                }
            );

            context.SaveChanges();
        }
    }
}