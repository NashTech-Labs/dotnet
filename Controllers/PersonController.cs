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
    public async Task<ActionResult<Person>> Post(Person newPerson)
    {
        try
        {
            if (newPerson == null)
            {
                return BadRequest();
            }
            await _personService.CreateAsync(newPerson);
            return newPerson;
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                "Error creating new record "+ex.Message);
        }
    }
    [HttpGet("getPerson/{id}")]
    public async Task<ActionResult<Person>> GetById(int id)
    {
        try
        {
            var person = await _personService.Get(id);
            if (person == null) return NotFound();
            return person;

        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                "Error retrieving data from the database "+ex.Message);
        }
    }
    [HttpGet("getAllPerson")]
    public async Task<ActionResult<List<Person>>> GetAllPersons()
    {
        try
        {
            return await _personService.GetAll();
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                "Error retrieving data from the database "+ex.Message);
        }
    }
   
    [HttpPut("updatePerson/{id}")]
    public async Task<ActionResult<Person>> UpdatePerson(Person person, int id)
    {
        try
        {
            if (id != person.Id)
                return BadRequest("Person ID mismatch");

            var personToUpdate = await _personService.Get(id);

            if (personToUpdate == null)
                return NotFound($"Employee with Id = {id} not found");

            await _personService.UpdateAsync(person, id);
            return Ok(person);

        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                "Error updating data "+ex.Message);
        }
    }
}