using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Hotelin_Desktop.Model
{
    public class BookingModel : INotifyPropertyChanged
    {
        public int id { get; set; }
        public int user_id { get; set; }
        public int room_id { get; set; }
        public string room_code { get; set; }
        public int booking_status { get; set; }
        public string check_in { get; set; }
        public string check_out { get; set; }
        public string booking_time { get; set; }
        public string hotel_name { get; set; }
        public string room_type { get; set; }
        public string bed_type { get; set; }
        public int room_price { get; set; }
        public string name { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class BookingList
    {
        public List<BookingModel> booking { get; set; }
    }
}
