using Microsoft.EntityFrameworkCore;
using Proyecto24AM.Context;
using Proyecto24AM.Models.Entities;
using Proyecto24AM.Services.IServices;

namespace Proyecto24AM.Services.Services
{
    public class UserServices : IUserServices
    {
        private readonly ApplicationDbContext _context;
        public UserServices(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<User>> GetUsers()
        {
            try
            {
                return await _context.Users.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Surgió un error" + ex.Message);
            }
        }
        public async Task<User> GetByIdUser(int id)
        {
            try
            {
                User response = await _context.Users.FirstOrDefaultAsync(x => x.PKUser == id);
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception("Surgió un error" + ex.Message);
            }
        }
        public async Task<User> CreateUser(User i)
        {
            try
            {
                User request = new User()
                {
                    Name = i.Name,
                    lastName = i.lastName,
                    UserName = i.UserName,
                    Password = i.Password,
                    FKRol = i.FKRol
                };
                //Con esto se manda a la bd de forma asincrona
                var result = await _context.Users.AddAsync(request);
                _context.SaveChanges();

                return request;
            }
            catch (Exception ex)
            {
                throw new Exception("Surgió un error" + ex.Message);
            }
        }
        public async Task<User> EditUser(User i)
        {
            try
            {
                User request = _context.Users.Find(i.PKUser);
                request.Name = i.Name;
                request.lastName = i.lastName;
                request.UserName = i.UserName;
                request.Password = i.Password;
                request.FKRol = i.FKRol;
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
        public async Task<User> DeleteUser(User i)
        {
            try
            {
                User request = _context.Users.Find(i);
                if (request != null)
                {
                    var result = _context.Users.Remove(request);
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
        public bool DeleteUser(int id)
        {
            try
            {
                User book = _context.Users.Find(id);

                if (book != null)
                {
                    var res = _context.Users.Remove(book);
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
