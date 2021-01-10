using Hotelin_Desktop.DetailKamar;
using Hotelin_Desktop.EditKamar;
using Hotelin_Desktop.FasilitasKamar;
using Hotelin_Desktop.Model;
using Hotelin_Desktop.TambahKamar;
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
        private BuilderButton buttonBuilder;
        private string token;
        public DetailPage()
        {
            InitializeComponent();
            initUIBuilders();
            initUIElements();
            setController(new RoomListController(this));
            token = File.ReadAllText(@"userToken.txt");
            getRoomList();

        }

        private void initUIBuilders()
        {
            buttonBuilder = new BuilderButton();
        }

        private void initUIElements()
        {
            /*viewButton = buttonBuilder
                .activate(this, "view_btn")
                .addOnClick(this, "onViewBtnClick");*/
            /*emailTxtBox = txtBoxBuilder.activate(this, "email_txt");
            passwordTxtBox = txtBoxBuilder.activate(this, "password_txt");
            loginStatusTxtBlock = txtBlockBuilder.activate(this, "loginStatus");*/
        }

        public void getRoomList()
        {
            this.Dispatcher.Invoke(() =>
            {
                kamar_datagrid.Items.Clear();
            });
            Console.WriteLine("MASUK COYYYY: " + token);
            getController().callMethod("requestRoomList", token);

        }

        public void setRoomList(List<Room> roomList)
        {
            string image_url = MyURL.MyURL.imageURL;
            Console.WriteLine("DATA KAMAR");
            foreach (Room room in roomList)
            {
                Console.WriteLine(room.bed_type);
                this.Dispatcher.Invoke(() =>
                {
                    kamar_datagrid.Items.Add(room);
                });

            }

        }

        private void addKamarButton_Click(object sender, RoutedEventArgs e)
        {
            TambahKamarPage tambahKamarPage = new TambahKamarPage();
            NavigationService.Navigate(tambahKamarPage);
        }

        private void view_btn_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("MASUK VIEWWWWWW ");
            int id = (kamar_datagrid.SelectedItem as Room).id;
            DetailKamarPage detailKamarPage = new DetailKamarPage(id);
            NavigationService.Navigate(detailKamarPage);
        }

        private void edit_btn_Click(object sender, RoutedEventArgs e)
        {
            int id = (kamar_datagrid.SelectedItem as Room).id;
            EditKamarPage editKamarPage = new EditKamarPage(id);
            NavigationService.Navigate(editKamarPage);
        }

        private void delete_btn_Click(object sender, RoutedEventArgs e)
        {
            int id = (kamar_datagrid.SelectedItem as Room).id;
            MessageBoxResult result = System.Windows.MessageBox.Show("Are you sure?", "Delete Confirmation", System.Windows.MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                getController().callMethod("deleteRoom", token, id);
            }
        }
    }
}
