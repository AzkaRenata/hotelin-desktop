using Hotelin_Desktop.Detail;
using Hotelin_Desktop.Model;
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

namespace Hotelin_Desktop.FasilitasKamar
{
    /// <summary>
    /// Interaction logic for RoomFacility.xaml
    /// </summary>
    public partial class RoomFacilityPage : MyPage
    {
        private BuilderButton buttonBuilder;
        private IMyButton saveRoomButton;
        private int room_id;
        public RoomFacilityPage(int room_id)
        {
            this.room_id = room_id;
            InitializeComponent();
            setController(new RoomFacilityController(this));
            initUIBuilders();
            initUIElements();
        }

        private void initUIBuilders()
        {
            buttonBuilder = new BuilderButton();
        }

        private void initUIElements()
        {
            saveRoomButton = buttonBuilder.activate(this, "save_btn")
                .addOnClick(this, "onSaveButtonClick");
        }

        public void onSaveButtonClick()
        {
            List<string> selectedId = new List<string>();
            List<string> desc = new List<String>();
            if (facility1.IsChecked == true)
            {
                selectedId.Add("1");
                desc.Add(desc1.Text);
            }
            if (facility2.IsChecked == true)
            {
                selectedId.Add("2");
                desc.Add(desc2.Text);
            }
            if (facility3.IsChecked == true)
            {
                selectedId.Add("3");
                desc.Add(desc3.Text);
            }
            if (facility4.IsChecked == true)
            {
                selectedId.Add("4");
                desc.Add(desc4.Text);
            }

            getController().callMethod("saveRoomFacility", room_id, selectedId, desc);
            DetailPage detail = new DetailPage();
            NavigationService.Navigate(detail);
        }
    }
}
