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
        public int days_count { get; set; }
        public int total_price { get; set; }

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
