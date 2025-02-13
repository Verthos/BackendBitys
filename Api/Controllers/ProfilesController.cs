using Core.Entities;
using Core.Interfaces.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Bitys.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfilesController : ControllerBase
    {
        private readonly IProfileRepository _db;

        public ProfilesController(IProfileRepository db)
        {
            _db = db;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Profile>> GetProfiles()
        {
            try
            {
                IEnumerable<Profile> profiles = _db.GetAll();
                return Ok(profiles);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

    }

}