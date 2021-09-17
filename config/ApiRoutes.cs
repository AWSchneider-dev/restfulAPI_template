using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace restfulAPI_template.config.V1
{
  public static class ApiRoutes
  {
    public const string Root = "api";
    public const string Version = "v1";
    public const string Base = Root + "/" + Version;

    public static class Products
    {
      public const string GetAll = Base + "/products";
    }
  }
}
