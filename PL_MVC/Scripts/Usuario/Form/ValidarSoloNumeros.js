function validarNumero(input) {
    var valor = input.value;

    if (isNaN(valor) || valor.length > 20) {
        alert("Por favor, ingrese solo números (máximo 20 dígitos).");
        input.value = ""; // Limpia el valor del campo
    }
}