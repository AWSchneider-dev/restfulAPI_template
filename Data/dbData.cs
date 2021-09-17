using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace restfulAPI_template.Data
{
    public class dbData : IdentityDbContext
    {
        public dbData(DbContextOptions<dbData> options)
            : base(options)
        {
        }
    }
}
