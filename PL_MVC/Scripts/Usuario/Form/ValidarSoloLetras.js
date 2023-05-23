function validarInput(input) {
    var regex = /^[A-Za-z]+$/;
    var valor = input.value;

    if (!regex.test(valor)) {
        alert("Solo se permiten letras en este campo.");
        input.value = "";
    } else {
        input.value = valor.charAt(0).toUpperCase() + valor.slice(1);
    }
}