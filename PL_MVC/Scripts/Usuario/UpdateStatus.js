function UpdateStatus(IdUsuario, estatus) {
    var Estatus = estatus.checked
    $.ajax({
        type: 'POST',
        url: '@Url.Action("UpdateStatus")',
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