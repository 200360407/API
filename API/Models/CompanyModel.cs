using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;

namespace API.Models
{
    public class CompanyModel : DbContext
    {
        

        // constructor
        public CompanyModel(DbContextOptions<CompanyModel> options) : base(options) { }

       

        public DbSet<company> company { get; set; }

       

        public DbSet<API.Models.child> child { get; set; }
    }
}
