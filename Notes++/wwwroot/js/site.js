window.preventDefaultDrop = function (event) {
    event.preventDefault();
};

async function chooseDirectory() {
    try {
        const handle = await window.showDirectoryPicker();
        return handle ? handle.name : "";
    } catch (error) {
        console.error("Directory selection was canceled or failed.", error);
        return "";
    }
}