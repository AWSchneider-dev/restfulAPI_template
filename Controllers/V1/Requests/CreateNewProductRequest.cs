using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace restfulAPI_template.Controllers.V1.Requests
{
  public class CreateNewProductRequest
  {
    public string Id { get; set; }
    public string name { get; set; }
    public string companyName { get; set; }
    public string salesPitch { get; set; }
  }
}
