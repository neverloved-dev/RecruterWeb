using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace RecruterWebApp.Models
{
    public class Recruter
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("Name")]
        public string Name { get; set; }
        public string Email { get; set; }
        
        public string PhoneNumber {get;set;}

        public string Agency {get;set;}
        
       
    }
}
