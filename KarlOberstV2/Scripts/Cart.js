$(document).ready(function () {
    $(".add-cart").click(function (result) {
        var id = $(this).attr("value");
        var selectorForm = "#" + id.toString();
        //var serializedObj = $(selectorForm).serialize();
        var nombre = $(selectorForm + " #nombre").attr("value");
        var cantidad = $(selectorForm + " #cantidad").attr("value");


        $.ajax({
            type: "POST",
            url: '/Cart/Add',
           // content: "application/json; charset=utf-8",
            data: {
                idProd: id,
                cant: cantidad
            },
            success: function () {
                alert("Se ha añadido " + nombre.toString() + " al carrito");
            }
        })


       
    });
});3