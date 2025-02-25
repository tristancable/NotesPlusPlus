window.setTheme = (cssFile) => {
    let existingLink = document.getElementById("theme-css");
    if (!existingLink) {
        existingLink = document.createElement("link");
        existingLink.id = "theme-css";
        existingLink.rel = "stylesheet";
        document.head.appendChild(existingLink);
    }
    existingLink.href = cssFile;
};

window.saveThemeToLocalStorage = (theme) => {
    localStorage.setItem("selectedTheme", theme);
};

window.getThemeFromLocalStorage = () => {
    return localStorage.getItem("selectedTheme") || "css/app.css"; // Default to Light theme
};
