using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Hotelin_Desktop.Model
{
    public class UserModel : INotifyPropertyChanged
    {
        public int id { get; set; }
        public string name { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public int user_level { get; set; }
        public object gender { get; set; }
        public object telp { get; set; }
        public string address { get; set; }
        public string user_picture { get; set; }
        public object email_verified_at { get; set; }
        public string remember_token { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}