// Search functionality
document.addEventListener('DOMContentLoaded', function() {
    const searchInput = document.getElementById('searchInput');
    const searchBtn = document.getElementById('searchBtn');

    // Search button click event
    searchBtn.addEventListener('click', function() {
        performSearch();
    });

    // Enter key press event
    searchInput.addEventListener('keypress', function(e) {
        if (e.key === 'Enter') {
            performSearch();
        }
    });

    function performSearch() {
        const searchTerm = searchInput.value.trim();
        if (searchTerm) {
            // You can customize this URL to match your site's search functionality
            window.location.href = `/?search=${encodeURIComponent(searchTerm)}`;
        } else {
            // Add a shake animation if search is empty
            searchInput.style.animation = 'shake 0.5s';
            setTimeout(() => {
                searchInput.style.animation = '';
            }, 500);
        }
    }

    // Add shake animation CSS dynamically
    const style = document.createElement('style');
    style.textContent = `
        @keyframes shake {
            0%, 100% { transform: translateX(0); }
            25% { transform: translateX(-10px); }
            75% { transform: translateX(10px); }
        }
    `;
    document.head.appendChild(style);

    // Add parallax effect to floating elements on mouse move
    document.addEventListener('mousemove', function(e) {
        const floatingIcons = document.querySelectorAll('.floating-icon');
        const mouseX = e.clientX / window.innerWidth;
        const mouseY = e.clientY / window.innerHeight;

        floatingIcons.forEach((icon, index) => {
            const speed = (index + 1) * 0.5;
            const x = (mouseX - 0.5) * speed * 20;
            const y = (mouseY - 0.5) * speed * 20;
            icon.style.transform = `translate(${x}px, ${y}px)`;
        });
    });

    // Add random movement to floating icons
    setInterval(() => {
        const floatingIcons = document.querySelectorAll('.floating-icon');
        floatingIcons.forEach(icon => {
            const randomX = (Math.random() - 0.5) * 20;
            const randomY = (Math.random() - 0.5) * 20;
            icon.style.transition = 'transform 2s ease-out';
            icon.style.transform += ` translate(${randomX}px, ${randomY}px)`;
        });
    }, 3000);
});

