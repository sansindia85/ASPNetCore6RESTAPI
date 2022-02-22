using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserInfo.API.Models;

namespace UserInfo.API.Controllers
{
    [Route("api/users/{userId}/pointsofinterest")]
    [ApiController]
    public class PointsOfInterestController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<PointOfInterestDto>> GetPointsOfInterest(int userId)
        {
            var user = UsersDataStore.Current.Users.FirstOrDefault(u => u.Id == userId);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user.PointsOfInterest);
        }

        [HttpGet("{pointofinterestid}")]
        public ActionResult<IEnumerable<PointOfInterestDto>> GetPointOfInterest(
            int userId, int pointOfInterestId)
        {
            var user = UsersDataStore.Current.Users.FirstOrDefault(u => u.Id == userId);

            if (user == null)
            {
                return NotFound();
            }

            //find point of interest
            var pointOfInterest = user.PointsOfInterest
                .FirstOrDefault(p => p.Id == pointOfInterestId);

            if (pointOfInterest == null)
            {
                return NotFound();
            }

            return Ok(pointOfInterest);
        }

    }
}
