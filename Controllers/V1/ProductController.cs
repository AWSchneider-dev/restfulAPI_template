using Microsoft.AspNetCore.Mvc;
using restfulAPI_template.config.V1;
using restfulAPI_template.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace restfulAPI_template.Controllers.V1
{
  public class ProductController : Controller
  {

    private List<Product> _products;

    public ProductController()
    {
      // Add dummy products
      _products = new List<Product>();
      for(int i = 0; i < 5; i++)
      {
        _products.Add(new Product { Id = Guid.NewGuid().ToString(), name = $"Retroincabulator{i}" ,companyName = "Rockwell Automation", salesPitch = "capable of automatically synchronizing cardinal grammeters" });
      }
    }

    [HttpGet(ApiRoutes.Products.GetAll)]
    public IActionResult GetAll()
    {
      return Ok(_products);
    }
  }
}
