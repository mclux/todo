using Core;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Api.Controllers
{
    [RoutePrefix("api/Todo")]
    [Authorize]
    public class TodoController : ApiController
    {
        TodoRepository todoRepo;
        public TodoController()
        {
            todoRepo = new TodoRepository();
        }

        [Route("Get")]
        public IHttpActionResult GetAll()
        {
            var todo = todoRepo.GetAll();
            return Ok(todo);
        }

        [Route("Add")]
        [HttpPost]
        public IHttpActionResult Create(Todo todo)
        {
            todoRepo.Add(todo);
            return Ok(todo);
        }

        [Route("Update")]
        [HttpPost]
        public IHttpActionResult Update(Todo todo)
        {
            todoRepo.Update(todo);
            return Ok(todo);
        }

        [Route("Delete")]
        [HttpPost]
        public IHttpActionResult Delete(int id)
        {
            todoRepo.Delete(id);
            return Ok();
        }
    }
}
