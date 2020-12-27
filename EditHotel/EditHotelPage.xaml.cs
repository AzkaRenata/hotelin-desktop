using Hotelin_Desktop.Model;
using Hotelin_Desktop.Profile;
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

namespace Hotelin_Desktop.EditHotel
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class EditHotelPage : MyPage
    {
        private BuilderButton buttonBuilder;
        private BuilderTextBox txtBoxBuilder;
        private IMyButton updateHotelButton;
        private IMyTextBox hotelNameTxtBox;
        private IMyTextBox hotelLocationTxtBox;
        private IMyTextBox hotelDescriptionTxtBox;
        private HotelProfile currentHotel;

        public EditHotelPage()
        {
            InitializeComponent();
            setController(new EditHotelController(this, 21));
            initUIBuilders();
            initUIElements();
        }

        //private void simpan_btn_Click(object sender, RoutedEventArgs e)
        //{
            //ProfilePage profilePage = new ProfilePage();
            //NavigationService.Navigate(profilePage);
        //}

        private void initUIBuilders()
        {
            buttonBuilder = new BuilderButton();
            txtBoxBuilder = new BuilderTextBox();
        }

        private void initUIElements()
        {
            updateHotelButton = buttonBuilder.activate(this, "simpan_btn")
                .addOnClick(this, "onUpdateHotelButtonClick");
            hotelNameTxtBox = txtBoxBuilder.activate(this, "nama_hotel_txt");
            hotelLocationTxtBox = txtBoxBuilder.activate(this, "lokasi_hotel_txt");
            hotelDescriptionTxtBox = txtBoxBuilder.activate(this, "deskripsi_hotel_txt");
        }

        public void onUpdateHotelButtonClick()
        {
            getController().callMethod("updateHotel",
                hotelNameTxtBox.getText(),
                hotelLocationTxtBox.getText(),
                hotelDescriptionTxtBox.getText());

            ProfilePage profile = new ProfilePage();
            NavigationService.Navigate(profile);
        }

        public void setCurrentHotelValue(HotelProfile hotelProfile)
        {
            foreach (Hotel hotel in hotelProfile.hotel)
            {
                hotelNameTxtBox.setText(hotel.hotel_name);
                hotelLocationTxtBox.setText(hotel.hotel_location);
                hotelDescriptionTxtBox.setText(hotel.hotel_desc);
            }
            
        }
    }
}
