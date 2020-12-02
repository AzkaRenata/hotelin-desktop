using Hotelin_Desktop.DetailPembatalan;
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

namespace Hotelin_Desktop.Pembatalan
{
    /// <summary>
    /// Interaction logic for PembatalanPage.xaml
    /// </summary>
    public partial class PembatalanPage : MyPage
    {
        private DetailPembatalanPage detailPembatalanPage;
        public PembatalanPage()
        {
            InitializeComponent();

            Pembatalan olivia = new Pembatalan();
            olivia.namaPemesan = "Olivia";
            olivia.tanggalMenginap = "3-5 Oktober";
            olivia.tipeKamar = "Presidental Suite";
            olivia.harga = "Rp. 1.626.804";

            pembatalan_datagrid.Items.Add(olivia);
        }

        public class Pembatalan
        {
            public string namaPemesan { get; set; }
            public string tanggalMenginap { get; set; }
            public string tipeKamar { get; set; }
            public string harga { get; set; }
        }

        private void view_btn_Click(object sender, RoutedEventArgs e)
        {
            //appFrame.Navigate(detailPembatalanPage);
        }

        private void delete_btn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
