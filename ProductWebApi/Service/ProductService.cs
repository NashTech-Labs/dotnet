using ProductWebApi.Model;
namespace ProductWebApi.Service;

public interface ProductService
{
     List<Product> GetAll();
     Product GetbyCode(int code);
     bool Remove(int code);
     Product Save(Product _product);

}