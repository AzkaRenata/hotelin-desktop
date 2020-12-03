using Hotelin_Desktop.DetailPengunjung;
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

namespace Hotelin_Desktop.Pengunjung
{
    /// <summary>
    /// Interaction logic for PengunjungPage.xaml
    /// </summary>
    public partial class PengunjungPage : MyPage
    {
        private DetailPengunjungPage detailPengunjungPage;

        public PengunjungPage()
        {
            InitializeComponent();
            Pengunjung olivia = new Pengunjung();
            olivia.namaPemesan = "Olivia";
            olivia.tanggalMenginap = "3-5 Oktober";
            olivia.tipeKamar = "Presidental Suite";
            olivia.harga = "Rp. 1.626.804";

            pengunjung_datagrid.Items.Add(olivia);

        }

        public class Pengunjung
        {
            public string namaPemesan { get; set; }
            public string tanggalMenginap { get; set; }
            public string tipeKamar { get; set; }
            public string harga { get; set; }
        }

        private void view_btn_Click(object sender, RoutedEventArgs e)
        {
            //appFrame.Navigate(detailPengunjungPage);
        }

        private void delete_btn_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}
