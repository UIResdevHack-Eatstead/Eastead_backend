﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Valuegate.Common.Types;

namespace Eatstead.Domain.Entities
{
    public class Cafeteria 
    {
        public int Id { get; set; }
        public string BusinessName { get; set; }
        public string HallName { get; set; }
        public string ProductPicture { get; set; }
        public int Review { get; set; }
        public int Rating { get; set; }
        public DateTime OpeningTime { get; set; }
        public DateTime ClosingTime { get; set;}
        public string Address { get; set; }
        public bool IsAvailable { get; set; }
        public string UserId { get; set; }
        public ICollection<Menu> Foods { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
