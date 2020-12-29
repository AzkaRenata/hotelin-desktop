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

namespace Hotelin_Desktop.Register
{
    /// <summary>
    /// Interaction logic for FormRegisterWindow.xaml
    /// </summary>
    public partial class FormRegisterWindow : MyWindow
    {
        public FormRegisterWindow()
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

        private void register_btn_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}
