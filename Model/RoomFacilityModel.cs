using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotelin_Desktop.Model
{
    public class RoomFacilityModel
    {
        public int id { get; set; }
        public int room_id { get; set; }
        public int facility_category_id { get; set; }
        public string description { get; set; }
    }
}
