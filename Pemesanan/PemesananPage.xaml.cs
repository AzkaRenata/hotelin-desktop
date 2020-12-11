using Hotelin_Desktop.Model;
using Hotelin_Desktop.DetailPemesanan;
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

namespace Hotelin_Desktop.Pemesanan
{
    /// <summary>
    /// Interaction logic for PemesananPage.xaml
    /// </summary>
    public partial class PemesananPage : MyPage
    {
        //private List<int> actualId = new List<int>();
        private DetailPemesananPage detailPemesananPage;
        private string token;


        public PemesananPage()
        {
            InitializeComponent();
            setController(new PemesananController(this));
            this.detailPemesananPage = new DetailPemesananPage();
            /*Pemesanan olivia = new Pemesanan();
            olivia.namaPemesan = "Olivia";
            olivia.tanggalMenginap = "3-5 Oktober";
            olivia.tipeKamar = "Presidental Suite";
            olivia.harga = "Rp. 1.626.804";

            pemesanan_datagrid.Items.Add(olivia);*/
            
            getBookingHistory();
        }

        private void getBookingHistory()
        {
            token = File.ReadAllText(@"userToken.txt");
            Console.WriteLine("MASUK : " + token);
            getController().callMethod("requestBookingHistory", token);
        }

        /*public void setBookingHistory(List<BookingModel> bookings)
        {
            *//*int id = 1;
            this.bookingList = bookings;

            actualId.Clear();*//*
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
        }*/

        public void setPemesanan(List<BookingModel> bookingList) {
            string base_url = MyURL.MyURL.baseURL;
            Console.WriteLine("DATA KAMAR");
            foreach (BookingModel booking in bookingList)
            {
                this.Dispatcher.Invoke(() =>
                {
                    pemesanan_datagrid.Items.Add(booking);
                });

            }
        }
/*
        public class Pemesanan
        {
            public string namaPemesan { get; set; }
            public string tanggalMenginap { get; set; }
            public string tipeKamar { get; set; }
            public string harga { get; set; }
        }*/

        private void view_btn_Click(object sender, RoutedEventArgs e)
        {
          /*  int id = (pemesanan_datagrid.SelectedItem as Room).id;
            DetailPemesananPage detailKamarPage = new DetailPemesananPage(id);
            NavigationService.Navigate(detailKamarPage);*/
        }

        // private void edit_btn_Click(object sender, RoutedEventArgs e)
        // {
        // }

        private void delete_btn_Click(object sender, RoutedEventArgs e)
        {
            /*int id = (pemesanan_datagrid.SelectedItem as Room).id;
            MessageBoxResult result = System.Windows.MessageBox.Show("Are you sure?", "Delete Confirmation", System.Windows.MessageBoxButton.YesNo);
            if(result == MessageBoxResult.Yes)
            {
                getController().callMethod("deleteRoom", token, id);
            }*/
        }
    }
}
