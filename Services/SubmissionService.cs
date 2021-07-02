using System;
using System.Collections.Generic;
using MongoDB.Driver;
using tododotnet.Models;

namespace tododotnet.Services
{
    public class TodoService
    {
        private readonly IMongoCollection<Todo> _submissions;

        public TodoService(IDatabaseSettings settings) {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _submissions = database.GetCollection<Todo>("Submissions");
        }

        public Todo Create(Todo submission) {
            Console.WriteLine(submission);
            _submissions.InsertOne(submission);

            return submission;
        }

        public IList<Todo> Read() =>
            _submissions.Find(sub => true).ToList();

        public Todo Find(string id) =>
            _submissions.Find(sub=>sub.Id == id).SingleOrDefault();

        public void Update(Todo submission) =>
            _submissions.ReplaceOne(sub => sub.Id == submission.Id, submission);

        public void Delete(string id) =>
            _submissions.DeleteOne(sub => sub.Id == id);
    }
}