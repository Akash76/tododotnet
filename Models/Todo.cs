using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace tododotnet.Models
{
    public class Todo
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Content { get; set; }
        public bool Complete { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}