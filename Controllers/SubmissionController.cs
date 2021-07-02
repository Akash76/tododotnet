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
    [Route("api/submission")]
    public class SubmissionController
    {
        private readonly SubmissionService _subSvc;
        public SubmissionController(SubmissionService submissionService)
        {
            _subSvc = submissionService;
        }

        [HttpPost("create")]
        public ActionResult<Submission> Create([FromBody] Submission submission) {
            Submission newSubmission = new Submission();
            newSubmission.Created = DateTime.Now;
            newSubmission.LastUpdated = DateTime.Now;
            newSubmission.UserId = submission.UserId;
            newSubmission.UserName = submission.UserName;
            newSubmission.Content = submission.Content;
            newSubmission.Complete = false;
            _subSvc.Create(newSubmission);
            return newSubmission;
        }

        [HttpPut("markComplete/{id}")]
        public Submission MarkComplete(string id) {
            Submission todo = _subSvc.Find(id);
            todo.Complete = true;
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