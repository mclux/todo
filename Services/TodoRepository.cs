using Core;
using Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class TodoRepository:ITodoRepository
    {
        TodoContext context = new TodoContext();
        public IEnumerable<Todo> GetAll()
        {
            return context.Todo.ToList();
        }
        public Todo Add(Todo todo)
        {
            todo.Created = DateTime.Now;
            context.Todo.Add(todo);
            if (context.SaveChanges() > 0)
            {
                return todo;
            }
            return null;
        }

        public Todo Update(Todo todo)
        {
            var toEdit = context.Todo.FirstOrDefault(p=>p.Id==todo.Id);
            toEdit.Status = todo.Status;
            context.Entry(todo).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
            return toEdit;
        }

        public void Delete(int Id)
        {
            var toDelete = context.Todo.FirstOrDefault(p=>p.Id==Id);
            context.Todo.Remove(toDelete);
            context.SaveChanges();
        }
    }
}
