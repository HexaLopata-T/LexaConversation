using Xamarin.Forms;

namespace Lexa_Conversation.Model
{
    public class User
    {
        private string name;

        #region Props
        public string Name
        { 
            get
            {
                return name;
            }
            set
            {
                if (value.Length <= 20 && value.Length > 1)
                    name = value.Trim();
                else
                    name = "No Name";
            }
        }
        public string Rank { get; set; }
        public Color NameColor { get; set; }
        #endregion

        #region Ctors
        public User(string name, string rank, Color nameColor)
        {
            Name = name;
            Rank = rank;
            NameColor = nameColor;
        }
        public User(string name) : this(name, "noob", Color.White) { }
        public User(string name, string rank) : this(name, rank, Color.White) { }
        public User(string name, Color nameColor) : this(name, "noob", nameColor) { }
        public User(User user)
        {
            Name = user.Name;
            Rank = user.Rank;
            NameColor = user.NameColor;
        }
        #endregion
    }
}
