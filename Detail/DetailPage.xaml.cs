using Hotelin_Desktop.DetailKamar;
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

namespace Hotelin_Desktop.Detail
{
    /// <summary>
    /// Interaction logic for DetailPage.xaml
    /// </summary>
    public partial class DetailPage : MyPage
    {
        private DetailKamarPage detailKamarPage;
        public DetailPage()
        {
            InitializeComponent();
            detailKamarPage = new DetailKamarPage();
            setController(new RoomListController(this));
            getRoomList();
           
        }

        public void getRoomList()
        {
            string token = File.ReadAllText(@"userToken.txt");
            Console.WriteLine("MASUK : " + token);
            getController().callMethod("requestRoomList", token);

        }

        public void setRoomList(List<Room> roomList)
        {
            string image_url = MyURL.MyURL.imageURL;
            Console.WriteLine("DATA KAMAR");
            foreach (Room room in roomList)
            {
                this.Dispatcher.Invoke(() =>
                {
                    kamar_datagrid.Items.Add(room);
                });

            }

        }

        private void view_btn_Click(object sender, RoutedEventArgs e)
        {
            appFrame.Navigate(detailKamarPage);
        }

        private void edit_btn_Click(object sender, RoutedEventArgs e)
        {
        }

        private void delete_btn_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}
