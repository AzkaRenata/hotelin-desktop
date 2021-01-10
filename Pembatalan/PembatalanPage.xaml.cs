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
using Hotelin_Desktop.EditKamar;

namespace Hotelin_Desktop.Pembatalan
{
    /// <summary>
    /// Interaction logic for PembatalanPage.xaml
    /// </summary>
    public partial class PembatalanPage : MyPage
    {
        private string token;
        private BuilderButton buttonBuilder;


        public PembatalanPage()
        {
            InitializeComponent();
            initUIBuilders();
            setController(new PembatalanController(this));
            getBookingHistory();
        }

        private void initUIBuilders()
        {
            buttonBuilder = new BuilderButton();
            /*txtBoxBuilder = new BuilderTextBox();
            txtBlockBuilder = new BuilderTextBlock();*/
        }

        private void getBookingHistory()
        {
            this.Dispatcher.Invoke(() =>
            {
                pembatalan_datagrid.Items.Clear();
            });
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
            string image_url = MyURL.MyURL.imageURL;
            Console.WriteLine("DATA BOOKING");
            foreach (BookingModel booking in bookingList)
            {
                this.Dispatcher.Invoke(() =>
                {
                    pembatalan_datagrid.Items.Add(booking);
                });

            }
        }

        private void view_btn_Click(object sender, RoutedEventArgs e)
        {
            int id = (pembatalan_datagrid.SelectedItem as BookingModel).id;
            Console.WriteLine("ID : " + id);
            DetailBookingPage detailBooking = new DetailBookingPage(id);
            NavigationService.Navigate(detailBooking);
           
        }

    }
}
