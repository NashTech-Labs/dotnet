using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace CrudApiWithMongoDB.Collections;
public class Person
{
    [BsonId]
    [BsonElement("id")]
    [Required]
    public int Id { get; set; }
    [BsonElement("name")]
    [Required]
    [MaxLength(10)]
    public string? Name { get; set; }
    [BsonElement("age")]
    [Required]
    [Range(0,1000)]
    public int Age { get; set; }

}