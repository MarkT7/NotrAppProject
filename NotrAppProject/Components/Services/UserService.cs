using NotrAppProject.Components.Data;
using NotrAppProject.Components.DbContexts;

namespace NotrAppProject.Components.Services
{
    public class UserService : IUserService
    {
        //Dependency Injection of ApplicationDbContext to Constructor
        private readonly ApplicationDbContext _dbContext;
        public UserService(ApplicationDbContext context)
        {
            _dbContext = context;
        }

        public void DeleteUser(int id)
        {
            var user = _dbContext.Users.FirstOrDefault(x => x.Id == id);
            if (user != null)
            {
                _dbContext.Users.Remove(user);
                _dbContext.SaveChanges();
            }
        }

        public User GetUserById(int id)
        {
            var user = _dbContext.Users.FirstOrDefault(w => w.Id == id);
            return user;
        }

        public User GetUserByUsername(String username)
        {
            var user = _dbContext.Users.FirstOrDefault(w  => w.username == username);
            return user;
        }

        public List<User> GetUsers()
        {
            return _dbContext.Users.ToList();
        }

        //Throws exception when username is already in use
        public void SaveUser(User user)
        {
            if (_dbContext.Users.FirstOrDefault(e => e.username==user.username) == null) { 
                _dbContext.Users.Add(user);
                _dbContext.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException("Un usuario con ese nombre ya existe");
            }
        }

        //Throws exception when user does not exist
        public void UpdateUser(User user)
        {
            var existingUser = _dbContext.Users.Find(user.Id);
            if (existingUser != null)
            {
                existingUser.email = user.email;
                existingUser.username = user.username; 
                existingUser.password = user.password;
                _dbContext.Update(existingUser);
                _dbContext.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException("El usuario no existe");
            }
        }
    }
}
