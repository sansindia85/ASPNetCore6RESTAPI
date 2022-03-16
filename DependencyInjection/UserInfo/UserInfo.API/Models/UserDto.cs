namespace UserInfo.API.Models
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }

        public int NumberOfPointsOfInterest
        {
            get
            {
                return PointsOfInterest.Count;
            }
        }

        //Good idea to have an empty collection
        //To avoid null reference issues
        public ICollection<PointOfInterestDto> PointsOfInterest { get; set; }
            = new List<PointOfInterestDto>();
    }
}
