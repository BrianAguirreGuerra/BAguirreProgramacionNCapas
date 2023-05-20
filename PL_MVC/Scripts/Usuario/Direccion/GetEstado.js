$(document).ready(function () {
    $("#ddlPais").change(function () {
        $("#ddlEstado").empty();
        $("#ddlMunicipio").empty();
        $("#ddlColonia").empty();
        var url = '/Usuario/GetEstado';
        $.ajax({
            type: 'POST',
            url: url,
            dataType: 'json',
            data: { IdPais: $("#ddlPais").val() },
            success: function (estados) {
                $("#ddlEstado").append('<option value="0">' + 'Seleccione un Estado' + '</option>');
                $("#ddlMunicipio").append('<option value="0">' + 'Seleccione un Municipio' + '</option>');
                $("#ddlColonia").append('<option value="0">' + 'Seleccione una Colonia' + '</option>');
                $.each(estados, function (i, estados) {
                    $("#ddlEstado").append('<option value="'
                        + estados.IdEstado + '">'
                        + estados.Nombre + '</option>');
                });
            },
            error: function (ex) {
                alert('Failed.' + ex);
            }
        });
    });
});