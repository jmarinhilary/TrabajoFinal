(function () {
    $(document).ready(function () {        
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
                $("#editProducto").click(editarProducto);
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

    var imageProductoModal = function () {
        _id = $(this).attr("data-Id");
        $.ajax({
            url: UrlAction.imagenProductoModal,
            type: "POST",
            data: { id: _id },
            success: function (data) {
                $("#imagenProducto").html(data).OpenKendoPopup({ title: 'Imagen Producto', width: "60%", modal: true })
            }
        })
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
                if (data.MessageResult.indexOf("Error") > 0) {
                    notify("success", data.MessageResult)
                }
                else {
                    notify("warning", data.MessageResult)
                }

            }
        })
    };

    var editarProducto = function () {
        form = $("#FrmCrearProducto");
        $.ajax({
            url: UrlAction.editRegistroProducto,
            type: "POST",
            data: form.serialize(),
            success: function (data) {
                if (data.MessageResult.indexOf("Error") > 0) {
                    notify("success", data.MessageResult)
                }
                else {
                    notify("warning", data.MessageResult)
                }

            }
        })
    }

    window.OnDataBound = function () {
        $(".editarModal").click(editProductoModal);
        $(".imageModal").click(imageProductoModal);
    }


})()