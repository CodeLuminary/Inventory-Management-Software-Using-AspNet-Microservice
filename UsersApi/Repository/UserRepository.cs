using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsersApi.Database;
using UsersApi.Model;

namespace UsersApi.Repository
{
    public class UserRepository : IUserRepository
    {
        public Task<UserModel> addUser(Users user)
        {
            throw new NotImplementedException();
        }

        public Task<UserModel> LoginUserAsync()
        {
            throw new NotImplementedException();
        }
    }
}
