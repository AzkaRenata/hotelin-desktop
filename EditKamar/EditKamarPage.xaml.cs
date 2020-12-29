﻿using System;
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

namespace Hotelin_Desktop.EditKamar
{
    /// <summary>
    /// Interaction logic for EditKamarPage.xaml
    /// </summary>
    public partial class EditKamarPage : MyPage
    {
        public EditKamarPage()
        {
            InitializeComponent();
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

        private void edit_kamar_btn_Click(object sender, RoutedEventArgs e)
        {

        }

<<<<<<< Updated upstream
=======
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
>>>>>>> Stashed changes
    }
}
