using DemoApi.Model;
using DemoApi.service;
using Microsoft.AspNetCore.Mvc;
namespace TestWebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class MyCntroller : ControllerBase
{
  private readonly service _DBContext;


    public MyCntroller(service dBContext)
    {
        this._DBContext = dBContext;
    }

    [HttpGet("GetAll")]
    public List<User> GetAll()
    {
        var user = this._DBContext.GetAll();
        return user;
    }
    [HttpGet("GetbyCode/{code}")]
    public User GetbyCode(int code)
    {
        var user =  this._DBContext.GetbyCode(code);
        return  user;
    }
}