(function () {
    $(document).ready(function () {
        $(".editarModal").click(editProductoModal);
        $("#CrearProducto").click(createProductoModal);
    });

    var editProductoModal = function () {
        _id = $(this).attr("data-Id");
        $.ajax({
            url: UrlAction.editProducto,
            type: "POST",
            data: { id: _id },
            success: function (data) {
                $("#editarProducto").html(data).OpenKendoPopup({ title: 'Editar Producto', width: "60%", modal: true });
                $("#toastrNot").click(grabarProducto);
            }
        });

    };

    var createProductoModal = function () {
        $.ajax({
            url: UrlAction.createProducto,
            type: "POST",
            success: function (data) {
                $("#crearProducto").html(data).OpenKendoPopup({ title: 'Editar Producto', width: "60%", modal: true });
            }
        });
    };

    var grabarProducto = function () {
        notify("success", "ok")
    }



})()