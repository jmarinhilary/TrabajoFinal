"use strict"
onlineShop.factory('adminPedidoService', function ($http, $q) {
    var url = "http://localhost:2871/AdminPedido";
    return {
        getPedido: function () {
            var defered = $q.defer();
            $http.get(url + '/GetPedido').success(function (data) {
                defered.resolve(data);
            }).error(function (msg, error) {
                defered.reject(msg);
            });
            return defered.promise;
        },
        getDetalle: function (id) {
            var defered = $q.defer();
            $http.get(url + '/GetDetalle', { params: { idPedido: id } }).success(function (data) {
                defered.resolve(data);
            }).error(function (msg, error) {
                defered.reject(msg);
            });
            return defered.promise;
        },
        CPedido: function (id) {            
            var response = $http({
                method: "post",
                url: url + '/ConfirmarPedido',
                data: { idPedido: id },
                dataType: "json"
            });
            return response
        }
    }
});