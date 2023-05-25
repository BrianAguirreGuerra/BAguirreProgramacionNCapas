function validarInput(input) {
    var regex = /^[A-Za-z]+$/;
    var valor = input.value;
    var id = input.id;

    if (!regex.test(valor)) {
        if (id == 'txtNombre') {
            var errorElementSet = $('#Nombre-error');
            errorElementSet.text('');
            var errorMessage = 'Solo se admiten letras';
            var errorElementSet = $('#Nombre-error');
            errorElementSet.text(errorMessage);
            input.value = "";
            $("#txtNombre").css('border', '2px solid #a94442');
        } else if (id == 'txtApellidoPaterno') {
            var errorMessage = 'Solo se admiten letras';
            var errorElementSet = $('#ApellidoPaterno-error');
            errorElementSet.text(errorMessage);
            input.value = "";
            $("#txtApellidoPaterno").css('border', '2px solid #a94442');
        } else if (id == 'txtApellidoMaterno') {
            var errorMessage = 'Solo se admiten letras';
            var errorElementSet = $('#ApellidoMaterno-error');
            errorElementSet.text(errorMessage);
            input.value = "";
            $("#txtApellidoMaterno").css('border', '2px solid #a94442');
        }
    } else {
        if (id == 'txtNombre') {
            var errorElementSet = $('#Nombre-error');
            errorElementSet.text('');
            $("#txtNombre").css('border', '');
        } else if (id == 'txtApellidoPaterno') {
            var errorElementSet = $('#ApellidoPaterno-error');
            errorElementSet.text('');
            $("#txtApellidoPaterno").css('border', '');
        } else if (id == 'txtApellidoMaterno') {
            var errorElementSet = $('#ApellidoMaterno-error');
            errorElementSet.text('');
            $("#txtApellidoMaterno").css('border', '');
        }
        input.value = valor.charAt(0).toUpperCase() + valor.slice(1);
    }
}



function validarNumero(input) {
    var valor = input.value;
    var id = input.id;

    if (isNaN(valor) || valor.length > 20) {
        if (id == 'txtTelefono') {
            var errorMessage = 'Solo se admiten números o supera los 20 digitos';
            var errorElementSet = $('#Telefono-error');
            errorElementSet.text(errorMessage);
            input.value = ""; 
            $("#txtTelefono").css('border', '2px solid #a94442');
        } else if (id == 'txtCelular') {
            var errorMessage = 'Solo se admiten números o supera los 20 digitos';
            var errorElementSet = $('#Celular-error');
            errorElementSet.text(errorMessage);
            input.value = ""; 
            $("#txtCelular").css('border', '2px solid #a94442');
        }

    } else {
        if (id == 'txtTelefono') {
            var errorElementSet = $('#Telefono-error');
            errorElementSet.text('');
            $("#txtTelefono").css('border', '');
        } else if (id == 'txtCelular') {
            var errorElementSet = $('#Celular-error');
            errorElementSet.text('');
            $("#txtCelular").css('border', '');
        }
    }
}



var curpInput = $('.curp-input');
var errorElement = $('#CURP-error');
curpInput.on('input', function () {
    errorElement.text('');
    $("#txtCURP").css('border', '');
    var curpValue = curpInput.val();

    var curpValueUpper = curpValue.toUpperCase();

    curpInput.val(curpValueUpper);
}).on('change', function () {
    var curpValue = curpInput.val();

    var curpRegex = /^[A-Z]{4}\d{6}[A-Z]{6}[0-9A-Z]{2}$/;

    if (curpRegex.test(curpValue)) {
        console.log('CURP válida');
    } else {
        var errorMessage = 'La CURP ingresada es incorrecta';

        var errorElement = $('#CURP-error');
        errorElement.text(errorMessage);

        curpInput.val('');
        $("#txtCURP").css('border', '2px solid #a94442');
    }
});



// Validar contraseña al perder el foco
function validarPassword() {
    var password = document.getElementById('txtPassword').value;
    var regex = /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z\s]).{8,}$/;
    var passwordField = $("#txtPassword");

    if (!regex.test(password)) {
        var errorMessage = 'La contraseña debe contener al menos una letra minúscula, un número, una letra mayúscula, un carácter especial, no debe contener espacios y tener un mínimo de 8 caracteres.';
        var errorElementSet = $('#password-error');
        errorElementSet.text(errorMessage);
        passwordField.val(""); // Limpiar el campo de contraseña
        passwordField.css('border', '2px solid #a94442');
    } else {
        document.getElementById('password-error').textContent = '';
        passwordField.removeClass('input-validation-error'); // Eliminar la clase de error de validación
        passwordField.css('border', ''); // Eliminar estilo de borde personalizado
    }
}

// Escuchar el evento 'blur' en el campo de contraseña
document.getElementById('txtPassword').addEventListener('blur', validarPassword);

// Escuchar el evento 'input' en el campo de contraseña
document.getElementById('txtPassword').addEventListener('input', function () {
    document.getElementById('password-error').textContent = '';
});

// Prevenir pegar la contraseña en el campo
document.getElementById('txtPassword').addEventListener('paste', function (e) {
    e.preventDefault();
});



// Validar UserName al perder el foco
function validarUserName() {
    var userName = document.getElementById('UserName').value;
    var regex = /^[A-Za-z0-9]+$/;

    if (!regex.test(userName)) {
        var errorMessage = 'El UserName solo puede contener letras y números.';
        document.getElementById('UserName-error').textContent = errorMessage;
        $("#UserName").addClass('input-validation-error'); // Agregar la clase de error de validación
        $("#UserName").css('border', '2px solid #a94442'); // Aplicar estilo de borde rojo
    } else {
        document.getElementById('UserName-error').textContent = '';
        $("#UserName").removeClass('input-validation-error'); // Eliminar la clase de error de validación
        $("#UserName").css('border', ''); // Eliminar estilo de borde personalizado
    }
}

// Escuchar el evento 'blur' en el campo de UserName
document.getElementById('UserName').addEventListener('blur', validarUserName);

// Escuchar el evento 'input' en el campo de UserName
document.getElementById('UserName').addEventListener('input', function () {
    document.getElementById('UserName-error').textContent = '';
});

//// Prevenir pegar caracteres especiales o espacios en el campo de UserName
document.getElementById('UserName').addEventListener('input', function (e) {
    var inputValue = e.target.value;
    e.target.value = inputValue.replace(/[^A-Za-z0-9]/g, '');
});





var txtPassword = document.getElementById("txtPassword");
var txtConfirmarPassword = document.getElementById("txtConfirmarPassword");

function validarContraseña() {
    var errorMessage = 'Las contraseñas no coinciden.';
    var errorElementSet = $('#ConfirmarPassword-error');
    if (txtPassword.value !== txtConfirmarPassword.value) {
        errorElementSet.text(errorMessage);
        $("#txtConfirmarPassword").css('border', '2px solid #a94442');
    } else {
        errorElementSet.text('');
        $("#txtConfirmarPassword").css('border', '');
    }
}

txtConfirmarPassword.addEventListener("input", validarContraseña);
