// DOM Elements
const registerForm = document.getElementById('registerForm');
const fullNameInput = document.getElementById('fullName');
const emailInput = document.getElementById('email');
const phoneInput = document.getElementById('phone');
const passwordInput = document.getElementById('password');
const confirmPasswordInput = document.getElementById('confirmPassword');
const togglePasswordBtn = document.getElementById('togglePassword');
const toggleConfirmPasswordBtn = document.getElementById('toggleConfirmPassword');
const termsCheckbox = document.getElementById('terms');
const submitBtn = document.querySelector('.submit-btn');

// Password Toggle Functionality
togglePasswordBtn.addEventListener('click', () => {
    const type = passwordInput.getAttribute('type') === 'password' ? 'text' : 'password';
    passwordInput.setAttribute('type', type);
    
    const icon = togglePasswordBtn.querySelector('i');
    icon.classList.toggle('fa-eye');
    icon.classList.toggle('fa-eye-slash');
});

toggleConfirmPasswordBtn.addEventListener('click', () => {
    const type = confirmPasswordInput.getAttribute('type') === 'password' ? 'text' : 'password';
    confirmPasswordInput.setAttribute('type', type);
    
    const icon = toggleConfirmPasswordBtn.querySelector('i');
    icon.classList.toggle('fa-eye');
    icon.classList.toggle('fa-eye-slash');
});

// Real-time Validation
fullNameInput.addEventListener('input', () => {
    validateFullName();
});

emailInput.addEventListener('input', () => {
    validateEmail();
});

phoneInput.addEventListener('input', () => {
    validatePhone();
});

passwordInput.addEventListener('input', () => {
    validatePassword();
    updatePasswordStrength();
});

confirmPasswordInput.addEventListener('input', () => {
    validateConfirmPassword();
});

// Validation Functions
function validateFullName() {
    const value = fullNameInput.value.trim();
    const errorElement = fullNameInput.parentElement.querySelector('.error-message');
    
    if (value.length < 3) {
        showError(fullNameInput, errorElement, 'Ad soyad en az 3 karakter olmalıdır');
        return false;
    } else if (!/^[a-zA-ZğüşıöçĞÜŞİÖÇ\s]+$/.test(value)) {
        showError(fullNameInput, errorElement, 'Ad soyad sadece harf içermelidir');
        return false;
    } else {
        showSuccess(fullNameInput, errorElement);
        return true;
    }
}

function validateEmail() {
    const value = emailInput.value.trim();
    const errorElement = emailInput.parentElement.querySelector('.error-message');
    const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    
    if (!value) {
        showError(emailInput, errorElement, 'E-posta adresi gereklidir');
        return false;
    } else if (!emailRegex.test(value)) {
        showError(emailInput, errorElement, 'Geçerli bir e-posta adresi giriniz');
        return false;
    } else {
        showSuccess(emailInput, errorElement);
        return true;
    }
}

function validatePhone() {
    const value = phoneInput.value.trim();
    const errorElement = phoneInput.parentElement.querySelector('.error-message');
    const phoneRegex = /^(\+90|0)?[5][0-9]{9}$/;
    
    // Remove spaces and dashes for validation
    const cleanPhone = value.replace(/[\s-]/g, '');
    
    if (!value) {
        showError(phoneInput, errorElement, 'Telefon numarası gereklidir');
        return false;
    } else if (!phoneRegex.test(cleanPhone)) {
        showError(phoneInput, errorElement, 'Geçerli bir telefon numarası giriniz (örn: +90 5XX XXX XX XX)');
        return false;
    } else {
        showSuccess(phoneInput, errorElement);
        return true;
    }
}

function validatePassword() {
    const value = passwordInput.value;
    const errorElement = passwordInput.parentElement.parentElement.querySelector('.error-message');
    
    if (value.length < 8) {
        showError(passwordInput, errorElement, 'Şifre en az 8 karakter olmalıdır');
        return false;
    } else if (!/(?=.*[a-z])/.test(value)) {
        showError(passwordInput, errorElement, 'Şifre en az bir küçük harf içermelidir');
        return false;
    } else if (!/(?=.*[A-Z])/.test(value)) {
        showError(passwordInput, errorElement, 'Şifre en az bir büyük harf içermelidir');
        return false;
    } else if (!/(?=.*[0-9])/.test(value)) {
        showError(passwordInput, errorElement, 'Şifre en az bir rakam içermelidir');
        return false;
    } else {
        showSuccess(passwordInput, errorElement);
        return true;
    }
}

function validateConfirmPassword() {
    const value = confirmPasswordInput.value;
    const passwordValue = passwordInput.value;
    const errorElement = confirmPasswordInput.parentElement.parentElement.querySelector('.error-message');
    
    if (!value) {
        showError(confirmPasswordInput, errorElement, 'Şifre tekrarı gereklidir');
        return false;
    } else if (value !== passwordValue) {
        showError(confirmPasswordInput, errorElement, 'Şifreler eşleşmiyor');
        return false;
    } else {
        showSuccess(confirmPasswordInput, errorElement);
        return true;
    }
}

function updatePasswordStrength() {
    const value = passwordInput.value;
    const strengthBar = document.querySelector('.strength-bar');
    
    if (value.length === 0) {
        strengthBar.style.width = '0%';
        strengthBar.className = 'strength-bar';
        return;
    }
    
    let strength = 0;
    if (value.length >= 8) strength++;
    if (/(?=.*[a-z])/.test(value)) strength++;
    if (/(?=.*[A-Z])/.test(value)) strength++;
    if (/(?=.*[0-9])/.test(value)) strength++;
    if (/(?=.*[!@#$%^&*])/.test(value)) strength++;
    
    strengthBar.className = 'strength-bar';
    if (strength <= 2) {
        strengthBar.classList.add('weak');
    } else if (strength <= 4) {
        strengthBar.classList.add('medium');
    } else {
        strengthBar.classList.add('strong');
    }
}

function showError(input, errorElement, message) {
    input.classList.remove('success');
    input.classList.add('error');
    errorElement.textContent = message;
}

function showSuccess(input, errorElement) {
    input.classList.remove('error');
    input.classList.add('success');
    errorElement.textContent = '';
}

// Phone Input Formatting
phoneInput.addEventListener('input', (e) => {
    let value = e.target.value.replace(/\D/g, '');
    
    if (value.startsWith('90')) {
        value = '+' + value;
    } else if (value.startsWith('0')) {
        value = value;
    } else if (value.length > 0 && !value.startsWith('+')) {
        value = '+90' + value;
    }
    
    // Format: +90 5XX XXX XX XX
    if (value.length > 3) {
        value = value.slice(0, 3) + ' ' + value.slice(3);
    }
    if (value.length > 7) {
        value = value.slice(0, 7) + ' ' + value.slice(7);
    }
    if (value.length > 11) {
        value = value.slice(0, 11) + ' ' + value.slice(11);
    }
    if (value.length > 14) {
        value = value.slice(0, 14) + ' ' + value.slice(14);
    }
    
    e.target.value = value;
});

// Form Submission
registerForm.addEventListener('submit', async (e) => {
    e.preventDefault();
    
    // Validate all fields
    const isFullNameValid = validateFullName();
    const isEmailValid = validateEmail();
    const isPhoneValid = validatePhone();
    const isPasswordValid = validatePassword();
    const isConfirmPasswordValid = validateConfirmPassword();
    
    // Check terms
    const termsErrorElement = termsCheckbox.closest('.form-group').querySelector('.error-message');
    if (!termsCheckbox.checked) {
        termsErrorElement.textContent = 'Kullanım şartlarını kabul etmelisiniz';
        return;
    } else {
        termsErrorElement.textContent = '';
    }
    
    if (!isFullNameValid || !isEmailValid || !isPhoneValid || !isPasswordValid || !isConfirmPasswordValid) {
        return;
    }
    
    // Disable submit button and show loading
    submitBtn.disabled = true;
    submitBtn.classList.add('loading');
    submitBtn.innerHTML = '<span>Kayıt yapılıyor...</span><i class="fas fa-spinner"></i>';
    
    // Simulate API call
    try {
        await new Promise(resolve => setTimeout(resolve, 2000));
        
        // Get form data
        const formData = {
            fullName: fullNameInput.value.trim(),
            email: emailInput.value.trim(),
            phone: phoneInput.value.trim(),
            password: passwordInput.value
        };
        
        // Success message (you can replace this with actual API call)
        alert('Kayıt başarıyla tamamlandı! Hoş geldiniz! 🎉');
        
        // Reset form
        registerForm.reset();
        document.querySelectorAll('.strength-bar').forEach(bar => {
            bar.style.width = '0%';
            bar.className = 'strength-bar';
        });
        
    } catch (error) {
        alert('Bir hata oluştu. Lütfen tekrar deneyin.');
    } finally {
        // Re-enable submit button
        submitBtn.disabled = false;
        submitBtn.classList.remove('loading');
        submitBtn.innerHTML = '<span>Kayıt Ol</span><i class="fas fa-arrow-right"></i>';
    }
});

// Social Login Buttons
document.querySelector('.google-btn').addEventListener('click', () => {
    // Add your Google OAuth integration here
});

// Terms Modal - Initialize when DOM is ready
function initTermsModal() {
    const termsModal = document.getElementById('termsModal');
    const termsLink = document.getElementById('termsLink');
    const closeModal = document.getElementById('closeModal');
    const acceptTermsBtn = document.getElementById('acceptTerms');
    const termsCheckbox = document.getElementById('terms');

    if (!termsModal || !termsLink || !closeModal || !acceptTermsBtn || !termsCheckbox) {
        return;
    }

    // Close modal function
    function closeTermsModal() {
        termsModal.classList.remove('active');
        document.body.style.overflow = '';
    }

    // Open modal when terms link is clicked
    termsLink.addEventListener('click', (e) => {
        e.preventDefault();
        e.stopPropagation();
        e.stopImmediatePropagation();
        termsModal.classList.add('active');
        document.body.style.overflow = 'hidden';
    });

    // Close modal
    closeModal.addEventListener('click', closeTermsModal);

    // Close modal when clicking outside
    termsModal.addEventListener('click', (e) => {
        if (e.target === termsModal) {
            closeTermsModal();
        }
    });

    // Accept terms button
    acceptTermsBtn.addEventListener('click', () => {
        termsCheckbox.checked = true;
        closeTermsModal();
    });

    // Close modal with Escape key
    document.addEventListener('keydown', (e) => {
        if (e.key === 'Escape' && termsModal.classList.contains('active')) {
            closeTermsModal();
        }
    });
}

// Initialize when DOM is ready
if (document.readyState === 'loading') {
    document.addEventListener('DOMContentLoaded', initTermsModal);
} else {
    initTermsModal();
}

// Add smooth scroll behavior
document.querySelectorAll('a[href^="#"]').forEach(anchor => {
    anchor.addEventListener('click', function (e) {
        e.preventDefault();
        // Add your navigation logic here
    });
});

