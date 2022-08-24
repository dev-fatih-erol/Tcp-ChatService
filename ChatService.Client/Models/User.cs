namespace ChatService.Client.Models
{
    public class User
	{
        public Guid Id { get; set; }

        public DateTime LastMessageDate { get; set; }

        public byte Counter { get; set; } = 0;
    }
}