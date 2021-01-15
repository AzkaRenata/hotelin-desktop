using Hotelin_Desktop.Detail;
using Hotelin_Desktop.EditFasilitasKamar;
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

namespace Hotelin_Desktop.EditKamar
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class EditKamarPage : MyPage
    {
        private BuilderButton buttonBuilder;
        private BuilderTextBox txtBoxBuilder;
        private BuilderTextBlock txtBlockBuilder;
        private IMyButton updateRoomButton;
        private IMyButton chooseImageButton;
        private IMyTextBox roomCodeTxtBox;
        private IMyTextBox roomTypeTxtBox;
        private IMyTextBox bedTypeTxtBox;
        private IMyTextBox bedCountTxtBox;
        private IMyTextBox guestCapacityTxtBox;
        private IMyTextBox roomPriceTxtBox;
        private IMyTextBlock imageTxtBlock;
        private byte[] fileByte = null;
        private string fullFileName = "";
        private int room_id;
        public EditKamarPage(int id)
        {
            this.room_id = id;
            InitializeComponent();
            setController(new EditKamarController(this, id));
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
            updateRoomButton = buttonBuilder.activate(this, "edit_kamar_btn")
                .addOnClick(this, "onEditRoomButtonClick");
            chooseImageButton = buttonBuilder.activate(this, "choose_image_btn")
                .addOnClick(this, "onChooseImageButtonClick");
            roomCodeTxtBox = txtBoxBuilder.activate(this, "kode_kamar_txt");
            roomTypeTxtBox = txtBoxBuilder.activate(this, "tipe_kamar_txt");
            bedTypeTxtBox = txtBoxBuilder.activate(this, "tipe_kasur_txt");
            bedCountTxtBox = txtBoxBuilder.activate(this, "jumlah_kasur_txt");
            guestCapacityTxtBox = txtBoxBuilder.activate(this, "kapasitas_tamu_txt");
            roomPriceTxtBox = txtBoxBuilder.activate(this, "harga_kamar_txt");
            imageTxtBlock = txtBlockBuilder.activate(this, "selected_image_tb");
        }

        public void onEditRoomButtonClick()
        {
            RoomModel room = new RoomModel();
            room.room_code = roomCodeTxtBox.getText();
            room.room_type = roomTypeTxtBox.getText();
            room.bed_type = bedTypeTxtBox.getText();
            room.bed_count = int.Parse(bedCountTxtBox.getText());
            room.room_price = long.Parse(roomPriceTxtBox.getText());
            room.guest_capacity = int.Parse(guestCapacityTxtBox.getText());
            getController().callMethod("updateKamar", room, fileByte, fullFileName);

            EditRoomFacilityPage pg = new EditRoomFacilityPage(room_id);
            NavigationService.Navigate(pg);
        }

        public void setCurrentRoomValue(RoomResponse roomResponse)
        {
            RoomModel room = roomResponse.room;
            roomCodeTxtBox.setText(room.room_code);
            roomTypeTxtBox.setText(room.room_type);
            bedTypeTxtBox.setText(room.bed_type);
            bedCountTxtBox.setText(Convert.ToString(room.bed_count));
            roomPriceTxtBox.setText(Convert.ToString(room.room_price));
            guestCapacityTxtBox.setText(Convert.ToString(room.guest_capacity));
            if (room.room_picture != null)
            {
                string longFileName = room.room_picture;
                string fileName = longFileName.Substring(13, longFileName.Length - 13);
                selected_image_tb.Text = fileName;
            }

        }

        private bool checkFileSize(string path)
        {
            FileInfo fi = new FileInfo(path);
            const double v = 1.049e+6;//convert byte to MB
            double fileSize = fi.Length / v;
            if (fileSize > 2)
            {
                MessageBox.Show("Image Too Large (Use Image Size <= 2MB)", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
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
