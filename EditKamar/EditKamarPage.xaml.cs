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

        public EditKamarPage()
        {
            InitializeComponent();
            setController(new EditKamarController(this, 10));
            initUIBuilders();
            initUIElements();
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
        }

        public void setCurrentRoomValue(
            string _roomType,
            string _bedType,
            long _roomPrice,
            int _guestCapacity
            )
        {
            roomTypeTxtBox.setText(_roomType);
            bedTypeTxtBox.setText(_bedType);
            roomPriceTxtBox.setText(Convert.ToString(_roomPrice));
            guestCapacityTxtBox.setText(Convert.ToString(_guestCapacity));
        }
    }
}
