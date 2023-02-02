using Microsoft.EntityFrameworkCore;
using userWebApi.Model;
using DemoApi.Model;
using DemoApi.service;
namespace ServiceWebApi.Service;
public class serviceimplement : service
{
    private readonly Database _DBContext;
    public serviceimplement(Database dBContext)
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
        User user =   _DBContext.Users.Find(code);
        if (user != null)
        {
            return user;
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
    public  bool Remove(int code)
    {
        var user =  _DBContext.Users.Find(code);
        if (user != null)
        {
            this._DBContext.Remove(user);
             this._DBContext.SaveChanges();
            return true;
        }
        else
        {
            return false;
        }
    }

    public  User Save(User _user)
    {
        var user = this._DBContext.Users.FirstOrDefault(o => o.age == _user.age);
        if (user != null)
        {
            user.name = _user.name;
            user.companyName = _user.companyName;
            this._DBContext.SaveChangesAsync();
        }
          else
        {
             this._DBContext.Users.Add(_user);
             this._DBContext.SaveChanges();
        }
        return _user;
    }

}
        