"use strict"
onlineShop.controller("AdminPedidoController", ['$scope', 'notificationService', 'adminPedidoService',
    function ($scope, notificationService, adminPedidoService) {
        $scope.titulo = "Administrador de Pedidos";
        $scope.pedido = "Pedidos";
        $scope.detalle = "Detalle de Pedido";
        $scope.lista = [];
        $scope.listaDetalle = [];
        $scope.NroPedido = 0;
        $scope.TotalNeto = 0;
        $scope.TotalIgv = 0;
        $scope.TotalPrecio = 0;
        $scope.Estado = "";
        var Listar = function ListarPedidos(res) {
            adminPedidoService.getPedido().then(function (data) {
                $scope.lista = data;
                if ($scope.lista.length > 0) {
                    if (res == "cap") {
                        notificationService.success("Se encontraron Pedidos");
                    }
                }
                else
                    notificationService.info("No se encontraron Pedidos");
            }, function (errorMsg) {
                notificationService.error(errorMsg);
            });
        }
        Listar("cap");
        $scope.verPedidos = function (id) {
            verPedidosId(id);
            $scope.NroPedido = id;
            $('html, body').stop().animate({ scrollTop: 0 });
            
        };

        var verPedidosId = function (id) {
            adminPedidoService.getDetalle(id).then(function (data) {
                $scope.listaDetalle = data;
                $scope.TotalNeto = 0;
                $scope.TotalIgv = 0;
                $scope.TotalPrecio = 0;
                $.each(data, function (i, elem) {
                    $scope.TotalNeto += elem["Precio"];
                    $scope.TotalIgv += elem["Igv"];
                    $scope.TotalPrecio += elem["PTotal"];
                    $scope.Estado = elem["idEstado"];
                    if (elem["idEstado"] == null) {
                        $scope.EstadoFinal = "Sin Confirmar"
                    }
                    else if (elem["idEstado"] == 1) {
                        $scope.EstadoFinal = "Aceptado"
                    }
                    else if (elem["idEstado"] == 2) {
                        $scope.EstadoFinal = "Anulado"
                    }
                    
                });
            }, function (errorMsg) {
                notificationService.error(errorMsg);
            });
        };

        var confirmaPedido = function (id) {
            adminPedidoService.CPedido(id).then(function (MensajeController) {
                notificationService.success(MensajeController.data)
            }, function (errorMsg) {
                notificationService.error(errorMsg);
            });
        };

        $scope.ConfirmarPedido = function (id) {
            confirmaPedido(id);            
            $scope.Estado = "";
            verPedidosId(0);
            Listar("");
            $scope.NroPedido = 0;
        };

    }])