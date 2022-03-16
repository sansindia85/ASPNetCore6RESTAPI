using Microsoft.EntityFrameworkCore;
using UserInfo.API.Entities;

namespace UserInfo.API.DbContexts
{
    //DbContext ensures that the properties are initialized not null after leaving the 
    //base constructor. So the warnings can be ignored.
    //To avoid warning, use null forgiving operator.
    public class UserInfoContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<PointOfInterest> PointsOfInterest { get; set; } = null!;

        public UserInfoContext(DbContextOptions<UserInfoContext> options) 
            : base(options)
        {

        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseNpgsql("Host=localhost:5435;Database=RestData;Username=postgres;Password=sandeep");
        //    base.OnConfiguring(optionsBuilder);
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasData(
                 new User("Sandeep Kandula")
                 {
                     Id = 1,                     
                     Description = "Passionate backend guy.",
                 },
                 new User("Kiran")
                 {
                     Id = 2,
                     Description = "Passionate backend guy."
                 },
                 new User("Sanjeev")
                 {
                     Id = 3,
                     Description = "Passionate testing guy."
                 });


            modelBuilder.Entity<PointOfInterest>()
                .HasData(                
                 new PointOfInterest("DotNet6")
                 {
                     Id = 1,
                     UserId = 1,
                     Description = "The latest .Net"
                 },
                 new PointOfInterest("Andorid12")
                 {
                     Id = 2,
                     UserId = 1,
                     Description = "The latest Android"
                 },
                 new PointOfInterest("StencilJS")
                 {
                     Id = 3,
                     UserId = 2,
                     Description = "Reusable web components."
                 },
                 new PointOfInterest("TypeScript")
                 {
                     Id = 4,
                     UserId = 2,                     
                     Description = "TypeScript is a strongly typed programming language that builds on JavaScript."
                 },
                 new PointOfInterest("JMeter")
                 {
                     Id = 5,
                     UserId = 3,                     
                     Description = "Designed to load test functional behavior and measure performance."
                 },
                 new PointOfInterest("Selenium IDE")
                 {
                     Id = 6,
                     UserId = 3,
                     Description = "Open source record and playback test automation for the web."
                 });

            base.OnModelCreating(modelBuilder);
        }
    }
}
