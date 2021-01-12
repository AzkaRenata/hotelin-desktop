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
using Velacro.Basic;
using Velacro.UIElements.Basic;
using Velacro.UIElements.Button;
using Velacro.UIElements.TextBox;

namespace Hotelin_Desktop.UpdateHotel
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

        public EditHotelPage()
        {
            InitializeComponent();
            setController(new UpdateHotelController(this, 21));
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
            updateHotelButton = buttonBuilder.activate(this, "update_hotel_btn")
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
        }

        public void setCurrentHotelValue(string _hotelName, string _hotelLocation, string _hotelDesc) 
        {
            hotelNameTxtBox.setText(_hotelName);
            hotelLocationTxtBox.setText(_hotelLocation);
            hotelDescriptionTxtBox.setText(_hotelDesc);
        }
    }

    internal class UpdateHotelController : IMyController
    {
        private EditHotelPage editHotelPage;
        private int v;

        public UpdateHotelController(EditHotelPage editHotelPage, int v)
        {
            this.editHotelPage = editHotelPage;
            this.v = v;
        }

        public void callMethod(string _methodName)
        {
            throw new NotImplementedException();
        }

        public void callMethod(string _methodName, params object[] _parameters)
        {
            throw new NotImplementedException();
        }
    }
}
