using Microsoft.EntityFrameworkCore;
using userWebApi.Model;
using DemoApi.Model;
using DemoApi.service;
namespace ServiceWebApi.Service;
public class serviceimp : service
{
    private readonly Db _DBContext;
    public serviceimp(Db dBContext)
    {
        this._DBContext = dBContext;
    }

    public List<User> GetAll()
    {
        List<User> resp = new List<User>();
        List<User> user =  _DBContext.Users.ToList();
        return user;
    }
    public User GetbyCode(int code)
    {
        User product =   _DBContext.Users.Find(code);
        if (product != null)
        {
            return product;
        }
        else
        {
            return new User();
        }
    }

    User service.GetbyCode(int code)
    {
        throw new NotImplementedException();
    }
}
        