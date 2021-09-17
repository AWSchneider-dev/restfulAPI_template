using Microsoft.AspNetCore.Mvc;
using restfulAPI_template.config.V1;
using restfulAPI_template.Controllers.V1.Requests;
using restfulAPI_template.Controllers.V1.Responses;
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

    // Why a Request/Response and Product Object they all are the same?
    //
    // The request and the product are seperate even though they seem redundant
    // This is to seperate the request a User would make, versus what is being used in the domain of the code
    // This allows us to have backward compatibility with new features and ensures we can expand capability
    // without breaking consumer requests
    // This is called a Contract First Approach
    // The contract tells the consumer what the request and response communication is expected to be.
    // Once the contract is in place, the service provider can work on providing a service that adheres to the contract.
    // The service consumer can work on developing an application to consume it.

    // What comes in is not the same as what we do work on or what we return.
    // This seperation allows backwards compatabiity since the calling application is aware of the contract and the contract is adhered to

    // tl;Dr The front end can start developing the UI and how it will consume the API
    // While the API Developers can develop the API
    // If the the front end and the backend can decide on a Contract then the requests can be formed in this way.
    // The idea being the Contract doesn't change often if at all.
    [HttpPost(ApiRoutes.Products.Create)]
    public IActionResult Create([FromBody] CreateNewProductRequest productRequest)
    {

      var product = new Product { Id = productRequest.Id};

      if(string.IsNullOrEmpty(product.Id))
      {
        product.Id = Guid.NewGuid().ToString();
      }

      _products.Add(product);

      // Return header
      // Location and Value
      // Hypermedia as the Engine of Application State(HATEOAS) is a constraint of the REST application architecture that distinguishes it from other network application architectures.
      // With HATEOAS, a client interacts with a network application whose application servers provide information dynamically through hypermedia.
      var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
      var locationUri = baseUrl + "/" + ApiRoutes.Products.Get.Replace("{Id}", product.Id);

      var response = new ProductResponse { Id = product.Id };

      return Created(locationUri, response);
    }


  }
}
