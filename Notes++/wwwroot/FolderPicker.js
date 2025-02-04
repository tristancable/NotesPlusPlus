window.pickFolder = async () => {
    // Use the File System Access API to prompt the user to select a folder
    const folderHandle = await window.showDirectoryPicker();

    // Save the path or handle for later use
    const folderPath = folderHandle.name;  // This gives the name of the folder, or use other APIs to get the full path if necessary

    return folderPath;  // Return the folder name or path
};