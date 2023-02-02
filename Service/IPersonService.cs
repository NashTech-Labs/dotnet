using CrudApiWithMongoDB.Collections;

namespace CrudApiWithMongoDB.Service;

public interface IPersonService
{
    Task CreateAsync(Person person);
    Task<Person> Get(int id);
    Task<List<Person>> GetAll();
    Task UpdateAsync(Person PersonToUpdate);

}