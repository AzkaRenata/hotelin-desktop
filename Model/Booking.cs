using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotelin_Desktop.Model
{
    public class Booking
    {
        public BookingModel booking { get; set; }
        public UserModel user { get; set; }
        public Room room { get; set; }
    }
}
