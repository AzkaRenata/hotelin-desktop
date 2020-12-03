using Hotelin_Desktop.DetailKamar;
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
using Velacro.UIElements.TextBlock;
using Velacro.UIElements.TextBox;

namespace Hotelin_Desktop.Detail
{
    /// <summary>
    /// Interaction logic for DetailPage.xaml
    /// </summary>
    public partial class DetailPage : MyPage
    {
        private DetailKamarPage detailKamarPage;
        public DetailPage()
        {
            InitializeComponent();

            Kamar presidental = new Kamar();
            presidental.tipeKamar = "Presidental Suite";
            presidental.harga = "Rp. 1.626.804";
            presidental.jumlahKamar = "20";

            kamar_datagrid.Items.Add(presidental);
        }

        public class Kamar
        {
            public string tipeKamar { get; set; }
            public string harga { get; set; }
            public string jumlahKamar { get; set; }
        }

        private void view_btn_Click(object sender, RoutedEventArgs e)
        {
            //appFrame.Navigate(detailKamarPage);
        }

        private void edit_btn_Click(object sender, RoutedEventArgs e)
        {
        }

        private void delete_btn_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}
