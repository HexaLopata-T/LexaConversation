using Lexa_Conversation.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace Lexa_Conversation.ViewModel
{
    public class ChatViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand SendMessage { get; set; }
        public MessageStorage messageStorage;
        public string enteredText = string.Empty;
        public User User { get; set; } = new User("DoubleGrabli", Color.FromHex("10b382"));

        public ObservableCollection<Message> Messages { get; set; } = new ObservableCollection<Message>();

        public string EnteredText
        {
            get { return enteredText; }
            set
            {
                enteredText = value;
                OnPropertyChanged(nameof(EnteredText));
            }
        }

        public ChatViewModel()
        {
            messageStorage = new MessageStorage();
            SendMessage = new Command(AddToDialog);
        }

        public void AddToDialog()
        {
            if (messageStorage != null && !string.IsNullOrEmpty(EnteredText.Trim()))
            {
                Messages.Add(new Message(EnteredText, new User(User)));
                EnteredText = string.Empty;
            }
        }

        protected void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}