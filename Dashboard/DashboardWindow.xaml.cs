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
       
        public DashboardWindow()
        {
            InitializeComponent();
 
            appFrame.Navigate(new ProfilePage());
        }

        private void profileButton_Click(object sender, RoutedEventArgs e)
        {
            appFrame.Navigate(new ProfilePage());
        }

        private void detailButton_Click(object sender, RoutedEventArgs e)
        {
            appFrame.Navigate(new DetailPage());
        }

        private void pemesananButton_Click(object sender, RoutedEventArgs e)
        {
            appFrame.Navigate(new PemesananPage());
        }

        private void pengunjungButton_Click(object sender, RoutedEventArgs e)
        {
            appFrame.Navigate(new PengunjungPage());
        }

        private void pembatalanButton_Click(object sender, RoutedEventArgs e)
        {
            appFrame.Navigate(new PembatalanPage());
        }

        private void logoutButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
