var j = jQuery.noConflict();

j(function () {
    j("#txtFechaNacimiento").datepicker({
        dateFormat: 'dd/mm/yy',
        showOn: 'button',
        buttonImage: "../Images/Calendar.png",
        buttonImageOnly: true,
        changeMonth: true,
        changeYear: true
    });
    $(".ui-datepicker-trigger").css("width", "30px");
    $(".ui-datepicker-trigger").css("height", "30px");
});