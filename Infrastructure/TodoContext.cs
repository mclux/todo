using Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class TodoContext: DbContext
    {
        public TodoContext():base("name=penttech_tododbEntities")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;

            Database.SetInitializer(new TodoInitializeDb());
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Todo> Todo { get; set; }
    }
}
