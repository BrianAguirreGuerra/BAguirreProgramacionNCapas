$(document).ready(function () {
    $("#ddlArea").change(function () {
        $("#ddlDepartamento").empty();
        var url = '/Producto/GetDepartamento';
        $.ajax({
            type: 'POST',
            url: url,
            dataType: 'json',
            data: { IdArea: $("#ddlArea").val() },
            success: function (departamentos) {
                $("#ddlDepartamento").append('<option value="0">' + 'Seleccione un Departamento' + '</option>');
                $.each(departamentos, function (i, departamentos) {
                    $("#ddlDepartamento").append('<option value="'
                        + departamentos.IdDepartamento + '">'
                        + departamentos.Nombre + '</option>');
                });
            },
            error: function (ex) {
                alert('Failed.' + ex);
            }
        });
    });
});