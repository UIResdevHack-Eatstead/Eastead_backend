using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Valuegate.Common.Types;

namespace Eatstead.Domain.Entities
{
    public class Menu
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }
        [ForeignKey("Cafeteria")]
        public int CafeteriaId { get; set; }
        public virtual Cafeteria Cafeteria { get; set; }
    }
}
