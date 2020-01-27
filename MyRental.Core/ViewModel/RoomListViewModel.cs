using MyRental.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRental.Core.ViewModel
{
    public class RoomListViewModel
    {
        public IEnumerable<Room> Room { get; set; }
        public IEnumerable<RoomType> TypeList { get; set; }
    }
}
