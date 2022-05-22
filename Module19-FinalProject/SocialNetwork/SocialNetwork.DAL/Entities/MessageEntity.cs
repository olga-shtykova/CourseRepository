namespace SocialNetwork.DAL.Entities
{
    public class MessageEntity
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public int Sender_id { get; set; }

        public int Recipient_id { get; set; }

    }
}
