namespace Notes__.Utilities
{
    class Subcategory
    {
        public string Name { get; set; }
        public List<Note> Notes { get; set; }
        public Subcategory(string name)
        {
            Name = name;
            Notes = new List<Note>();
        }
    }
}