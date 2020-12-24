using Hotelin_Desktop.Model;
using Hotelin_Desktop.DetailPembatalan;
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

namespace Hotelin_Desktop.Pembatalan
{
    /// <summary>
    /// Interaction logic for PembatalanPage.xaml
    /// </summary>
    public partial class PembatalanPage : MyPage
    {
        private List<BookingModel> bookingList;
        private List<int> actualId = new List<int>();
        private DetailPembatalanPage detailPembatalanPage;
        private string token;


        public PembatalanPage()
        {
            InitializeComponent();
            setController(new PembatalanController(this));
            this.detailPembatalanPage = new DetailPembatalanPage(1);
            /*Pembatalan olivia = new Pembatalan();
            olivia.namaPemesan = "Olivia";
            olivia.tanggalMenginap = "3-5 Oktober";
            olivia.tipeKamar = "Presidental Suite";
            olivia.harga = "Rp. 1.626.804";

            pembatalan_datagrid.Items.Add(olivia);*/
            getBookingHistory();
        }

        private void getBookingHistory()
        {
            token = File.ReadAllText(@"userToken.txt");
            Console.WriteLine("MASUK : " + token);
            getController().callMethod("requestBookingHistory", token);
        }

        public void setBookingHistory(List<BookingModel> bookings)
        {
            /*int id = 1;
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
            Console.WriteLine("");*/
        }

        public void setPembatalan(List<BookingModel> bookingList)
        {
            string base_url = MyURL.MyURL.baseURL;
            Console.WriteLine("DATA KAMAR");
            foreach (BookingModel booking in bookingList)
            {
                this.Dispatcher.Invoke(() =>
                {
                    pembatalan_datagrid.Items.Add(booking);
                });

            }
        }

        public class Pembatalan
        {
            public string namaPemesan { get; set; }
            public string tanggalMenginap { get; set; }
            public string tipeKamar { get; set; }
            public string harga { get; set; }
        }

        private void view_btn_Click(object sender, RoutedEventArgs e)
        {
            int id = (pembatalan_datagrid.SelectedItem as Room).id;
            DetailPembatalanPage detailPembatalanPage = new DetailPembatalanPage(id);
            NavigationService.Navigate(detailPembatalanPage);
           
        }

        // private void edit_btn_Click(object sender, RoutedEventArgs e)
        // {
        // }

        private void delete_btn_Click(object sender, RoutedEventArgs e)
        {
            int id = (pembatalan_datagrid.SelectedItem as Room).id;
            MessageBoxResult result = System.Windows.MessageBox.Show("Are you sure?", "Delete Confirmation", System.Windows.MessageBoxButton.YesNo);
            if(result == MessageBoxResult.Yes)
            {
                getController().callMethod("deleteRoom", token, id);
            }
        }
    }
}
