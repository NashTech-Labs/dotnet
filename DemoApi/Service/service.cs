using DemoApi.Model;

namespace DemoApi.service;
public interface service {
     List<User> GetAll();
     User GetbyCode(int code);
    }
