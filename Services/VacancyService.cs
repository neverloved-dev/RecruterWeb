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

        public async Task<List<Vacancy>>GetAllAsync()
        {
            return await _vacancyCollection.Find(_=>true).ToListAsync();
        }
        public async Task<Vacancy?>GetVacancyAsync(string id)
        {
            return await _vacancyCollection.Find(x=>x.Id == id).FirstOrDefaultAsync();
        }

        public async Task CreateVacancyAsync(Vacancy vacancy)
        {
            await _vacancyCollection.InsertOneAsync(vacancy);
        }
        public async Task UpdateVacancyDataAsync(string id, Vacancy vacancy)
        {
            await _vacancyCollection.ReplaceOneAsync(x=>x.Id == id,vacancy);
        }

        public async Task DeleteVacancyAsync(string id)
        {
            await _vacancyCollection.DeleteOneAsync(x=>x.Id == id);
        }
    }
}
