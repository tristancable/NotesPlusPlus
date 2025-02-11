namespace Notes__.Utilities
{
    public class Note
    {
        public Guid Id { get; set; }
        public string Content { get; set; }

        public Note(string content)
        {
            Id = Guid.NewGuid();
            Content = content;
        }
    }
}
