(function () {
    function applyToken() {
        const token = localStorage.getItem("jwtToken");

        if (!token) return false;
        if (!window.ui) return false;
        if (typeof window.ui.preauthorizeApiKey !== "function") return false;

        try {
            window.ui.preauthorizeApiKey("Bearer", "Bearer " + token);
            return true;
        } catch (e) {
            return false;
        }
    }

    let count = 0;

    const timer = setInterval(() => {
        count++;
        const done = applyToken();

        if (done || count > 40) {
            clearInterval(timer);
        }
    }, 500);
})();