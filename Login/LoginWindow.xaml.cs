using Hotelin_Desktop.Dashboard;
using Hotelin_Desktop.Register;
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
using Velacro.UIElements.Basic;
using Velacro.UIElements.Button;
using Velacro.UIElements.TextBlock;
using Velacro.UIElements.TextBox;


namespace Hotelin_Desktop.Login
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : MyWindow
    {
        private BuilderButton buttonBuilder;
        private BuilderTextBox txtBoxBuilder;
        private BuilderTextBlock txtBlockBuilder;
        private IMyButton loginButton;
        private IMyTextBox emailTxtBox;
        private IMyTextBox passwordTxtBox;
        private IMyTextBlock loginStatusTxtBlock;
        private MyWindow registerWindow;
        private MyWindow dashboardWindow;

        public LoginWindow()
        {
            InitializeComponent();
            //this.KeepAlive = true;
            setController(new LoginController(this));
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
            loginButton = buttonBuilder
                .activate(this, "login_btn")
                .addOnClick(this, "onLoginButtonClick");
            emailTxtBox = txtBoxBuilder.activate(this, "email_txt");
            passwordTxtBox = txtBoxBuilder.activate(this, "password_txt");
            loginStatusTxtBlock = txtBlockBuilder.activate(this, "loginStatus");
        }

        public void onLoginButtonClick()
        {
            getController().callMethod("login", email_txt.Text, password_txt.Text);
        }


        public void setLoginStatus(string _status)
        {
            this.Dispatcher.Invoke(() =>
            {
                loginButton.setText(_status);
            });
        }

        public void saveToken(String token)
        {
            this.Dispatcher.Invoke(() =>
            {
                string fullPath = @"userToken.txt";
                File.WriteAllText(fullPath, token);
                // Read a file  
                string readText = File.ReadAllText(fullPath);
                Console.WriteLine("READ : " + readText);
                dashboardWindow = new DashboardWindow();
                dashboardWindow.Show();
                Window.GetWindow(this).Close();
            });
        }

        private void register_window_btn_Click(object sender, RoutedEventArgs e)
        {
            registerWindow = new RegisterWindow();
            registerWindow.Show();
            this.Close();
        }

        private void register_link_Click(object sender, RoutedEventArgs e)
        {
            registerWindow = new RegisterWindow();
            registerWindow.Show();
            this.Close();
        }

        public void tesPrint()
        {
            Console.WriteLine("TESSS");
        }
    }
}
