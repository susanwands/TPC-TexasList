﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TexasList.Data.Models
{
    public class City
    {
        public int CityId { get; set; }
        public string CityName { get; set; }

        public List<Post> Posts { get; set; }
    }
}
