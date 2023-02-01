
using Microsoft.EntityFrameworkCore;
using ProductWebApi.Model;
using AutoMapper;

namespace ProductWebApi.Service;
public class ProductServiceImpl : ProductService
{
    private readonly Learn_DBContext _DBContext;
    public ProductServiceImpl(Learn_DBContext dBContext)
    {
        this._DBContext = dBContext;
    }

    public List<Product> GetAll()
    {
        List<Product> resp = new List<Product>();
        List<Product> product =  _DBContext.Products.ToList();
        return product;
    }
    public Product GetbyCode(int code)
    {
        Product product =   _DBContext.Products.Find(code);
        if (product != null)
        {
            return product;
        }
        else
        {
            return new Product();
        }
    }
    public  bool Remove(int code)
    {
        var product =  _DBContext.Products.Find(code);
        if (product != null)
        {
            this._DBContext.Remove(product);
             this._DBContext.SaveChanges();
            return true;
        }
        else
        {
            return false;
        }
    }

    public  Product Save(Product _product)
    {
        var product = this._DBContext.Products.FirstOrDefault(o => o.Id == _product.Id);
        Console.WriteLine("sdfghjkjhgf"+product);
        if (product != null)
        {
            product.Name = _product.Name;
            product.Price = _product.Price;
            this._DBContext.SaveChangesAsync();
        }
          else
        {
             this._DBContext.Products.Add(_product);
             this._DBContext.SaveChanges();
        }
        return _product;
    }

}