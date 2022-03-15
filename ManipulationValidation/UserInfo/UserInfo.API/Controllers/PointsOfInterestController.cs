using System.Drawing;
using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
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

        [HttpGet("{pointofinterestid}", Name = "GetPointOfInterest")]
        public ActionResult<PointOfInterestDto> GetPointOfInterest(
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

        [HttpPost]
        public ActionResult<PointOfInterestDto> CreatePointOfInterest(
            int userId,
            PointOfInterestForCreationDto pointOfInterest)
        {
            //APIControllerAttribute also automatically deserializes to PointOfInterest.
            //API Controller attribute automatically checks this.
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest();
            //}

            var user = UsersDataStore.Current.Users.FirstOrDefault(u => u.Id == userId);

            if (user == null)
                return NotFound();

            //demo purposes - to be improved
            var maxPointOfInterestId = UsersDataStore.Current.Users.SelectMany(
                c => c.PointsOfInterest).Max(p => p.Id);

            var finalPointOfInterest = new PointOfInterestDto()
            {
                Id = ++maxPointOfInterestId,
                Name = pointOfInterest.Name,
                Description = pointOfInterest.Description
            };

            user.PointsOfInterest.Add(finalPointOfInterest);

            return CreatedAtRoute("GetPointOfInterest",
                new
                {
                    userId = userId,
                    pointofinterestid = finalPointOfInterest.Id
                }, finalPointOfInterest);
        }


        [HttpPut("{pointofinterestid}")]
        public ActionResult<PointOfInterestDto> UpdatePointOfInterest(
            int userId,
            int pointOfInterestId,
            PointOfInterestForUpdateDto pointOfInterest)
        {
            
            var user = UsersDataStore.Current.Users
                .FirstOrDefault(u => u.Id == userId);

            if (user == null)
            {
                return NotFound();
            }

            //find point of interest
            var pointOfInterestFromStore = user.PointsOfInterest
                .FirstOrDefault(u => u.Id == pointOfInterestId);

            if (pointOfInterestFromStore == null)
            {
                return NotFound();
            }

            //find point of interest
            pointOfInterestFromStore.Name = pointOfInterest.Name;
            pointOfInterestFromStore.Description = pointOfInterest.Description;

            return NoContent();
        }

        [HttpPatch("{pointofinterestid}")]
        public ActionResult PartiallyUpdatePointOfInterest(
            int userId, int pointOfInterestId,
            JsonPatchDocument<PointOfInterestForUpdateDto> patchDocument)
        {
            var user = UsersDataStore.Current.Users.FirstOrDefault(u => u.Id == userId);

            if (user == null)
                return NotFound();

            //find point of interest
            var pointOfInterestFromStore = user.PointsOfInterest
                .FirstOrDefault(u => u.Id == pointOfInterestId);

            if (pointOfInterestFromStore == null)
            {
                return NotFound();
            }

            var pointOfInterestToPatch =
                new PointOfInterestForUpdateDto()
                {
                    Name = pointOfInterestFromStore.Name,
                    Description = pointOfInterestFromStore.Description
                };

            //Pass the model state if clients make errors
            patchDocument.ApplyTo(pointOfInterestToPatch, ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!TryValidateModel(pointOfInterestToPatch))
            {
                return BadRequest(ModelState);
            }

            pointOfInterestFromStore.Name = pointOfInterestToPatch.Name;
            pointOfInterestFromStore.Description = pointOfInterestToPatch.Description;

            return NoContent();
        }

        [HttpDelete("{pointOfInterestId}")]
        public ActionResult DeletePointOfInterest(int userId, int pointOfInterestId)
        {
            var user = UsersDataStore.Current.Users
                .FirstOrDefault(u => u.Id == userId);

            if (user == null)
            {
                return NotFound();
            }
            var pointOfInterestFromStore = user.PointsOfInterest
                .FirstOrDefault(u => u.Id == pointOfInterestId);

            if (pointOfInterestFromStore == null)
            {
                return NotFound();
            }

            user.PointsOfInterest.Remove(pointOfInterestFromStore);
            return NoContent();
        }
    }
}
