using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class WebApplication3Context : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public WebApplication3Context() : base("name=WebApplication3Context")
        {
        }

        public System.Data.Entity.DbSet<WebApplication3.Models.College> Colleges { get; set; }

        public System.Data.Entity.DbSet<WebApplication3.Models.Stream> Streams { get; set; }

        public System.Data.Entity.DbSet<WebApplication3.Models.Branch> Branches { get; set; }

        public System.Data.Entity.DbSet<WebApplication3.Models.Qualification> Qualifications { get; set; }

        public System.Data.Entity.DbSet<WebApplication3.Models.Employee> Employees { get; set; }
    }
}
