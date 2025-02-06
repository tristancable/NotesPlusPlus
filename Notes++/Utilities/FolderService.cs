using System;
using System.Collections.Generic;
using System.IO;

namespace Notes__.Utilities
{
    public class FolderService
    {
        private string BaseDirectory => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Notes++");
        private readonly string basePath;

        public FolderService()
        {
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            basePath = Path.Combine(documentsPath, "Notes++");

            if (!Directory.Exists(basePath))
            {
                Directory.CreateDirectory(basePath);
            }
        }

        public List<string> GetFolders()
        {
            if (!Directory.Exists(basePath)) return new List<string>();

            var folders = new List<string>();
            foreach (var dir in Directory.GetDirectories(basePath))
            {
                folders.Add(Path.GetFileName(dir));
            }
            return folders;
        }

        public void CreateFolder(string folderName)
        {
            if (string.IsNullOrWhiteSpace(folderName)) return;

            string folderPath = Path.Combine(basePath, folderName);
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
        }

        public List<string> GetFilesInFolder(string folderName)
        {
            string folderPath = Path.Combine(BaseDirectory, folderName);

            // Make sure the folder exists
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            return Directory.GetFiles(folderPath).Select(f => Path.GetFileName(f)).ToList();
        }

        public void CreateFileInFolder(string folderName, string fileName)
        {
            string folderPath = Path.Combine(BaseDirectory, folderName);

            // Ensure folder exists
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            // Make sure the file has the .txt extension
            if (!fileName.EndsWith(".txt", StringComparison.OrdinalIgnoreCase))
            {
                fileName += ".txt";
            }

            string filePath = Path.Combine(folderPath, fileName);

            // Check if the file already exists, if not, create it
            if (!File.Exists(filePath))
            {
                File.Create(filePath).Dispose();
            }
        }

        // Read file contents
        public string ReadFileContent(string folderName, string fileName)
        {
            if (!fileName.EndsWith(".txt", StringComparison.OrdinalIgnoreCase))
            {
                fileName += ".txt";
            }

            string filePath = Path.Combine(basePath, folderName, fileName);

            Console.WriteLine($"Reading from: {filePath}"); // Debugging output

            if (!File.Exists(filePath))
            {
                Console.WriteLine("⚠️ File not found!");
                return "";
            }

            return File.ReadAllText(filePath);
        }


        // Save file contents
        public void SaveFileContent(string folderName, string fileName, string content)
        {
            // Ensure filename has the correct extension
            if (!fileName.EndsWith(".txt", StringComparison.OrdinalIgnoreCase))
            {
                fileName += ".txt";
            }

            string filePath = Path.Combine(basePath, folderName, fileName);
            File.WriteAllText(filePath, content);
        }

    }
}
