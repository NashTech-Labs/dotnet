using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ProductWebApi.Service;
using ProductWebApi.Model;

namespace ProductWebApi.Controllers;

///[Authorize(Roles ="admin,user")]
[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{

    private readonly ProductService _DBContext;


    public ProductController(ProductService dBContext)
    {
        this._DBContext = dBContext;
    }

    [HttpGet("GetAll")]
    public List<Product> GetAll()
    {
        var product = this._DBContext.GetAll();
        return product;
    }
    [HttpGet("GetbyCode/{code}")]
    public Product GetbyCode(int code)
    {
        var product =  this._DBContext.GetbyCode(code);
        return  product;
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
    public  Product Create([FromBody] Product _product)
    {
        var product = this._DBContext.Save(_product);
        return product;
    }
}
