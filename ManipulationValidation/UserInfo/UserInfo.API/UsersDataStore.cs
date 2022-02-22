using UserInfo.API.Models;

namespace UserInfo.API
{
    public class UsersDataStore
    {
        public List<UserDto> Users { get; set; }

        public static UsersDataStore Current { get; } = new UsersDataStore();

        public UsersDataStore()
        {
            //init dummy data
            Users = new List<UserDto>()
            {
                new UserDto()
                {
                    Id = 1,
                    Name = "Sandeep Kandula",
                    Description = "Passionate backend guy.",
                    PointsOfInterest = new List<PointOfInterestDto>()
                    {
                        new PointOfInterestDto()
                        {
                            Id = 1,
                            Name = "DotNet6",
                            Description = "The latest .Net"
                        },
                        new PointOfInterestDto()
                        {
                            Id = 2,
                            Name = "Andorid12",
                            Description = "The latest Andorid"
                        }
                    }
                },
                new UserDto()
                {
                    Id = 2,
                    Name = "Kiran",
                    Description = "Passionate backend guy.",
                    PointsOfInterest = new List<PointOfInterestDto>()
                    {
                        new PointOfInterestDto()
                        {
                            Id = 3,
                            Name = "StencilJS",
                            Description = "Reusable web components."
                        },
                        new PointOfInterestDto()
                        {
                            Id = 4,
                            Name = "TypeScript",
                            Description = "TypeScript is a strongly typed programming language that builds on JavaScript."
                        }
                    }
                },
                new UserDto()
                {
                    Id =3,
                    Name = "Sanjeev",
                    Description = "Passionate testing guy.",
                    PointsOfInterest = new List<PointOfInterestDto>()
                    {
                        new PointOfInterestDto()
                        {
                            Id = 5,
                            Name = "JMeter",
                            Description = "Designed to load test functional behavior and measure performance."
                        },
                        new PointOfInterestDto()
                        {
                            Id = 6,
                            Name = "Selenium IDE",
                            Description = "Open source record and playback test automation for the web."
                        }
                    }
                }
            };
        }
    }
}
