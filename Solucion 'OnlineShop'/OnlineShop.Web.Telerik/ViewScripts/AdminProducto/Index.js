(function () {
    $(document).ready(function () {
        $(".editarModal").click(editProductoModal);
        $("#CrearProducto").click(createProductoModal);
    });

    var editProductoModal = function () {
        _id = $(this).attr("data-Id");
        $.ajax({
            url: UrlAction.editProductoModal,
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
            url: UrlAction.createProductoModal,
            type: "POST",
            success: function (data) {
                $("#crearProducto").html(data).OpenKendoPopup({ title: 'Editar Producto', width: "60%", modal: true });
                $("#grabarProducto").click(grabarProducto);
            }
        });
    };

    var grabarProducto = function () {
        form = $("#FrmCrearProducto");
        $.ajax({
            url: UrlAction.createRegistroProducto,
            type: "POST",
            data: form.serialize(),
            success: function () {

            }
        })
    };

    //var grabarProducto = function () {
    //    notify("success", "ok")
    //}



})()