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



function validarEmail(input) {
    if (!/^[^\s@]+@[^\s@]+\.[^\s@]+$/.test(input.value)) {
        var errorMessage = 'Por favor, ingrese una dirección de correo electrónico válida.';
        var errorElementSet = $('#Email-error');
        errorElementSet.text(errorMessage);
        input.value = "";
        $("#txtEmail").css('border', '2px solid #a94442');
    } else {
        var errorElementSet = $('#Email-error');
        errorElementSet.text('');
        $("#txtEmail").css('border', '');
    }
}