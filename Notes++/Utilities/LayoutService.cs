namespace Notes__.Utilities
{
    public class LayoutService
    {
        public enum EFormat
        {
            BASIC,
            BULLETPOINT,
            NUMBERED
        }
        private int _editNumber = -1;
        public int EditNumber
        {
            get => _editNumber;
            set => _editNumber = value;
        }
        private EFormat _format = EFormat.BASIC;
        public EFormat Format
        {
            get => _format;
            set => _format = value;
        }
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
