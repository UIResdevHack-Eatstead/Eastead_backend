﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Valuegate.Common.Types;

namespace Eatstead.Domain.Entities
{
    public class Menu: BaseEntity<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }
        public int CafeteriaId { get; set; }
        public Cafeteria Cafeteria { get; set; }
    }
}
