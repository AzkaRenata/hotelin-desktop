using Hotelin_Desktop.Login;
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
using Velacro.UIElements.PasswordBox;
using System.IO;
using Hotelin_Desktop.Dashboard;
using Hotelin_Desktop.AddHotel;

namespace Hotelin_Desktop.Register
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : MyWindow
    {
        private BuilderButton buttonBuilder;
        private BuilderTextBox txtBoxBuilder;
        private BuilderPasswordBox passBoxBuilder;
        private BuilderTextBlock txtBlockBuilder;
        private IMyButton registerButton;
        private IMyTextBox usernameTxtBox;
        private IMyTextBox emailTxtBox;
        private IMyTextBox nameTxtBox;
        private IMyPasswordBox passwordPassBox;
        private IMyPasswordBox passwordcPassBox;
        private IMyTextBlock registerStatusTxtBlock;
        private MyWindow loginWindow;
        private MyWindow formRegisterWindow;
        private MyPage addHotelPage;

        public RegisterWindow()
        {
            InitializeComponent();
            setController(new RegisterController(this));
            initUIBuilders();
            initUIElements();
        }

        private void initUIBuilders()
        {
            buttonBuilder = new BuilderButton();
            txtBoxBuilder = new BuilderTextBox();
            passBoxBuilder = new BuilderPasswordBox();
            txtBlockBuilder = new BuilderTextBlock();
        }

        private void initUIElements()
        {
            registerButton = buttonBuilder.activate(this, "register_btn")
                .addOnClick(this, "onRegisterButtonClick");
            usernameTxtBox = txtBoxBuilder.activate(this, "username_txt");
            nameTxtBox = txtBoxBuilder.activate(this, "nama_txt");
            emailTxtBox = txtBoxBuilder.activate(this, "email_txt");
            passwordPassBox = passBoxBuilder.activate(this, "password_txt");
            passwordcPassBox = passBoxBuilder.activate(this, "confirm_password_txt");
            registerStatusTxtBlock = txtBlockBuilder.activate(this, "registerStatus");
        }

        public void onRegisterButtonClick()
        {
            getController().callMethod("register",
                nameTxtBox.getText(),
                emailTxtBox.getText(),
                nameTxtBox.getText(),
                passwordPassBox.getPassword(),
                passwordcPassBox.getPassword());
        }

        public void setRegisterStatus(string _status)
        {
            this.Dispatcher.Invoke(() => {
                registerButton.setText(_status);
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
                /*formRegisterWindow = new FormRegisterWindow();
                formRegisterWindow.Show();
                Window.GetWindow(this).Close();*/

                DashboardWindow dashboard = new DashboardWindow();
                dashboard.Show();
                dashboard.appFrame.Navigate(new AddHotelPage());
                Window.GetWindow(this).Close();
            });
        }


        private void login_window_btn_Click(object sender, RoutedEventArgs e)
        {
            redirectTologin();

        }

        private void login_link_Click(object sender, RoutedEventArgs e)
        {
            redirectTologin();
        }

        private void redirectTologin() {
            loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }
    }
}
