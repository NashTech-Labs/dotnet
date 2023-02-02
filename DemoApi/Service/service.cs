using DemoApi.Model;

namespace DemoApi.service;
public interface service {
     List<User> GetAll();
     User GetbyCode(int code);
    bool Remove(int code);
    User Save(User user);
}
