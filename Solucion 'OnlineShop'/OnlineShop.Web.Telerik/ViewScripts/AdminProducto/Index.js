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
                $("#editarCerrar").click(CerrarPopUp);
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
                $("#grabarCerrar").click(CerrarPopUp);
            }
        });
    };

    var CerrarPopUp = function () {
        $("#" + $(this).attr("data-div")).data("kendoWindow").close();
    };

    var grabarProducto = function () {
        form = $("#FrmCrearProducto");
        $.ajax({
            url: UrlAction.createRegistroProducto,
            type: "POST",
            data: form.serialize(),
            success: function (data) {
                if (data.indexOf("Error") > 0) {
                    notify("success", data)
                }
                else {
                    notify("warning", data)
                }
                
            }
        })
    };

    //var grabarProducto = function () {
    //    notify("success", "ok")
    //}



})()