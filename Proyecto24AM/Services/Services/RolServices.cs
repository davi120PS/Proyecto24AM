using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Proyecto24AM.Context;
using Proyecto24AM.Models.Entities;
using Proyecto24AM.Services.IServices;

namespace Proyecto24AM.Services.Services
{
    public class RolServices : IRolServices
    {
        private readonly ApplicationDbContext _context;
        public RolServices(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Rol>> GetRols()
        {
            try
            {
                return await _context.Rols.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Surgió un error" + ex.Message);
            }
        }
        public async Task<Rol> GetByIdRol(int id)
        {
            try
            {
                Rol response = await _context.Rols.FirstOrDefaultAsync(x => x.PKRol == id);
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception("Surgió un error" + ex.Message);
            }
        }
        public async Task<Rol> CreateRol(Rol i)
        {
            try
            {
                Rol request = new Rol()
                {
                    Name = i.Name
                };
                //Con esto se manda a la bd de forma asincrona
                var result = await _context.Rols.AddAsync(request);
                _context.SaveChanges();

                return request;
            }
            catch (Exception ex)
            {
                throw new Exception("Surgió un error" + ex.Message);
            }
        }
        public async Task<Rol> EditRol(Rol i)
        {
            try
            {
                Rol request = _context.Rols.Find(i.PKRol);
                request.Name = i.Name;
                //Con esto se manda a la bd de forma asincrona

                _context.Entry(request).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return request;

                /*var result = _context.Articles.Update(request);
                await _context.SaveChangesAsync();

                return request;*/
            }
            catch (Exception ex)
            {
                throw new Exception("Surgió un error" + ex.Message);
            }
        }
        public async Task<Rol> DeleteUser(Rol i)
        {
            try
            {
                Rol request = _context.Rols.Find(i);
                if (request != null)
                {
                    var result = _context.Rols.Remove(request);
                    await _context.SaveChangesAsync();
                }
                else
                    Console.WriteLine("No existe el registro");
                //Con esto se manda a la bd de forma asincrona

                return request;
            }
            catch (Exception ex)
            {
                throw new Exception("Surgió un error" + ex.Message);
            }
        }
        public bool DeleteRol(int id)
        {
            try
            {
                Rol rol = _context.Rols.Find(id);

                if (rol != null)
                {
                    var res = _context.Rols.Remove(rol);
                    _context.SaveChanges();
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw new Exception("Surgió un error" + ex.Message);
            }
        }
    }
}
