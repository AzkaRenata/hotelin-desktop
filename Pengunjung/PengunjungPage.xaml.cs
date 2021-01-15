using Hotelin_Desktop.Model;
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
using Hotelin_Desktop.DetailBooking;

namespace Hotelin_Desktop.Pengunjung
{
    /// <summary>
    /// Interaction logic for PengunjungPage.xaml
    /// </summary>
    public partial class PengunjungPage : MyPage
    {
        private List<BookingModel> bookingList;
        private List<int> actualId = new List<int>();
        private String token;

        public PengunjungPage()
        {
            InitializeComponent();
            setController(new PengunjungController(this));
            getBookingHistory();
        }

        private void getBookingHistory()
        {
            token = File.ReadAllText(@"userToken.txt");
            Console.WriteLine("MASUK : " + token);
            getController().callMethod("requestBookingHistory", token);
        }


        public void setPengunjung(List<BookingModel> bookingList)
        {
            string base_url = MyURL.MyURL.baseURL;
            foreach (BookingModel booking in bookingList)
            {
                this.Dispatcher.Invoke(() =>
                {
                    pengunjung_datagrid.Items.Add(booking);
                });

            }
        }


        private void view_btn_Click(object sender, RoutedEventArgs e)
        {
            int id = (pengunjung_datagrid.SelectedItem as BookingModel).id;
            DetailBookingPage detailBooking = new DetailBookingPage(id);
            NavigationService.Navigate(detailBooking);

        }
    }
}
