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
            _recruterCollection = db.GetCollection<Recruter>("Recruter");
        }

          public async Task<List<Recruter>>GetAllAsync()
        {
            return await _recruterCollection.Find(_=>true).ToListAsync();
        }
        public async Task<Recruter?>GetRecruterAsync(long id)
        {
            return await _recruterCollection.Find(x=>x.Id == id).FirstOrDefaultAsync();
        }

        public async Task CreateRecruterAsync(Recruter Recruter)
        {
            await _recruterCollection.InsertOneAsync(Recruter);
        }
        public async Task UpdateRecruterDataAsync(long id, Recruter Recruter)
        {
            await _recruterCollection.ReplaceOneAsync(x=>x.Id == id,Recruter);
        }

        public async Task DeleteRecruterAsync(long id)
        {
            await _recruterCollection.DeleteOneAsync(x=>x.Id == id);
        }
    }
}
