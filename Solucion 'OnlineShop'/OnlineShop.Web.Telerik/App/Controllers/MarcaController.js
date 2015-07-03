"use strict";
onlineShop.controller("marcaController", ['$scope', 'marcaService', 'notificationService',
    function ($scope, marcaService, notificationService) {
        $scope.titulo = "Mantenimiento de Marcas de Laptops"
        $scope.lista = [];
        $scope.divMarcaMod = false;
        function Listar(str) {
            marcaService.traerMarca().then(function (data) {
                $scope.lista = data;
                if ($scope.lista.length > 0) {
                    if (str == "")
                    {
                        notificationService.success("Se encontraron registros");
                    }
                }
                else
                    notificationService.info("No se encontraron registros");
            }, function (errorMsg) {
                notificationService.error(errorMsg);
            });
        }
        Listar("");

        $scope.edit = function (item) {
            $scope.Id = item.Id;
            $scope.Nombre = item.Nombre;
            $scope.Descripcion = item.Descripcion;
            $scope.Imagen = item.Imagen;
            $scope.Operacion = "Actualizar";
            $scope.divMarcaMod = true;
        }

        $scope.add = function () {
            $scope.Id = "";
            $scope.Nombre = "";
            $scope.Descripcion = "";
            $scope.Imagen = "";
            $scope.Password = "";
            $scope.Operation = "Agregar";
            $scope.divMarcaMod = true;
        }

        $scope.Cancel = function () {
            $scope.divMarcaMod = false;
        }

        $scope.Save = function () {
            var Marca = {
                Id: $scope.Id,
                Nombre: $scope.Nombre,
                Descripcion: $scope.Descripcion,
                Imagen: $scope.Imagen
            };
            var Operacion = $scope.Operacion;

            if (Operacion == "Actualizar") {
                Marca.Id = $scope.Id;
                var result = marcaService.editMarca(Marca);
                result.then(function (MensajeController) {
                    Listar(MensajeController);
                    notificationService.success(MensajeController.data);
                    $scope.divMarcaMod = false;
                }, function () {
                    notificationService.warning('Error al Actualizar');
                });
            }
            else {
                var result = marcaService.GrabarMarca(Marca);
                result.then(function (MensajeController) {
                    Listar(MensajeController);
                    notificationService.success(MensajeController.data);
                    $scope.divMarcaMod = false;
                }, function () {
                    notificationService.warning('Error al Grabar');
                });
            }
        }

}]);