using Proyecto24AM.Models.Entities;

namespace Proyecto24AM.Services.IServices
{
    public interface IUserServices
    {
        public Task<List<User>> GetUsers();
        public Task<User> GetByIdUser(int id);
        public Task<User> CreateUser(User i);
        public Task<User> EditUser(User i);
        public bool DeleteUser(int id);
    }
}
