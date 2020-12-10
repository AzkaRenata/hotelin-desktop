using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotelin_Desktop.Model
{
    public class RoomModel
    {
        public int id { get; set; }
        public string room_type { get; set; }
        public string bed_type { get; set; }
        public long room_price { get; set; }
        public int guest_capacity { get; set; }
        public string room_picture { get; set; }
        public int hotel_id { get; set; }
    }

    public class RoomResponse
    {
        public HotelModel hotel { get; set; }
        public RoomModel room { get; set; }
        public List<object> facility { get; set; }
    }
}
