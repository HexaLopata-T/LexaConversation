using Lexa_Conversation.Model;
using System.ComponentModel;
using Xamarin.Forms;

namespace Lexa_Conversation.ViewModel
{
    public class ProfileViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private ChatViewModel mv;
        private User user;
        public User User
        {
            get
            {
                return user;
            }
            set
            {
                if (value != null)
                {
                    user = new User(value);
                    mv.User = user;
                    OnPropertyChanged(nameof(User));
                }
            }
        }

        public ProfileViewModel(ChatViewModel mv)
        {
            this.mv = mv;
            User = new User("DoubleGrabli", Color.FromHex("10b382"));
        }

        protected void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
