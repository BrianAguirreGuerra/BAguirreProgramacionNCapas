<script>
$(document).ready(function() {
  $('#btnAddUsuario').click(function() {
    var url = '@Url.Action("Add", "Usuario")'; // La URL de la acción en tu controlador
    window.location.href = url; // Redirige a la URL
  });
});
</script>