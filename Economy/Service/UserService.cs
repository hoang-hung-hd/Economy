using Economy.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Economy.Service
{
   
    public class UserService 
    {
        private AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<UserModel> GetAll()
        {
            return _context.Users;
        }

        public UserModel GetById(int id)
        {
            return getUser(id);
        }
        public void Create(UserModel model)
        {
            // validate
            if (_context.Users.Any(x => x.Email == model.Email))
                throw new Exception("Email '" + model.Email + "' already register");
            UserModel user = new UserModel();
            user.DisplayName = model.DisplayName;
            user.UserName = model.UserName;
            user.Email = model.Email;
            user.Password = model.Password;
            /*user.Password = BCrypt.Net.BCrypt.HashPassword(model.Password);*/

            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void Update(int id, UserModel model)
        {
            var user = getUser(id);

            // validate
            if (_context.Users.Any(x => x.Email == model.Email))
                throw new Exception("Email '" + model.Email + "' already register");
            user.DisplayName = model.DisplayName;
            user.UserName = model.UserName;
            user.Email = model.Email;
            user.Password = model.Password;
            /*user.Password = BCrypt.Net.BCrypt.HashPassword(model.Password);*/


            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var user = getUser(id);
            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        // helper methods

        private UserModel getUser(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null) throw new KeyNotFoundException("USer not found");
            return user;
        }
    }
}
