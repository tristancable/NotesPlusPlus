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

window.saveThemeToSession = (theme) => {
    sessionStorage.setItem("selectedTheme", theme);
};

window.getThemeFromSession = () => {
    return sessionStorage.getItem("selectedTheme") || "css/default.css";
};


