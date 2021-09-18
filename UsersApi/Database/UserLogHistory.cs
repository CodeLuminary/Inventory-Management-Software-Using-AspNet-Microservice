using System;
using System.ComponentModel.DataAnnotations;

namespace UsersApi.Database
{
    public class UserLogHistory
    {
        [Key]
        public int userLogHistory { get; set; }
        public DateTime datetime { get; set; }
        public int userId { get; set; }
        public virtual Users user { get; set; }
    }
}
