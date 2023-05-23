function validarEmail(input) {
    var regex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    var valor = input.value;

    if (!regex.test(valor)) {
        alert("Por favor, ingrese una dirección de correo electrónico válida.");
        input.value = ""; // Limpia el valor del campo
    }
}