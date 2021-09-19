using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsersApi.Database;
using UsersApi.Model;

namespace UsersApi.Repository
{
    public interface IUserRepository
    {
        public string LoginUser(string username, string password);
        public Task<string> addUser(Users user);
    }
}
