using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TexasList.Data.Models;

namespace TexasList.Models
{
    public class ViewModel
    {
        public List<Category> Categories { get; set; }
        public List<City> Cities { get; set; }
        public List<Post> Posts { get; set; }
        public List<User> Users { get; set; }
        public List<Subcategory> Subcategories { get; set; }
        public List<PostSubcategory> PostSubcategories { get; set; }

    }
}