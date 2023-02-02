using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
namespace CrudApiWithMongoDB.Collections;
public class Person
{
    [BsonId]
    
    [BsonElement("id")]
    public int Id { get; set; }
    [BsonElement("name")]
    public string? Name { get; set; }
    [BsonElement("age")]

    public int Age { get; set; }

}