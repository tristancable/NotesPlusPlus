namespace Notes__.Utilities
{
    public class FolderService
    {
        private string rootPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Notes++");

        public FolderService()
        {
            if (!Directory.Exists(rootPath))
            {
                Directory.CreateDirectory(rootPath);
            }
        }

        // Create a folder by its name
        public void CreateFolder(string folderName)
        {
            string folderPath = Path.Combine(rootPath, folderName);
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
        }

        // Get all folders
        public List<string> GetFolders()
        {
            List<string> folderNames = new();
            if (Directory.Exists(rootPath))
            {
                var directoryInfo = new DirectoryInfo(rootPath);
                foreach (var folder in directoryInfo.GetDirectories())
                {
                    folderNames.Add(folder.Name);
                }
            }
            return folderNames;
        }

        // Get files inside a specific folder
        public List<string> GetFilesInFolder(string folderName)
        {
            string folderPath = Path.Combine(rootPath, folderName);
            List<string> files = new();
            if (Directory.Exists(folderPath))
            {
                var directoryInfo = new DirectoryInfo(folderPath);
                foreach (var file in directoryInfo.GetFiles())
                {
                    files.Add(file.Name);
                }
            }
            return files;
        }

        // Create a new file inside a folder
        public void CreateFileInFolder(string folderName, string fileName)
        {
            string folderPath = Path.Combine(rootPath, folderName);
            string filePath = Path.Combine(folderPath, fileName);
            if (!File.Exists(filePath))
            {
                File.Create(filePath).Dispose();
            }
        }
    }
}
