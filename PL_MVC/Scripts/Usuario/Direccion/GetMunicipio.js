$(document).ready(function () {
    $("#ddlEstado").change(function () {
        $("#ddlMunicipio").empty();
        $("#ddlColonia").empty();
        var url = '/Usuario/GetMunicipio';
        $.ajax({
            type: 'POST',
            url: url,
            dataType: 'json',
            data: { IdEstado: $("#ddlEstado").val() },
            success: function (municipios) {
                $("#ddlMunicipio").append('<option value="0">' + 'Seleccione un Municipio' + '</option>');
                $("#ddlColonia").append('<option value="0">' + 'Seleccione una Colonia' + '</option>');
                $.each(municipios, function (i, municipios) {
                    $("#ddlMunicipio").append('<option value="'
                        + municipios.IdMunicipio + '">'
                        + municipios.Nombre + '</option>');
                });
            },
            error: function (ex) {
                alert('Failed.' + ex);
            }
        });
    });
});