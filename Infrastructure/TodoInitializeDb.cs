using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class TodoInitializeDb: DropCreateDatabaseIfModelChanges<TodoContext>
    {
        protected override void Seed(TodoContext context)
        {
            MD5 md5Hash = MD5.Create();
            context.Users.Add(new Core.User
            {
                Username = "alex",
                Password = PasswordManager.GetMd5Hash(md5Hash, "todo"),
                FirstName = "alex",
                LastName="tosin",
                Created=DateTime.Now
            });

            base.Seed(context);
            context.SaveChanges();
        }
    }
}
