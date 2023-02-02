using CrudApiWithMongoDB.Collections;
using MongoDB.Driver;

namespace CrudApiWithMongoDB.Service;

public class PersonService : IPersonService
{
    private readonly IMongoCollection<Person> _mongoPersonCollection;

    public PersonService(IMongoDatabase mongoDatabase)
    {
        _mongoPersonCollection = mongoDatabase.GetCollection<Person>("person");
    }

    public async Task CreateAsync(Person person)
    {
        await _mongoPersonCollection.InsertOneAsync(person);

    }

    public async Task<Person> Get(int id)
    {
        return await _mongoPersonCollection.Find(obj => obj.Id == id).FirstOrDefaultAsync();
    }
    public async Task<List<Person>> GetAll()
    {
        return await _mongoPersonCollection.Find(obj => true).ToListAsync();
    }

    public async Task UpdateAsync(Person person,int id)
    {
        await _mongoPersonCollection.
        ReplaceOneAsync(obj => obj.Id == id, person);

    }
}