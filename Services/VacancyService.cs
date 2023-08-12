using RecruterWebApp.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;

namespace RecruterWebApp.Services
{
    public class RecruterService
    {
        private readonly IMongoCollection<Recruter> _RecruterCollection;
        public RecruterService(IOptions<DatabaseSettings> databaseSettings)
        {
            MongoClient mongoClient = new MongoClient(databaseSettings.Value.ConnectionURI);
            IMongoDatabase db = mongoClient.GetDatabase(databaseSettings.Value.DatabaseName);
            _RecruterCollection = db.GetCollection<Recruter>(databaseSettings.Value.CollectionName);
        }

        public async Task<List<Recruter>>GetAllAsync()
        {
            return await _RecruterCollection.Find(_=>true).ToListAsync();
        }
        public async Task<Recruter?>GetRecruterAsync(string id)
        {
            return await _RecruterCollection.Find(x=>x.Id == id).FirstOrDefaultAsync();
        }

        public async Task CreateRecruterAsync(Recruter Recruter)
        {
            await _RecruterCollection.InsertOneAsync(Recruter);
        }
        public async Task UpdateRecruterDataAsync(string id, Recruter Recruter)
        {
            await _RecruterCollection.ReplaceOneAsync(x=>x.Id == id,Recruter);
        }

        public async Task DeleteRecruterAsync(string id)
        {
            await _RecruterCollection.DeleteOneAsync(x=>x.Id == id);
        }
    }
}
