using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsersApi.Database;
using UsersApi.Model;
using UsersApi.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UsersApi.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class userController : ControllerBase
    {
        private readonly IUserRepository userRepository;
        public userController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        // GET: api/<userController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<userController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
       public IActionResult Authenticate([FromBody] UserCredential credential)
        {
            var token = userRepository.LoginUser(credential.userName, credential.password);
            if(token == null)
            {
                return Unauthorized();
            }
            return Ok(token);
        }
        [AllowAnonymous]
        [HttpPost("adduser")]
        public async Task<IActionResult> AddUser([FromBody] Users user)
        {
            var result = await userRepository.addUser(user);
            return Ok(result);
        }
    }
}
