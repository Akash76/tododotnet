using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using tododotnet.Models;
using tododotnet.Services;

namespace tododotnet.Controllers
{
    [Produces("application/json")]
    [Route("api/submission")]
    public class SubmissionGetController
    {
        private readonly SubmissionService _subSvc;

        public SubmissionGetController(SubmissionService submissionService) {
            _subSvc = submissionService;
        }

        [HttpGet("getTodoById/{id}")]
        public ActionResult<Submission> GetTodoById(string id) {
            Submission todo = _subSvc.Find(id);
            return todo;
        }

        [HttpGet("allTodos")]
        public IEnumerable<Submission> GetAllTodos() {
            IEnumerable<Submission> todos =  _subSvc.Read();
            return todos;
        }

        [HttpGet("getTodoByUsername/{username}")]
        public IEnumerable<Submission> GetTodoByUsername(string username) {
            IEnumerable<Submission> todos = _subSvc.FindByUsername(username);
            return todos;
        }
    }
}