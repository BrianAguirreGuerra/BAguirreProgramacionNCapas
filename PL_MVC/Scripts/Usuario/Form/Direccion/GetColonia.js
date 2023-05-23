$(document).ready(function () {
    $("#ddlMunicipio").change(function () {
        $("#ddlColonia").empty();
        var url = '/Usuario/GetColonia';
        $.ajax({
            type: 'POST',
            url: url,
            dataType: 'json',
            data: { IdMunicipio: $("#ddlMunicipio").val() },
            success: function (resultEstatus) {
                $("#ddlColonia").append('<option value="0">' + 'Seleccione un Municipio' + '</option>');
                $.each(colonias, function (i, colonias) {
                    $("#ddlColonia").append('<option value="'
                        + colonias.IdColonia + '">'
                        + colonias.Nombre + '</option>');
                });
            },
            error: function (ex) {
                alert('Failed.' + ex);
            }
        });
    });
});