using Core.Entities;


namespace Core.Interfaces.Repositories
{
    public interface IProfileRepository : IRepository<Profile>
    {
        void Update(Profile user);
        void Save();
    }
}
