using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using tododotnet.Models;
using tododotnet.Services;

namespace tododotnet.Controllers
{
    [Produces("application/json")]
    [Route("api/submission")]
    public class TodoGetController
    {
        private readonly TodoService _todoService;

        public TodoGetController(TodoService todoService) {
            _todoService = todoService;
        }

        [HttpGet("getTodoById/{id}")]
        public ActionResult<Todo> GetTodoById(string id) {
            Todo todo = _todoService.Find(id);
            return todo;
        }

        [HttpGet("allTodos")]
        public IEnumerable<Todo> GetAllTodos() {
            IEnumerable<Todo> todos =  _todoService.Read();
            return todos;
        }

        [HttpGet("getTodoByUsername/{username}")]
        public IEnumerable<Todo> GetTodoByUsername(string username) {
            IEnumerable<Todo> todos = _todoService.FindByUsername(username);
            return todos;
        }
    }
}