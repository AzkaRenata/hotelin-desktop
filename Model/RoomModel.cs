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
        public string room_code { get; set; }
        public string room_type { get; set; }
        public string bed_type { get; set; }
        public int bed_count { get; set; }
        public long room_price { get; set; }
        public int guest_capacity { get; set; }
        public string room_picture { get; set; }
        public int hotel_id { get; set; }
    }

    public class RoomResponse
    {
        internal string room_type;
        internal string bed_type;
        internal long room_price;
        internal int guest_capacity;

        public HotelModel hotel { get; set; }
        public RoomModel room { get; set; }
        public List<object> facility { get; set; }
    }
}
