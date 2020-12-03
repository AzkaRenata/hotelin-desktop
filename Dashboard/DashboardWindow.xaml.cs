using Hotelin_Desktop.Detail;
using Hotelin_Desktop.Pembatalan;
using Hotelin_Desktop.Pemesanan;
using Hotelin_Desktop.Pengunjung;
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
using System.Windows.Shapes;
using Velacro.UIElements.Basic;
using Velacro.UIElements.Button;
using Velacro.UIElements.TextBlock;
using Velacro.UIElements.TextBox;

namespace Hotelin_Desktop.Dashboard
{
    /// <summary>
    /// Interaction logic for DashboardWindow.xaml
    /// </summary>
    public partial class DashboardWindow : MyWindow
    {
        private ProfilePage profilePage;
        private DetailPage detailPage;
        private PemesananPage pemesananPage;
        private PengunjungPage pengunjungPage;
        private PembatalanPage pembatalanPage;
       
        public DashboardWindow()
        {
            InitializeComponent();
            profilePage = new ProfilePage();
            detailPage = new DetailPage();
            pemesananPage = new PemesananPage();
            pengunjungPage = new PengunjungPage();
            pembatalanPage = new PembatalanPage();

            appFrame.Navigate(profilePage);
        }

        private void profileButton_Click(object sender, RoutedEventArgs e)
        {
            appFrame.Navigate(profilePage);
        }

        private void detailButton_Click(object sender, RoutedEventArgs e)
        {
            appFrame.Navigate(detailPage);
        }

        private void pemesananButton_Click(object sender, RoutedEventArgs e)
        {
            appFrame.Navigate(pemesananPage);
        }

        private void pengunjungButton_Click(object sender, RoutedEventArgs e)
        {
            appFrame.Navigate(pengunjungPage);
        }

        private void pembatalanButton_Click(object sender, RoutedEventArgs e)
        {
            appFrame.Navigate(pembatalanPage);
        }

        private void logoutButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
