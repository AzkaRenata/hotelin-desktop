using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Hotelin_Desktop.Model
{
    public class BookingDetail : INotifyPropertyChanged
    {
        public int id { get; set; }
        public int user_id { get; set; }
        public int room_id { get; set; }
        public int booking_status { get; set; }
        public string check_in { get; set; }
        public string check_out { get; set; }
        public string booking_time { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string telp { get; set; }
        public string user_picture { get; set; }
        public string days_count { get; set; }
        public string hotel_name { get; set; }
        public string hotel_picture { get; set; }
        public string hotel_location { get; set; }
        public string room_type { get; set; }
        public string bed_type { get; set; }
        public int room_price { get; set; }
        public int guest_capacity { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class DetailBooking
    {
        public BookingDetail booking { get; set; }
    }
}
