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
using Velacro.Basic;
using Velacro.LocalFile;
using Velacro.UIElements.Basic;
using Velacro.UIElements.Button;
using Velacro.UIElements.TextBlock;
using Velacro.UIElements.TextBox;

namespace Hotelin_Desktop.AddHotel
{
    /// <summary>
    /// Interaction logic for AddHotelPage.xaml
    /// </summary>
    public partial class AddHotelPage : MyPage
    {
        private BuilderButton buttonBuilder;
        private BuilderTextBox txtBoxBuilder;
        private BuilderTextBlock txtBlockBuilder;
        private IMyButton saveHotelButton;
        private IMyButton chooseImageButton;
        private IMyTextBox hotelNameTxtBox;
        private IMyTextBox hotelLocationTxtBox;
        private IMyTextBox hotelDescTxtBox;
        private IMyTextBlock imageTxtBlock;
        private byte[] fileByte = null;
        private string fullFileName = "";
        public AddHotelPage()
        {
            InitializeComponent();
            setController(new AddHotelController(this));
            initUIBuilders();
            initUIElements();
        }

        private void initUIBuilders()
        {
            buttonBuilder = new BuilderButton();
            txtBoxBuilder = new BuilderTextBox();
            txtBlockBuilder = new BuilderTextBlock();
        }

        private void initUIElements()
        {
            saveHotelButton = buttonBuilder.activate(this, "simpan_btn")
                .addOnClick(this, "onAddHotelButtonClick");
            chooseImageButton = buttonBuilder.activate(this, "pilih_gambar_btn")
                .addOnClick(this, "onChooseImageButtonClick");
            hotelNameTxtBox = txtBoxBuilder.activate(this, "nama_hotel_txt");
            hotelLocationTxtBox = txtBoxBuilder.activate(this, "lokasi_hotel_txt");
            hotelDescTxtBox = txtBoxBuilder.activate(this, "deskripsi_hotel_txt");
            imageTxtBlock = txtBlockBuilder.activate(this, "selected_image_tb");
        }

        public void onAddHotelButtonClick()
        {
            Hotel hotel = new Hotel();
            hotel.hotel_name = hotelNameTxtBox.getText();
            hotel.hotel_location = hotelLocationTxtBox.getText();
            hotel.hotel_desc = hotelDescTxtBox.getText();
            getController().callMethod("addHotel", hotel, fileByte, fullFileName);

        }

        private bool checkFileSize(string path)
        {
            FileInfo fi = new FileInfo(path);
            const double v = 1.049e+6;//convert byte to MB
            double fileSize = fi.Length / v;
            if (fileSize > 5)
            {
                MessageBox.Show("Image Too Large (Use Image Size <= 5MB)", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
                selected_image_tb.Text = "No Image Selected";
                return false;
            }
            else
            {
                fullFileName = System.IO.Path.GetFileName(path);
                fileByte = File.ReadAllBytes(path);
                selected_image_tb.Text = fullFileName;
                return true;
            }
        }

        public void onChooseImageButtonClick()
        {
            fileByte = null;
            fullFileName = "";
            OpenFile openFileDialog = new OpenFile();
            MyFile temp = openFileDialog.openFile(false)[0];
            if (
                temp.extension.Equals(".jpg", StringComparison.InvariantCultureIgnoreCase) ||
                temp.extension.Equals(".jpeg", StringComparison.InvariantCultureIgnoreCase) ||
                temp.extension.Equals(".png", StringComparison.InvariantCultureIgnoreCase) ||
                temp.extension.Equals(".jpg", StringComparison.InvariantCultureIgnoreCase))
            {
                checkFileSize(temp.fullPath);

            }
            else
            {
                MessageBox.Show("Only Support Image File", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
                selected_image_tb.Text = "No Image Selected";
            }

        }

        private void panel_DragOver(object sender, DragEventArgs e)
        {
            bool dropEnabled = true;
            if (e.Data.GetDataPresent(DataFormats.FileDrop, true))
            {
                string[] filenames =
                                 e.Data.GetData(DataFormats.FileDrop, true) as string[];
                string path = filenames[0];
                string extension = System.IO.Path.GetExtension(path).ToLowerInvariant();
                if (extension != ".jpg" && extension != ".jpeg" && extension != ".png")
                {
                    dropEnabled = false;
                }

            }
            else
            {
                dropEnabled = false;
            }

            if (!dropEnabled)
            {
                MessageBox.Show("Only Support Image File", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
                selected_image_tb.Text = "No Image Selected";
                e.Effects = DragDropEffects.None;
                e.Handled = true;
            }
        }

        private void panel_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                checkFileSize(files[0]);
            }
        }
    }
}
