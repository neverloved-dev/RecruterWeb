using RecruterWebApp.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;

namespace RecruterWebApp.Services
{
    public class RecruterService
    {
         private readonly IMongoCollection<Recruter> _recruterCollection;
          public RecruterService(IOptions<DatabaseSettings> databaseSettings)
        {
            MongoClient mongoClient = new MongoClient(databaseSettings.Value.ConnectionURI);
            IMongoDatabase db = mongoClient.GetDatabase(databaseSettings.Value.DatabaseName);
            _recruterCollection = db.GetCollection<Recruter>(databaseSettings.Value.CollectionName);
        }
    }
}