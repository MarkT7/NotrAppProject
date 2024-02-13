using NotrAppProject.Components.Data;

namespace NotrAppProject.Components.Services
{
    public interface IUserService
    {
        List<User> GetUsers();
        User GetUserById(int id);

        User GetUserByUsername(String username);
        void SaveUser(User user);
        void DeleteUser(int id);

        void UpdateUser(User user);
    }
}
