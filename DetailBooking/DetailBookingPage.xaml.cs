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

namespace Hotelin_Desktop.DetailBooking
{
    /// <summary>
    /// Interaction logic for DetailPembatalanPage.xaml
    /// </summary>
    public partial class DetailBookingPage : MyPage
    {
        public DetailBookingPage(int id)
        {
            InitializeComponent();
            setController(new DetailBookingController(this));
            getBookingDetail(id);
        }

        public void getBookingDetail(int id)
        {
            string token = File.ReadAllText(@"userToken.txt");
            getController().callMethod("requestBookingDetail", token, id);

        }

        public void setBookingDetail(Booking bookingDetail)
        {
            string image_url = MyURL.MyURL.imageURL;
            //Console.WriteLine("NAME : " + bookingDetail.name);
            this.Dispatcher.Invoke(() =>
            {
                name_label.Content = bookingDetail.booking.name;
                email_label.Content = bookingDetail.booking.email;
                telp_label.Content = bookingDetail.booking.telp;
                check_in_label.Content = bookingDetail.booking.check_in;
                check_out_label.Content = bookingDetail.booking.check_out;
                booking_time_label.Content = bookingDetail.booking.booking_time;
                price_label.Content = bookingDetail.booking.total_price;
                days_count_label.Content = bookingDetail.booking.days_count + " Hari";
                room_code_label.Content = bookingDetail.booking.room_code;

                if (bookingDetail.booking.booking_status == 1)
                    status_label.Content = "Status : Ongoing";
                else if (bookingDetail.booking.booking_status == 2)
                    status_label.Content = "Status : Done"; 
                else
                    status_label.Content = "Status : Canceled"; 



                BitmapImage bitmap = new BitmapImage();
                if (bookingDetail.booking.user_picture != null) { 
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(@image_url + bookingDetail.booking.user_picture);
                bitmap.EndInit();
                user_picture.Source = bitmap;
                }
            });
        }
    }
}
