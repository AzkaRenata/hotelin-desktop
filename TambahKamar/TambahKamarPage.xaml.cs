using Hotelin_Desktop.TambahKamar;
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

namespace Hotelin_Desktop.TambahKamar
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class TambahKamarPage : MyPage
    {
        private BuilderButton buttonBuilder;
        private BuilderTextBox txtBoxBuilder;
        private IMyButton addRoomButton;
        private IMyTextBox roomTypeTxtBox;
        private IMyTextBox bedTypeTxtBox;
        private IMyTextBox guestCapacityTxtBox;
        private IMyTextBox roomPriceTxtBox;

        private int HOTEL_ID = 21;

        public TambahKamarPage()
        {
            InitializeComponent();
            setController(new TambahKamarController(this));
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
            addRoomButton = buttonBuilder.activate(this, "add_kamar_btn")
                .addOnClick(this, "onAddRoomButtonClick");
            roomTypeTxtBox = txtBoxBuilder.activate(this, "tipe_kamar_txt");
            bedTypeTxtBox = txtBoxBuilder.activate(this, "tipe_kasur_txt");
            guestCapacityTxtBox = txtBoxBuilder.activate(this, "kapasitas_tamu_txt");
            roomPriceTxtBox = txtBoxBuilder.activate(this, "harga_kamar_txt");
        }

        public void onAddRoomButtonClick()
        {
            Console.WriteLine(roomTypeTxtBox.getText());
            Console.WriteLine(bedTypeTxtBox.getText());
            Console.WriteLine(roomPriceTxtBox.getText());
            Console.WriteLine(int.Parse(guestCapacityTxtBox.getText()));

            getController().callMethod("addKamar",
                HOTEL_ID,
                roomTypeTxtBox.getText(),
                bedTypeTxtBox.getText(),
                long.Parse(roomPriceTxtBox.getText()),
                int.Parse(guestCapacityTxtBox.getText())
            );
        }
    }
}
