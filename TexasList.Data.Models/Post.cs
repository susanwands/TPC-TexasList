using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TexasList.Data.Models
{
    public class Post
    {
        public int PostId { get; set; }

        public string Title { get; set; }
        public string AdBody { get; set; }
        public string Amount { get; set; }

        public virtual List<PostSubcategory> PostSubcategories { get; set; }
      

        public int UserId { get; set; }
        public virtual User User { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public int CityId { get; set; }
        public virtual City City { get; set; }





    }
}
