using Proyecto24AM.Models.Entities;

namespace Proyecto24AM.Services.IServices
{
    public interface IRolServices
    {
        public Task<List<Rol>> GetRols();
        public Task<Rol> GetByIdRol(int id);
        public Task<Rol> CreateRol(Rol i);
        public Task<Rol> EditRol(Rol i);
        public bool DeleteRol(int id);
    }
}
