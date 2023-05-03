using Api.Models;
using Common.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Api.Controllers
{
    public class UserController : BaseController
    {
        private readonly DemoContext context;

        public UserController(DemoContext context)
        {
            this.context = context;
          
        }

        [HttpGet]
        public IEnumerable<User> GetAllUser() => context.Users.ToList();

        [HttpGet("{id}")]
        public User Get(int id)
        {
            return context.Users.Find(id);
        }

        [HttpPost]
        public int Create(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
            return user.UserId;
        }

        [HttpPut]
        public User Update(User user)
        {
            context.Users.Update(user);
            context.SaveChanges();
            return user;
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var user= context.Users.Find(id);
            if (user is null)
            {
                return BadRequest();
            }
            //context.Users.Remove(new User() { UserId = id });
            context.Users.Remove(user);
            context.SaveChanges();
            return Ok(user);
        }
    

    }
}
