using CrudApiWithMongoDB.Collections;
using CrudApiWithMongoDB.Service;
using Microsoft.AspNetCore.Mvc;

namespace CrudApiWithMongoDB.Controllers;

[ApiController]
[Route("/api")]
public class PersonController : ControllerBase
{
    private readonly IPersonService _personService;
    public PersonController(IPersonService personService)
    {
        this._personService = personService;
    }

    [HttpPost("create")]
    public async Task<Person> Post(Person newPerson)
    {
        await _personService.CreateAsync(newPerson);
        return newPerson;
    }
     [HttpGet("getPerson/{id}")]
    public async Task<Person> GetById(int id)
    {
      var person=  await _personService.Get(id);
        return person;
    }
     [HttpGet("getAllPerson")]
    public async Task<List<Person>> GetAllPersons()
    {
      var person=  await _personService.GetAll();
        return person;
    }
    [HttpPut("updatePerson")]
    public async Task<IActionResult> Put(Person personToUpdate)
    { var person=_personService.Get(personToUpdate.Id);
    if(person==null){
        return NotFound();
    }
        await _personService.UpdateAsync(personToUpdate);
        return Ok(personToUpdate);
    }
}