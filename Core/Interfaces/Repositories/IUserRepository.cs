using Core.Entities;


namespace Core.Interfaces.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        void Update(User user);
        void Save();

        IEnumerable<User> GetAllWithProfile();
        User GetByIdWithProfile(int id);
    }
}
