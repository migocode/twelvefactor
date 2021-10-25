using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using TwelveFactor.WebApi.Configuration;
using TwelveFactor.WebApi.Data.Models;

namespace TwelveFactor.WebApi.Data
{
    public class PersonRepository : IPersonRepository
    {
        private const string collectionName = "Person";
        private readonly IMongoCollection<Person> personCollection;
        private EnvironmentVariables environmentVariables;

        public PersonRepository(IOptions<EnvironmentVariables> options)
        {
            environmentVariables = options.Value;
            MongoClient client = new MongoClient(environmentVariables.DbConnectionString);
            IMongoDatabase database = client.GetDatabase(environmentVariables.DbName);
            personCollection = database.GetCollection<Person>(collectionName);
        }

        public Task InsertAsync(Person person)
        {
            return personCollection.InsertOneAsync(person);
        }

        public Task<List<Person>> SelectAllAsync()
        {
            return personCollection.Find(new BsonDocument()).ToListAsync();
        }
    }
}
