using Hotelin_Desktop.Model;
using Hotelin_Desktop.DetailPengunjung;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Velacro.UIElements.Basic;
using Velacro.UIElements.Button;
using Velacro.UIElements.TextBlock;
using Velacro.UIElements.TextBox;

namespace Hotelin_Desktop.Pengunjung
{
    /// <summary>
    /// Interaction logic for PengunjungPage.xaml
    /// </summary>
    public partial class PengunjungPage : MyPage
    {
        private List<BookingModel> bookingList;
        private List<int> actualId = new List<int>();
        private DetailPengunjungPage detailPengunjungPage;
        
        public PengunjungPage()
        {
            InitializeComponent();
            setController(new PengunjungController(this));
            Pengunjung olivia = new Pengunjung();
            olivia.namaPemesan = "Olivia";
            olivia.tanggalMenginap = "3-5 Oktober";
            olivia.tipeKamar = "Presidental Suite";
            olivia.harga = "Rp. 1.626.804";

            pengunjung_datagrid.Items.Add(olivia);
            getBookingHistory();
        }

        private void getBookingHistory()
        {
            string token = File.ReadAllText(@"userToken.txt");
            Console.WriteLine("MASUK : " + token);
            getController().callMethod("requestBookingHistory", token);
        }

        public void setBookingHistory(List<BookingModel> bookings)
        {
            int id = 1;
            this.bookingList = bookings;

            actualId.Clear();
            foreach (BookingModel booking in bookings)
            {
                Console.WriteLine(booking.id);
                Console.WriteLine(booking.name);
                Console.WriteLine(booking.room_id);
                Console.WriteLine(booking.room_price);
                Console.WriteLine(booking.room_type);
                Console.WriteLine(booking.booking_status);
            }
            Console.WriteLine("");
            Console.WriteLine("");
        }

        public class Pengunjung
        {
            public string namaPemesan { get; set; }
            public string tanggalMenginap { get; set; }
            public string tipeKamar { get; set; }
            public string harga { get; set; }
        }

        private void view_btn_Click(object sender, RoutedEventArgs e)
        {
            //appFrame.Navigate(detailPengunjungPage);
        }

        private void delete_btn_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}
