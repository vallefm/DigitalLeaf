let password = document.getElementById("password");
let confPassword = document.getElementById("confirmPassword");

function confirmPassword(){
    if (password.value != confPassword.value) {
        confPassword.setCustomValidity('Passwords do not match');
        confPassword.style.borderColor = 'red';
    } else {
        confPassword.style.borderColor = 'green';
        confPassword.setCustomValidity('');
    }
    if (confPassword.value == '') {
        confPassword.style.borderColor = '';
    }
}

password.change = confirmPassword;
confPassword.onkeyup = confirmPassword;