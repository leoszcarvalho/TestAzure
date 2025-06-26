namespace TestAzure.Models
{
    public class Conversation
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string User1 { get; set; }
        public string User2 { get; set; }

        public bool HasUser(string username) =>
            username == User1 || username == User2;
    }

}
