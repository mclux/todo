using Core;
using Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class UserRepository: IUserRepository
    {
        TodoContext context = new TodoContext();
        public IEnumerable<Todo> GetAll()
        {
            return context.Todo.ToList();
        }
        
        public User Add(User user)
        {
            user.Created = DateTime.Now;
            context.Users.Add(user);
            if (context.SaveChanges() > 0)
            {
                return user;
            }
            return null;
        }
        public User Get(string username)
        {
            return context.Users.FirstOrDefault(p=>p.Username==username);
        }
    }
}
