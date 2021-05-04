using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.DataLayer.Models
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options){ 
        }

        public virtual DbSet<Ownerdetails> Ownerdetails { get; set; }
    }
}
