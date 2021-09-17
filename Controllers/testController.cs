using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace restfulAPI_template.Controllers
{
  public class testController : Microsoft.AspNetCore.Mvc.Controller
  {
    [HttpGet("api/RockwellAutomationProducts")]
    public IActionResult Get()
    {
      return Ok(new { item = "Retroincabulator", company = "Rockwell Automation", salesPitch = "capable of automatically synchronizing cardinal grammeters" });
    }
  }
}
