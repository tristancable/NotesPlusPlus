using System;
using System.Collections.Generic;
using System.IO;

namespace Notes__.Utilities
{
    public class FolderService
    {
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
            string folderPath = Path.Combine(basePath, folderName);
            if (!Directory.Exists(folderPath)) return new List<string>();

            var files = new List<string>();
            foreach (var file in Directory.GetFiles(folderPath, "*.txt"))
            {
                files.Add(Path.GetFileName(file));
            }
            return files;
        }

        public void CreateFileInFolder(string folderName, string fileName)
        {
            if (string.IsNullOrWhiteSpace(folderName) || string.IsNullOrWhiteSpace(fileName)) return;

            string folderPath = Path.Combine(basePath, folderName);
            if (!Directory.Exists(folderPath)) return;

            string filePath = Path.Combine(folderPath, fileName + ".txt");
            if (!File.Exists(filePath))
            {
                File.WriteAllText(filePath, ""); // Create an empty file
            }
        }

        // Read file contents
        public string ReadFileContent(string folderName, string fileName)
        {
            string filePath = Path.Combine(basePath, folderName, fileName);
            return File.Exists(filePath) ? File.ReadAllText(filePath) : "";
        }

        // Save file contents
        public void SaveFileContent(string folderName, string fileName, string content)
        {
            string filePath = Path.Combine(basePath, folderName, fileName);
            File.WriteAllText(filePath, content);
        }
    }
}
