using RecruterWebApp.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;

namespace RecruterWebApp.Services
{
    public class VacancyService
    {
        private readonly IMongoCollection<Vacancy> _vacancyCollection;
        public VacancyService(IOptions<DatabaseSettings> databaseSettings)
        {
            MongoClient mongoClient = new MongoClient(databaseSettings.Value.ConnectionURI);
            IMongoDatabase db = mongoClient.GetDatabase(databaseSettings.Value.DatabaseName);
            _vacancyCollection = db.GetCollection<Vacancy>(databaseSettings.Value.CollectionName);
        }
    }
}
