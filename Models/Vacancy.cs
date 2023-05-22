using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace RecruterWebApp.Models
{
    public class Vacancy
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public int Id { get; set; }
        [BsonElement("Title")]
        public string Title { get; set; }
        public string Text { get; set; }
       
    }
}
