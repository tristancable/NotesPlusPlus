namespace Notes__.Utilities
{
    public class LayoutService
    {
        private string _pageTitle = "Untitled Note Page";

        public string PageTitle
        {
            get => _pageTitle;
            set => _pageTitle = value;
        }

        public void SetPageTitle(string folderName, string fileName)
        {
            // Set the title as Folder Name - File Name
            _pageTitle = $"{folderName} - {fileName}";
        }
    }
}
