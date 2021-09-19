using System.ComponentModel.DataAnnotations;

namespace UsersApi.Database
{
    public class Users
    {
        [Key]
        public int userId { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public bool isActive { get; set; }
        public bool isEmailConfirmed { get; set; }
        public string role { get; set; }
    }
}
