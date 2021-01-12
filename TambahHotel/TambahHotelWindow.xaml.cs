using Hotelin_Desktop.TambahHotel;
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

namespace Hotelin_Desktop.TambahHotel
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class TambahHotelPage : MyWindow
    {
        private BuilderButton buttonBuilder;
        private BuilderTextBox txtBoxBuilder;
        private IMyButton addHotelButton;
        private IMyTextBox hotelNameTxtBox;
        private IMyTextBox hotelLocationTxtBox;
        private IMyTextBox hotelDescriptionTxtBox;

        public TambahHotelPage()
        {
            InitializeComponent();
            setController(new TambahHotelController(this));
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
            addHotelButton = buttonBuilder.activate(this, "register_btn")
                .addOnClick(this, "onAddHotelButtonClick");
            hotelNameTxtBox = txtBoxBuilder.activate(this, "nama_hotel_txt");
            hotelLocationTxtBox = txtBoxBuilder.activate(this, "lokasi_txt");
            hotelDescriptionTxtBox = txtBoxBuilder.activate(this, "deskripsi_txt");
        }

        public void onAddHotelButtonClick()
        {
            getController().callMethod("addHotel",
                hotelNameTxtBox.getText(),
                hotelLocationTxtBox.getText(),
                hotelDescriptionTxtBox.getText(),
                3); // User ID
        }
    }
}
