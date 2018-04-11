using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class CompanyModel : DbContext
    {
        

        // constructor
        public CompanyModel(DbContextOptions<CompanyModel> options) : base(options) { }

        public DbSet<child> children{ get; set; }
    }
}
