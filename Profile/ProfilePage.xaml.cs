using Hotelin_Desktop.AddHotel;
using Hotelin_Desktop.Dashboard;
using Hotelin_Desktop.EditHotel;
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

namespace Hotelin_Desktop.Profile
{
    /// <summary>
    /// Interaction logic for ProfilePage.xaml
    /// </summary>
    public partial class ProfilePage : MyPage
    {
        private HotelProfile profile;
        public ProfilePage()
        {
            InitializeComponent();
            setController(new ProfileController(this));
            getProfile();
        }

        private void addProfileButton_Click(object sender, RoutedEventArgs e)
        {
            AddHotelPage addHotelPage = new AddHotelPage();
            NavigationService.Navigate(addHotelPage);

        }

        private void editProfileButton_Click(object sender, RoutedEventArgs e)
        {
            EditHotelPage editHotelPage = new EditHotelPage();
            NavigationService.Navigate(editHotelPage);
        }

        private void getProfile()
        {
            string token = File.ReadAllText(@"userToken.txt");Console.WriteLine(token);
            getController().callMethod("requestProfile", token);
        }

        public void setProfile(HotelProfile profile)
        {
            string image_url = MyURL.MyURL.imageURL;
            foreach (Hotel hotel in profile.hotel)
            {
                this.Dispatcher.Invoke(() =>
                {
                    hotel_name_label.Content = hotel.hotel_name;
                    hotel_location_label.Content = hotel.hotel_location;
                    hotel_desc_label.Text = hotel.hotel_desc;
                    hotel_price_label.Content = hotel.hotel_price.ToString("C", CultureInfo.CurrentCulture) + ",00";
                    hotel_rating_label.Content = hotel.hotel_rating + "/5";
                    BitmapImage bitmap = new BitmapImage();
                    if(hotel.hotel_picture != null) { 
                    bitmap.BeginInit();
                    bitmap.UriSource = new Uri(@image_url+hotel.hotel_picture);
                    bitmap.EndInit();
                    hotel_img.Source = bitmap;
                    }
                });
                

            }

            int star_count = (int) profile.hotel[0].hotel_rating;
            Image[] star_list = { star1, star2, star3, star4, star5 };
            for(int j=0; j<star_count; j++)
            {
                this.Dispatcher.Invoke(() =>
                {
                    star_list[j].Source = new BitmapImage(new Uri("star.png", UriKind.Relative));
                });
            }
            Image[] room_image_list = { room_img1, room_img2, room_img3, room_img4};
            int i = 0;
            foreach (Room room in profile.room)
            {

                this.Dispatcher.Invoke(() =>
                {
                    BitmapImage bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.UriSource = new Uri(@image_url + room.room_picture);
                    bitmap.EndInit();
                    room_image_list[i].Source = bitmap;
                });
            }
           
            Label[] facility_list = { facility1_label, facility2_label, facility3_label, facility4_label };
            foreach (RoomFacility facility in profile.facility)
            {

                this.Dispatcher.Invoke(() =>
                {
                    facility_list[facility.id-1].Content = facility.facility_name;
                });
            }
               
        }

        
    }
}
