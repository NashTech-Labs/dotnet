
using Microsoft.EntityFrameworkCore;
using ProductWebApi.Model;
using AutoMapper;

namespace ProductWebApi.Service;
public class ProductServiceImpl : ProductService
{
    private readonly ProductDBContext _ProductDBContext;
    public ProductServiceImpl(ProductDBContext productDBContext)
    {
        this._ProductDBContext = productDBContext;
    }

    public List<Product> GetAll()
    {
        List<Product> resp = new List<Product>();
        List<Product> product =  _ProductDBContext.Products.ToList();
        return product;
    }
    public Product GetbyCode(int code)
    {
        Product product =   _ProductDBContext.Products.Find(code);
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
        var product =  _ProductDBContext.Products.Find(code);
        if (product != null)
        {
            this._ProductDBContext.Remove(product);
             this._ProductDBContext.SaveChanges();
            return true;
        }
        else
        {
            return false;
        }
    }

    public  Product Save(Product productObj)
    {
        var product = this._ProductDBContext.Products.FirstOrDefault(o => o.Id == productObj.Id);
        if (product != null)
        {
            product.Name = productObj.Name;
            product.Price = productObj.Price;
            this._ProductDBContext.SaveChangesAsync();
        }
          else
        {
             this._ProductDBContext.Products.Add(productObj);
             this._ProductDBContext.SaveChanges();
        }
        return productObj;
    }

}