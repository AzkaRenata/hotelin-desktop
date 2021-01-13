using Hotelin_Desktop.Dashboard;
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
using System.Windows.Shapes;
using Velacro.Basic;
using Velacro.LocalFile;
using Velacro.UIElements.Basic;
using Velacro.UIElements.Button;
using Velacro.UIElements.TextBlock;
using Velacro.UIElements.TextBox;

namespace Hotelin_Desktop.Register
{
    /// <summary>
    /// Interaction logic for FormRegisterWindow.xaml
    /// </summary>
    public partial class FormRegisterWindow : MyWindow
    {

        private BuilderButton buttonBuilder;
        private BuilderTextBox txtBoxBuilder;
        private BuilderTextBlock txtBlockBuilder;
        private IMyButton registerButton;
        private IMyButton chooseImageButton;
        private IMyTextBox hotelNameTxtBox;
        private IMyTextBox locationTxtBox;
        private IMyTextBox descriptionTxtBox;
        private IMyTextBox bedCountTxtBox;
        private IMyTextBox guestCapacityTxtBox;
        private IMyTextBox roomPriceTxtBox;
        private IMyTextBlock imageTxtBlock;
        private byte[] fileByte = null;
        private string fullFileName = "";
        private MyWindow dashboardWindow;


        public FormRegisterWindow()
        {
            InitializeComponent();
            initUIBuilders();
            setController(new FormRegisterController(this));
        }

        private void initUIBuilders()
        {
            buttonBuilder = new BuilderButton();
            txtBoxBuilder = new BuilderTextBox();
            txtBlockBuilder = new BuilderTextBlock();
        }

        private void initUIElements()
        {
            registerButton = buttonBuilder.activate(this, "register_btn")
                .addOnClick(this, "register_btn_Click");
            chooseImageButton = buttonBuilder.activate(this, "pilih_gambar_btn")
                .addOnClick(this, "pilih_gambar_btn_Click");
            hotelNameTxtBox = txtBoxBuilder.activate(this, "nama_hotel_txt");
            locationTxtBox = txtBoxBuilder.activate(this, "lokasi_txt");
            descriptionTxtBox = txtBoxBuilder.activate(this, "deskripsi_txt");
            
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
                file_name_lbl.Content = "No Image Selected";
                e.Effects = DragDropEffects.None;
                e.Handled = true;
            }
        }

        private bool checkFileSize(string path)
        {
            FileInfo fi = new FileInfo(path);
            const double v = 1.049e+6;//convert byte to MB
            double fileSize = fi.Length / v;
            if (fileSize > 5)
            {
                MessageBox.Show("Image Too Large (Use Image Size <= 5MB)", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
                file_name_lbl.Content = "No Image Selected";
                return false;
            }
            else
            {
                fullFileName = System.IO.Path.GetFileName(path);
                fileByte = File.ReadAllBytes(path);
                file_name_lbl.Content = fullFileName;
                return true;
            }
        }

        public void rectangle_drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                string filename = System.IO.Path.GetFileName(files[0]);
                file_name_lbl.Content = filename;
            }
        }

        public void redirectToDashboard()
        {   
            this.Dispatcher.Invoke(() =>
            {
                dashboardWindow = new DashboardWindow();
                dashboardWindow.Show();
                Window.GetWindow(this).Close();
            });

        }


        private void register_btn_Click(object sender, RoutedEventArgs e)
        {
            Hotel hotel = new Hotel();
            hotel.hotel_name = nama_hotel_txt.Text;
            hotel.hotel_location = lokasi_txt.Text;
            hotel.hotel_desc = deskripsi_txt.Text;
            getController().callMethod("addHotel", hotel, fileByte, fullFileName);
        }

        private void pilih_gambar_btn_Click(object sender, RoutedEventArgs e)
        {
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
                file_name_lbl.Content = "No Image Selected";
            }
        }
    }
}
