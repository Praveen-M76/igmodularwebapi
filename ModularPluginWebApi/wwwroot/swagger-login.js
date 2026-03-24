(function () {

    let isLoggedIn = false;

    async function loginPopup() {

        const username = prompt("Enter Username:");
        if (!username) return false;

        const password = prompt("Enter Password:");
        if (!password) return false;

        const response = await fetch("/api/auth/login", {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify({
                username: username,
                password: password
            })
        });

        const data = await response.json();

        if (data.access === true) {
            alert("Login successful");
            isLoggedIn = true;
            return true;
        }

        alert("Invalid username or password");
        return false;
    }

    document.addEventListener("click", async function (e) {

        const operation = e.target.closest(".opblock-summary");

        if (!operation) return;

        if (isLoggedIn) return;

        e.preventDefault();
        e.stopPropagation();

        const ok = await loginPopup();

        if (ok) {
            setTimeout(() => {
                operation.click();
            }, 100);
        }

    }, true);

})();