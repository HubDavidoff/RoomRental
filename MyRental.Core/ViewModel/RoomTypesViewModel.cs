using MyRental.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRental.Core.ViewModel
{
    public class RoomTypesViewModel
    {
        public Room Room { get; set; }
        public IEnumerable<RoomType> typeList { get; set; }
    }
}
