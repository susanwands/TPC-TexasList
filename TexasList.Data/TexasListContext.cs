using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TexasList.Data.Models;

namespace TexasList.Data
{
    public class TexasListContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Subcategory> Subcategories { get; set; }
        public DbSet<PostSubcategory> PostSubcategories { get; set; }


    }
}
