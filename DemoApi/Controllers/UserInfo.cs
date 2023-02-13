using DemoApi.Model;
using DemoApi.service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace TestWebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UserInfo : ControllerBase
{
  private readonly service _DBContext;


    public UserInfo(service dBContext)
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
    [Authorize(Roles ="admin")]
    [HttpDelete("Remove/{code}")]
    public bool Remove(int code)
    {
        var product = this._DBContext.Remove(code);
        return  false;
    }

    //[Authorize(Roles ="admin")]
    [HttpPost("Create")]
    public  User Create([FromBody] User _user)
    {
        var user = this._DBContext.Save(_user);
        return _user;
    }
}