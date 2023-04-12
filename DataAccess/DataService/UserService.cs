using DataAccess.Db;
using DataAccessLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DataService
{
    public class UserService : IUserService

    {


        private readonly AppDbContext _dbContext;

        public UserService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<IUser> GetUsers()
        {
            return _dbContext.Users.ToList<IUser>();
        }

        public IUser GetUserById(int id)
        {
            var userList = GetUsers();
            return userList.FirstOrDefault(u => u.Id == id);
        }

        public void AddUser(IUser user)
        {

                if (CheckUserNotNull(user))
                {
                User userToAdd = new User(); // Create a new User object
                                             // Set properties of userToAdd based on user
                userToAdd.FirstName = user.FirstName;
                userToAdd.MiddleName = user.MiddleName;
                userToAdd.LastName = user.LastName;
                userToAdd.AdLogin = user.AdLogin;
                userToAdd.IsDeleted = user.IsDeleted;
                // Add userToAdd to the _dbContext.Users collection
                
                
                try
                {
                    _dbContext.Users.Add(userToAdd);
                    _dbContext.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }

            }
                else
                {
                    throw new Exception("Пользователь не найден в Active Directory. Пожалуйста, сначала создайте пользователя в Active Directory");
                }

        }


        public void UpdateUser(IUser user)
        {
            if (CheckUserNotNull(user))
            {
                if (CheckUserExistsInAD(user.AdLogin))
                {
                    _dbContext.Users.Update((User)user);
                    _dbContext.SaveChanges();
                }
                else
                {
                    throw new Exception("Пользователь не найден в Active Directory. Возможно пользователь более не состоит в организации. Вы можете только удалить пользователя");
                }
            }


        }
        public void DeleteUser(IUser user)
        {
            if (CheckUserNotNull(user))
            {
                if (CheckUserExistsInAD(user.AdLogin))
                {
                    user.IsDeleted = true;
                    _dbContext.Users.Update((User)user);
                    _dbContext.SaveChanges();
                }
                else
                {
                    throw new Exception("Пользователь не найден в Active Directory");
                }
            }


        }


        public bool CheckUserExistsInAD(string login)
        {
            // Логика проверки наличия информации о пользователе в Active Directory
            // в данном случае для теста возвращаем true
            return true;
        }

        public bool CheckUserNotNull(IUser user)
        {
            if (user is not null)
            {
                return true;
            }
            else
            { return false; }
        }



    }


}


