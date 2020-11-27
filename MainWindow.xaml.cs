using Hotelin_Desktop.Login;
using Hotelin_Desktop.Register;
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

namespace Hotelin_Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MyWindow
    {
        private MyPage loginPage;
        private MyPage registerPage;
        public MainWindow()
        {
            InitializeComponent();
            loginPage = new LoginPage();
            registerPage = new RegisterPage();
        }

        private void login_btn_onCLick(Object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(loginPage);
        }

        private void register_btn_onCLick(Object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(registerPage );
        }
    }
}
