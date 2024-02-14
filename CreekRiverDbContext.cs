using Microsoft.EntityFrameworkCore;
using CreekRiver.Models;

public class CreekRiverDbContext : DbContext
{

    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<UserProfile> UserProfiles { get; set; }
    public DbSet<Campsite> Campsites { get; set; }
    public DbSet<CampsiteType> CampsiteTypes { get; set; }

    public CreekRiverDbContext(DbContextOptions<CreekRiverDbContext> context) : base(context)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // seed data with campsite types
        modelBuilder.Entity<CampsiteType>().HasData(new CampsiteType[]
        {
                new CampsiteType {Id = 1, CampsiteTypeName = "Tent", FeePerNight = 15.99M, MaxReservationDays = 7},
                new CampsiteType {Id = 2, CampsiteTypeName = "RV", FeePerNight = 26.50M, MaxReservationDays = 14},
                new CampsiteType {Id = 3, CampsiteTypeName = "Primitive", FeePerNight = 10.00M, MaxReservationDays = 3},
                new CampsiteType {Id = 4, CampsiteTypeName = "Hammock", FeePerNight = 12M, MaxReservationDays = 7}
        });

        modelBuilder.Entity<Campsite>().HasData(new Campsite[]
        {
            new Campsite {Id = 1, CampsiteTypeId = 1, Nickname = "Barred Owl", ImageUrl="https://tnstateparks.com/assets/images/content-images/campgrounds/249/colsp-area2-site73.jpg"},
            new Campsite {Id = 2, CampsiteTypeId = 1, Nickname = "Bledsoe Creek", ImageUrl="https://tnstateparks.com/assets/images/content-images/73/bledsoe_creek_2017_tennessee_photographs__0001__full.jpg"},
            new Campsite {Id = 3, CampsiteTypeId = 1, Nickname = "Edgar Evins", ImageUrl="https://tnstateparks.com/assets/images/content-images/86/edgar-evins-office__full.jpg"},
            new Campsite {Id = 4, CampsiteTypeId = 1, Nickname = "Harrison Bay", ImageUrl="https://tnstateparks.com/assets/images/content-images/91/harrison_bay3__full.jpg"},
            new Campsite {Id = 5, CampsiteTypeId = 1, Nickname = "Long Hunter", ImageUrl="https://tnstateparks.com/assets/images/content-images/96/long_hunter5__full.jpg"}
        });

        modelBuilder.Entity<UserProfile>().HasData(new UserProfile[]
        {
            new UserProfile {Id = 1, FirstName = "Ionni", LastName = "Sanni", Email = "ionnisanni@email.io"}
        });

        modelBuilder.Entity<Reservation>().HasData(new Reservation[]
        {
            new Reservation {Id = 1, CampsiteId = 3, UserProfileId = 1, CheckinDate = new DateTime(2024, 01, 22), CheckoutDate = new DateTime(2024, 02, 01)}
        });
    }
}