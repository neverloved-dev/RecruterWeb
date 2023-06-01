using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace RecruterWebApp.Models
{
    public class Recruter
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id {get;set;}
        [BsonElement("Name")]
        public string FullName{get;set;}
        public string Company {get;set;}
           [BsonElement("Listings")]
        public ICollection<Vacancy>Vacancies {get;set;}
    }
    
}
