using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
// using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using tododotnet.Models;
using tododotnet.Services;

namespace tododotnet.Controllers
{
    [Produces("application/json")]
    [Route("api/todo")]
    public class TodoController
    {
        private readonly TodoService _subSvc;
        public TodoController(TodoService submissionService)
        {
            _subSvc = submissionService;
        }

        [HttpPost("create")]
        public ActionResult<Todo> Create([FromBody] Todo submission) {
            Todo newSubmission = new Todo();
            newSubmission.Created = DateTime.Now;
            newSubmission.LastUpdated = DateTime.Now;
            newSubmission.Content = submission.Content;
            newSubmission.Complete = false;
            _subSvc.Create(newSubmission);
            return newSubmission;
        }

        [HttpPut("markComplete/{id}")]
        public Todo MarkComplete(string id) {
            Todo todo = _subSvc.Find(id);
            todo.Complete = !todo.Complete;
            todo.LastUpdated = DateTime.Now;
            _subSvc.Update(todo);

            return todo;
        }

        [HttpDelete("deleteTodo/{id}")]
        public string DeleteTodo(string id) {
            _subSvc.Delete(id);

            return "Deleted todo with id:" + id + " successfully";
        }
    }
}