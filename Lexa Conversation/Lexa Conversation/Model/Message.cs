namespace Lexa_Conversation.Model
{
    public class Message
    {
        public string Content { get; set; }
        public User Owner { get; set; }

        public Message(string content, User owner)
        {
            Content = content;
            Owner = owner;
        }
    }
}
