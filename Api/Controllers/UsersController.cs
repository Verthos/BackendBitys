using Core.Entities;
using Core.Interfaces.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Bitys.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _db;

        public UsersController(IUserRepository db)
        {
            _db = db;
        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> GetUsers()
        {
            try
            {
                IEnumerable<User> users = _db.GetAll();
                return Ok(users);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("{id}")]
        public ActionResult<User> GetUser(int id)
        {
            try
            {
                return Ok(_db.GetFirstOrDefault(u => u.Id == id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }

        [HttpPut("{id}")]
        public ActionResult PutUser(int id, User user)
        {
            try
            {

                _db.Update(user);
                _db.Save();
                return Ok($"User id: {id} atualizado");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }




        }

        [HttpPost]
        public ActionResult<User> CreateUser(User user)
        {

                User newUser = user;
                try
                {
                    _db.Add(newUser);
                    _db.Save();
                    return Created("Usuario criado", new { Message = $"O Usuário de nome {user.Name} foi criado" });
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            

        }

        [HttpDelete("{id}")]
        public ActionResult DeleteUser(int id)
        {
            try
            {
                _db.Remove(_db.GetFirstOrDefault(e => e.Id == id));
                _db.Save();
                return Ok($"User id:{id} was deleted");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

    }
}