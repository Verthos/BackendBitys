using Core.Entities;
using Core.Interfaces.Repositories;
using Infrastructure.DatabaseContext;

namespace Infrastructure.Repositories
{
    public class ProfileRepository : Repository<Profile>, IProfileRepository
    {
        private readonly ApiContext _db;
        public ProfileRepository(ApiContext db) : base(db)
        {
            _db = db;
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Profile user)
        {
            //_db.Users.Update(user);
        }


    }
}
