using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotelin_Desktop.Model
{
    public class RoomDetail
    {
        public Hotel hotel { get; set; }
        public Room room { get; set; }
        public List<RoomFacility> facility { get; set; }
    }
}
