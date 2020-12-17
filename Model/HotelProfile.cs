using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Hotelin_Desktop.Model
{
    public class Hotel : INotifyPropertyChanged
    {
        public int id { get; set; }
        public string hotel_name { get; set; }
        public string hotel_location { get; set; }
        public string hotel_desc { get; set; }
        public string hotel_picture { get; set; }
        public int user_id { get; set; }
        public double hotel_rating { get; set; }
        public double hotel_price { get; set; }
 

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            
        }
    }

    public class Room : INotifyPropertyChanged
    {
        public int id { get; set; }
        public string room_type { get; set; }
        public double room_price { get; set; }
        public string bed_type { get; set; }
        public int guest_capacity { get; set; }
        public string room_picture { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class RoomFacility : INotifyPropertyChanged
    {
        public int id { get; set; }
        public string facility_name { get; set; }
        public string facility_icon { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class HotelProfile
    {
        
        public List<Hotel> hotel { get; set; }
        public List<Room> room { get; set; }
        public List<RoomFacility> facility { get; set; }
    }
}
