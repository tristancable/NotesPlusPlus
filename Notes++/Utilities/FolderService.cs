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


        public void DeleteFile(string folderName, string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName)) return;

            if (!fileName.EndsWith(".txt", StringComparison.OrdinalIgnoreCase))
            {
                fileName += ".txt";
            }

            string filePath = Path.Combine(basePath, folderName, fileName);

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
                Console.WriteLine($"✅ File deleted: {filePath}");
            }
            else
            {
                Console.WriteLine($"⚠️ File not found: {filePath}");
            }
        }

        // 🔄 UPDATE FILE NAME METHOD
        public void UpdateFileName(string folderName, string oldFileName, string newFileName)
        {
            if (string.IsNullOrWhiteSpace(oldFileName) || string.IsNullOrWhiteSpace(newFileName)) return;

            if (!oldFileName.EndsWith(".txt", StringComparison.OrdinalIgnoreCase))
            {
                oldFileName += ".txt";
            }

            if (!newFileName.EndsWith(".txt", StringComparison.OrdinalIgnoreCase))
            {
                newFileName += ".txt";
            }

            string oldFilePath = Path.Combine(basePath, folderName, oldFileName);
            string newFilePath = Path.Combine(basePath, folderName, newFileName);

            if (File.Exists(oldFilePath))
            {
                File.Move(oldFilePath, newFilePath);
                Console.WriteLine($"✅ File renamed from {oldFileName} to {newFileName}");
            }
            else
            {
                Console.WriteLine($"⚠️ File not found: {oldFileName}");
            }
        }

        public void DeleteFolder(string folderName)
        {
            if (string.IsNullOrWhiteSpace(folderName)) return;

            string folderPath = Path.Combine(basePath, folderName);

            if (Directory.Exists(folderPath))
            {
                Directory.Delete(folderPath, true); // `true` ensures it deletes non-empty folders
                Console.WriteLine($"✅ Folder deleted: {folderPath}");
            }
            else
            {
                Console.WriteLine($"⚠️ Folder not found: {folderPath}");
            }
        }

        public void UpdateFolderName(string oldFolderName, string newFolderName)
        {
            if (string.IsNullOrWhiteSpace(oldFolderName) || string.IsNullOrWhiteSpace(newFolderName)) return;

            string oldFolderPath = Path.Combine(basePath, oldFolderName);
            string newFolderPath = Path.Combine(basePath, newFolderName);

            if (Directory.Exists(oldFolderPath))
            {
                Directory.Move(oldFolderPath, newFolderPath);
                Console.WriteLine($"✅ Folder renamed from {oldFolderName} to {newFolderName}");
            }
            else
            {
                Console.WriteLine($"⚠️ Folder not found: {oldFolderName}");
            }
        }


    }
}
