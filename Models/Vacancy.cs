using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace RecruterWebApp.Models
{
    public class Vacancy
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("Title")]
        public string Title { get; set; }
        public string Text { get; set; }

         [BsonElement("Posted by")]
        public string RecruterId {get;set;}
        public virtual Recruter Recruter {get;set;}
       
    }
}
