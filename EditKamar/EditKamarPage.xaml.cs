using Hotelin_Desktop.Detail;
using Hotelin_Desktop.Model;
using System;
using System.Collections.Generic;
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
using Velacro.UIElements.TextBox;

namespace Hotelin_Desktop.EditKamar
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class EditKamarPage : MyPage
    {
        private BuilderButton buttonBuilder;
        private BuilderTextBox txtBoxBuilder;
        private IMyButton updateRoomButton;
        private IMyTextBox roomTypeTxtBox;
        private IMyTextBox bedTypeTxtBox;
        private IMyTextBox roomPriceTxtBox;
        private IMyTextBox guestCapacityTxtBox;

        public EditKamarPage(int id)
        {
            InitializeComponent();
            setController(new EditKamarController(this, id));
            initUIBuilders();
            initUIElements();
            //initRoomData(id);
        }

        private void initUIBuilders()
        {
            buttonBuilder = new BuilderButton();
            txtBoxBuilder = new BuilderTextBox();
        }

        private void initUIElements()
        {
            updateRoomButton = buttonBuilder.activate(this, "edit_kamar_btn")
                .addOnClick(this, "onEditRoomButtonClick");
            roomTypeTxtBox = txtBoxBuilder.activate(this, "tipe_kamar_txt");
            bedTypeTxtBox = txtBoxBuilder.activate(this, "tipe_kasur_txt");
            roomPriceTxtBox = txtBoxBuilder.activate(this, "harga_kamar_txt");
            guestCapacityTxtBox = txtBoxBuilder.activate(this, "kapasitas_tamu_txt");
        }

        public void onEditRoomButtonClick()
        {
            //Console.WriteLine("Kepencet");

            getController().callMethod("updateKamar",
                roomTypeTxtBox.getText(),
                bedTypeTxtBox.getText(),
                long.Parse(roomPriceTxtBox.getText()),
                int.Parse(guestCapacityTxtBox.getText())
                );

            DetailPage detail = new DetailPage();
            NavigationService.Navigate(detail);
        }

        public void setCurrentRoomValue(RoomResponse roomResponse)
        {
            RoomModel room = roomResponse.room;

            roomTypeTxtBox.setText(room.room_type);
            bedTypeTxtBox.setText(room.bed_type);
            roomPriceTxtBox.setText(Convert.ToString(room.room_price));
            guestCapacityTxtBox.setText(Convert.ToString(room.guest_capacity));
        }

        private void pilih_gambar_btn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
