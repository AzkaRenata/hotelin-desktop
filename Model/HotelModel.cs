using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Hotelin_Desktop.Model
{
    public class HotelModel : INotifyPropertyChanged
    {
        public int id { set; get; }
        public string hotel_name { set; get; }
        public string hotel_location { set; get; }
        public string hotel_desc { set; get; }
        public string hotel_picture { set; get; }
        public int user_id { set; get; }

        public event PropertyChangedEventHandler PropertyChanged;
    }

    public class HotelList
    {
        public List<HotelModel> hotel { get; set; }
    }
}
