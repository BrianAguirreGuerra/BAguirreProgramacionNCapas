function UpdateStatus(IdUsuario, estatus) {
    var Estatus = estatus.checked
    var url = '/Usuario/UpdateStatus';
    $.ajax({
        type: 'POST',
        url: url,
        dataType: 'json',
        data: { IdUsuario, Estatus },
        success: function (resultEstatus) {
            if (resultEstatus.Correct == true) {
                alert('Se ha actualizado correctamente el status del usuario')
            }
            else {
                alert('No se pudo actualizar correctamente el status' + resultEstatus.ErrorMessage)
            }
        },
        error: function (ex) {
            alert('Failed.' + ex);
        }
    });
}