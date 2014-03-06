using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TexasList.Data.Models
{
    public class PostSubcategory
    {
        public int PostSubcategoryId { get; set; }

        public int PostId { get; set; }
        public virtual Post Post { get; set; }

        public int SubcategoryId { get; set; }
        public virtual Subcategory Subcategory { get; set; }
    }
}
