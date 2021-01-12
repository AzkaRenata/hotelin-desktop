using Hotelin_Desktop.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
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
            string status;
            this.Dispatcher.Invoke(() =>
            {
                name_label.Content = bookingDetail.user.name;
                email_label.Content = bookingDetail.user.email;
                telp_label.Content = bookingDetail.user.telp;
                room_code_label.Content = bookingDetail.room.room_code;
                check_in_label.Content = bookingDetail.booking.check_in;
                check_out_label.Content = bookingDetail.booking.check_out;
                booking_time_label.Content = bookingDetail.booking.booking_time;
                price_label.Content = bookingDetail.booking.total_price.ToString("C", CultureInfo.CurrentCulture) + ",00";
                days_count_label.Content = bookingDetail.booking.days_count + " Hari";

                if (bookingDetail.booking.booking_status == 1)
                    status = "Ongoing";
                else if (bookingDetail.booking.booking_status == 2)
                    status = "Done";
                else
                    status = "Canceled";
                status_label.Content = "Status : " + status;



                BitmapImage bitmap = new BitmapImage();
                if (bookingDetail.user.user_picture != null)
                {
                    ImageBrush ImgBrush = new ImageBrush();
                    ImgBrush.ImageSource = new BitmapImage(
                        new Uri(@image_url + bookingDetail.user.user_picture));
                    user_picture.Fill = ImgBrush;
                }
            });
        }
    }
}
