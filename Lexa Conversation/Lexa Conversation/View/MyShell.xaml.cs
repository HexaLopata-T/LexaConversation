using Lexa_Conversation.ViewModel;
using System.Collections.Specialized;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lexa_Conversation.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyShell : Shell
    {
        public ChatViewModel mv = new ChatViewModel();
        public ProfileViewModel pmv;
        public MyShell()
        {
            InitializeComponent();
            pmv= new ProfileViewModel(mv);
            CurrentItem = Chat;
            Chat.BindingContext = mv;
            Profile.BindingContext = pmv;
            pmv.User = mv.User;
            mv.Messages.CollectionChanged += Messages_CollectionChanged;
        }

        private void Messages_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (mv.Messages.Count > 0)
            {
                dialog1.ScrollTo(mv.Messages[mv.Messages.Count - 1], ScrollToPosition.End, false);
            }
        }

        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            Color oldColor = mv.User.NameColor;
            try
            {
                mv.User.NameColor = Color.FromHex(e.NewTextValue);
            }
            catch
            {
                mv.User.NameColor = oldColor;
            }
        }
    }
}