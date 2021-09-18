using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsersApi.Database;
using UsersApi.Model;

namespace UsersApi.Repository
{
    interface IUserRepository
    {
        public Task<UserModel> LoginUserAsync();
        public Task<UserModel> addUser(Users user);
    }
}
