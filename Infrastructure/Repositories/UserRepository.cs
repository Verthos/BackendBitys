using Core.Entities;
using Core.Interfaces.Repositories;
using Infrastructure.DatabaseContext;

namespace Infrastructure.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly ApiContext _db;
        public UserRepository(ApiContext db) : base(db)
        {
            _db = db;
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(User user)
        {
            //_db.Users.Update(user);
        }


    }
}
