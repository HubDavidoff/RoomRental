using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRental.Core.Model
{
    public class Room : BaseEntity
    {
        [StringLength(30)]
        public string Name { get; set; }
        public string Description { get; set; }
        [Range(10,300)]
        public decimal Price { get; set; }
        public string Type { get; set; }
        public string Image { get; set; }
    }
}
