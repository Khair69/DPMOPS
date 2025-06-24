document.addEventListener("DOMContentLoaded", function () {
    const checkbox = document.getElementById("themeToggleCheckbox");
    const html = document.documentElement;
    const aside = document.getElementById("Aside");

    function applyTheme(theme) {
        html.setAttribute("data-bs-theme", theme);
        aside.setAttribute("data-bs-theme", theme);

        if (theme === "dark") {
            aside.classList.remove("bg-light");
            aside.classList.add("bg-dark");
            document.body.classList.add("dark");
        } else {
            aside.classList.remove("bg-dark");
            aside.classList.add("bg-light");
            document.body.classList.remove("dark");
        }

        localStorage.setItem("theme", theme);
    }

    const savedTheme = localStorage.getItem("theme") || "light";
    checkbox.checked = savedTheme === "light";
    applyTheme(savedTheme);

    checkbox.addEventListener("change", function () {
        const theme = this.checked ? "light" : "dark";
        applyTheme(theme);
    });
});