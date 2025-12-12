// DOM Elements
const loginForm = document.getElementById('loginForm');
const emailInput = document.getElementById('email');
const passwordInput = document.getElementById('password');
const togglePasswordBtn = document.getElementById('togglePassword');
const loginButton = document.getElementById('loginButton');
const emailError = document.getElementById('emailError');
const passwordError = document.getElementById('passwordError');
const rememberMe = document.getElementById('rememberMe');

// Toggle Password Visibility
togglePasswordBtn.addEventListener('click', () => {
    const type = passwordInput.getAttribute('type') === 'password' ? 'text' : 'password';
    passwordInput.setAttribute('type', type);
    
    // Update icon (you can add different icons for show/hide)
    togglePasswordBtn.style.opacity = type === 'text' ? '0.7' : '1';
});

// Email Validation
function validateEmail(email) {
    const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    return emailRegex.test(email);
}

// Show Error
function showError(element, message) {
    element.textContent = message;
    element.classList.add('show');
}

// Hide Error
function hideError(element) {
    element.textContent = '';
    element.classList.remove('show');
}

// Real-time Validation
emailInput.addEventListener('blur', () => {
    if (emailInput.value.trim() === '') {
        showError(emailError, 'E-posta adresi gereklidir');
    } else if (!validateEmail(emailInput.value)) {
        showError(emailError, 'Geçerli bir e-posta adresi giriniz');
    } else {
        hideError(emailError);
    }
});

emailInput.addEventListener('input', () => {
    if (emailError.classList.contains('show')) {
        if (emailInput.value.trim() === '' || !validateEmail(emailInput.value)) {
            return;
        }
        hideError(emailError);
    }
});

passwordInput.addEventListener('blur', () => {
    if (passwordInput.value.trim() === '') {
        showError(passwordError, 'Şifre gereklidir');
    } else if (passwordInput.value.length < 6) {
        showError(passwordError, 'Şifre en az 6 karakter olmalıdır');
    } else {
        hideError(passwordError);
    }
});

passwordInput.addEventListener('input', () => {
    if (passwordError.classList.contains('show')) {
        if (passwordInput.value.trim() === '' || passwordInput.value.length < 6) {
            return;
        }
        hideError(passwordError);
    }
});

// Form Submission (.NET uyumlu)
loginForm.addEventListener('submit', (e) => {
    // Reset errors
    hideError(emailError);
    hideError(passwordError);
    
    // Get form values
    const email = emailInput.value.trim();
    const password = passwordInput.value;
    
    // Client-side validation
    let isValid = true;
    
    if (email === '') {
        showError(emailError, 'E-posta adresi gereklidir');
        isValid = false;
    } else if (!validateEmail(email)) {
        showError(emailError, 'Geçerli bir e-posta adresi giriniz');
        isValid = false;
    }
    
    if (password === '') {
        showError(passwordError, 'Şifre gereklidir');
        isValid = false;
    } else if (password.length < 6) {
        showError(passwordError, 'Şifre en az 6 karakter olmalıdır');
        isValid = false;
    }
    
    // Eğer validasyon geçmezse, form submit'ini engelle
    if (!isValid) {
        e.preventDefault();
        return false;
    }
    
    // Validasyon geçerse, form'un .NET'e normal submit olmasına izin ver
    // Loading state göster
    loginButton.classList.add('loading');
    loginButton.disabled = true;
    
    // Form .NET tarafında işlenecek, burada sadece UX için loading gösteriyoruz
    // .NET'te başarılı/başarısız durumlar server-side'da handle edilecek
});

// Not: .NET MVC kullanıldığı için API çağrısı server-side'da yapılacak
// Bu fonksiyon artık kullanılmıyor, sadece referans için bırakıldı

// Social Login Handlers
document.querySelectorAll('.social-button').forEach(button => {
    button.addEventListener('click', (e) => {
        e.preventDefault();
        const provider = button.classList.contains('google') ? 'Google' : 'GitHub';
        
        // Show loading
        button.style.opacity = '0.7';
        button.disabled = true;
        
        // Simulate social login
        setTimeout(() => {
            console.log(`${provider} login clicked`);
            alert(`${provider} ile giriş özelliği yakında eklenecek!`);
            button.style.opacity = '1';
            button.disabled = false;
        }, 1000);
    });
});

// Forgot Password Handler
document.querySelector('.forgot-password').addEventListener('click', (e) => {
    e.preventDefault();
    const email = prompt('Şifre sıfırlama e-postası göndermek için e-posta adresinizi girin:');
    if (email && validateEmail(email)) {
        alert('Şifre sıfırlama bağlantısı e-posta adresinize gönderildi!');
    } else if (email) {
        alert('Geçerli bir e-posta adresi giriniz!');
    }
});

// Signup Link Handler
document.querySelector('.signup-link a').addEventListener('click', (e) => {
    e.preventDefault();
    alert('Kayıt sayfası yakında eklenecek!');
});

// Add smooth focus transitions
document.querySelectorAll('input').forEach(input => {
    input.addEventListener('focus', function() {
        this.parentElement.style.transform = 'scale(1.01)';
    });
    
    input.addEventListener('blur', function() {
        this.parentElement.style.transform = 'scale(1)';
    });
});

// Keyboard navigation enhancement
document.addEventListener('keydown', (e) => {
    if (e.key === 'Enter' && e.target.tagName !== 'BUTTON') {
        const form = e.target.closest('form');
        if (form) {
            const submitButton = form.querySelector('button[type="submit"]');
            if (submitButton && !submitButton.disabled) {
                submitButton.click();
            }
        }
    }
});

// Add entrance animation to form elements
const observerOptions = {
    threshold: 0.1,
    rootMargin: '0px 0px -50px 0px'
};

const observer = new IntersectionObserver((entries) => {
    entries.forEach((entry, index) => {
        if (entry.isIntersecting) {
            setTimeout(() => {
                entry.target.style.opacity = '1';
                entry.target.style.transform = 'translateY(0)';
            }, index * 100);
        }
    });
}, observerOptions);

// Observe form groups
document.querySelectorAll('.form-group').forEach((group, index) => {
    group.style.opacity = '0';
    group.style.transform = 'translateY(20px)';
    group.style.transition = 'opacity 0.5s ease, transform 0.5s ease';
    observer.observe(group);
});

console.log('TourifyX Login Page Loaded 🚀');

