using DataAccessLibrary.Models;

namespace DataAccess.DataService
{
    public interface IUserService
    {
        void AddUser(IUser user);
        bool CheckUserExistsInAD(string login);
        void DeleteUser(IUser user);
        IUser GetUserById(int id);
        List<IUser> GetUsers();
        void UpdateUser(IUser user);
        bool CheckUserNotNull(IUser user);
    }
}