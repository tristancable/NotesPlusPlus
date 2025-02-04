using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace NotesApp.Services
{
    public class FolderService
    {
        // Default base path for notes, you can modify this as needed
        private string basePath = Path.Combine(Directory.GetCurrentDirectory(), "Notes++");

        public FolderService()
        {
            // Ensure the "Notes++" directory exists
            if (!Directory.Exists(basePath))
            {
                Directory.CreateDirectory(basePath);
            }
        }

        // Set the base directory (allow dynamic change by user)
        public void SetBasePath(string selectedFolderPath)
        {
            if (!string.IsNullOrEmpty(selectedFolderPath))
            {
                basePath = selectedFolderPath;
            }

            // Ensure the selected directory exists
            if (!Directory.Exists(basePath))
            {
                Directory.CreateDirectory(basePath);
            }
        }

        // Create a new folder
        public void CreateFolder(string folderName)
        {
            string folderPath = Path.Combine(basePath, folderName);

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
        }

        // Get all folder names under the base directory
        public List<string> GetFolderNames()
        {
            // Get all directories inside the base path
            return Directory.GetDirectories(basePath)
                            .Select(Path.GetFileName)
                            .ToList();
        }

        // Create a note file in a specified folder
        public void CreateNoteInFolder(string folderName, string noteName, string content)
        {
            string folderPath = Path.Combine(basePath, folderName);

            if (!Directory.Exists(folderPath))
            {
                throw new DirectoryNotFoundException($"Folder {folderName} does not exist.");
            }

            // Ensure a note file with the specified name exists (e.g., .txt or .md)
            string noteFilePath = Path.Combine(folderPath, noteName + ".txt");

            // Save content to the note file
            File.WriteAllText(noteFilePath, content);
        }

        // Get all notes in a specific folder
        public List<string> GetNotesInFolder(string folderName)
        {
            string folderPath = Path.Combine(basePath, folderName);

            if (!Directory.Exists(folderPath))
            {
                throw new DirectoryNotFoundException($"Folder {folderName} does not exist.");
            }

            // Get all note files in the folder (for example, .txt files)
            return Directory.GetFiles(folderPath, "*.txt")
                            .Select(Path.GetFileNameWithoutExtension)
                            .ToList();
        }

        // Read content from a specific note file in a folder
        public string ReadNoteContent(string folderName, string noteName)
        {
            string folderPath = Path.Combine(basePath, folderName);
            string noteFilePath = Path.Combine(folderPath, noteName + ".txt");

            if (File.Exists(noteFilePath))
            {
                return File.ReadAllText(noteFilePath);
            }

            throw new FileNotFoundException($"Note {noteName} not found in folder {folderName}.");
        }

        // Delete a note from a folder
        public void DeleteNoteFromFolder(string folderName, string noteName)
        {
            string folderPath = Path.Combine(basePath, folderName);
            string noteFilePath = Path.Combine(folderPath, noteName + ".txt");

            if (File.Exists(noteFilePath))
            {
                File.Delete(noteFilePath);
            }
            else
            {
                throw new FileNotFoundException($"Note {noteName} not found in folder {folderName}.");
            }
        }
    }
}
