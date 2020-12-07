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

namespace Hotelin_Desktop.DetailKamar
{
    /// <summary>
    /// Interaction logic for DetailKamarPage.xaml
    /// </summary>
    public partial class DetailKamarPage : MyPage
    {
        public DetailKamarPage(int room_id)
        {
            InitializeComponent();
            setController(new RoomDetailController(this));
            getRoomDetail(room_id);
        }

        public void getRoomDetail(int id)
        {
            string token = File.ReadAllText(@"userToken.txt");
            getController().callMethod("requestRoomDetail", token, id);

        }

        public void setRoomDetail(RoomDetail roomDetail)
        {
            string image_url = MyURL.MyURL.imageURL;
            this.Dispatcher.Invoke(() =>
            {
                room_type_label.Content = roomDetail.room.room_type;
                room_price_label.Content = roomDetail.room.room_price;
                guest_capacity_label.Content = roomDetail.room.guest_capacity;
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(@image_url + roomDetail.room.room_picture);
                bitmap.EndInit();
                room_image.Source = bitmap;
            });

            Label[] facility_label = { facility1, facility2, facility3};
            int i = 0;
            foreach (RoomFacility facility in roomDetail.facility)
            {

                this.Dispatcher.Invoke(() =>
                {
                    facility_label[i].Content = facility.facility_name;
                });
                i++;
            }
        }

        private void room_edit_btn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
