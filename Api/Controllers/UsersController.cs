using Core.Entities;
using Core.Interfaces.Repositories;
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
                var users = _db.GetAllWithProfile(); 
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
                var user = _db.GetByIdWithProfile(id);
                if (user == null) return NotFound($"Usuário com id {id} não encontrado.");
                return Ok(user);
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
                var existingUser = _db.GetByIdWithProfile(id);
                if (existingUser == null) return NotFound($"Usuário com id {id} não encontrado.");

                existingUser.Name = user.Name;
                existingUser.CPF = user.CPF;
                existingUser.Email = user.Email;
                existingUser.BirthDate = user.BirthDate;
                existingUser.ProfileId = user.ProfileId; 
                existingUser.Language = user.Language;
                existingUser.Status = user.Status;

                _db.Update(existingUser);
                _db.Save();
                return Ok($"Usuário id: {id} atualizado");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult<User> CreateUser(User user)
        {
            try
            {
                _db.Add(user);
                _db.Save();
                return Created("Usuario criado", new { Message = $"O Usuário {user.Name} foi criado" });
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
                var user = _db.GetByIdWithProfile(id);
                if (user == null) return NotFound($"Usuário com id {id} não encontrado.");

                _db.Remove(user);
                _db.Save();
                return Ok($"Usuário id:{id} foi deletado");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
