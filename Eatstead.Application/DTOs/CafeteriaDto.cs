﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eatstead.Application.DTOs
{
    public class CafeteriaDto
    {
        public string UserId { get; set; }
        public string BusinessName { get; set; }
        public string HallName { get; set; }
        public string ProductPicture { get; set; }
        public int Review { get; set; }
        public int Rating { get; set; }
        public DateTime OpeningTime { get; set; }
        public DateTime ClosingTime { get; set; }
        public string Address { get; set; }
        public bool IsAvailable { get; set; }
    }
}
