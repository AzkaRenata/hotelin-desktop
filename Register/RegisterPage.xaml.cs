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

namespace Hotelin_Desktop.Register
{
    /// <summary>
    /// Interaction logic for RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : MyPage
    {
        private BuilderButton buttonBuilder;
        private BuilderTextBox txtBoxBuilder;
        private BuilderTextBlock txtBlockBuilder;
        private IMyButton registerButton;
        private IMyTextBox usernameTxtBox;
        private IMyTextBox emailTxtBox;
        private IMyTextBox nameTxtBox;
        private IMyTextBox passwordTxtBox;
        private IMyTextBox passwordcTxtBox;
        private IMyTextBlock registerStatusTxtBlock;

        public RegisterPage()
        {
            InitializeComponent();
            this.KeepAlive = true;
            setController(new RegisterController(this));
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
            registerButton = buttonBuilder.activate(this, "register_btn")
                .addOnClick(this, "onRegisterButtonClick");
            usernameTxtBox = txtBoxBuilder.activate(this, "username_txt");
            nameTxtBox = txtBoxBuilder.activate(this, "name_txt");
            emailTxtBox = txtBoxBuilder.activate(this, "email_txt");
            passwordTxtBox = txtBoxBuilder.activate(this, "password_txt");
            passwordcTxtBox = txtBoxBuilder.activate(this, "passwordConfirmation_txt");
            registerStatusTxtBlock = txtBlockBuilder.activate(this, "registerStatus");
        }

        public void onRegisterButtonClick()
        {
            getController().callMethod("register",
                usernameTxtBox.getText(),
                emailTxtBox.getText(),
                nameTxtBox.getText(),
                passwordTxtBox.getText());
            Console.WriteLine(usernameTxtBox.getText());
            Console.WriteLine(emailTxtBox.getText());
            Console.WriteLine(nameTxtBox.getText());
            Console.WriteLine(passwordTxtBox.getText());
        }

        public void setRegisterStatus(string _status)
        {
            this.Dispatcher.Invoke(() => {
                registerButton.setText(_status);
            });

        }
    }
}
