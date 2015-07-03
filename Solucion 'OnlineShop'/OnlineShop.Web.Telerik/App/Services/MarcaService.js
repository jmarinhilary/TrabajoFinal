"use strict"
onlineShop.factory('marcaService', function ($http, $q) {
    var url = "http://localhost:2871/Marca";
    return {
        traerMarca: function () {
            var defered = $q.defer();
            $http.get(url + '/GetMarcas').success(function (data) {
                defered.resolve(data);
            }).error(function (msg, error) {
                defered.reject(msg);
            });
            return defered.promise;
        },
        editMarca: function (item) {            
            var response = $http({
                method: "post",
                url: url + "/Update",
                data: JSON.stringify(item),
                dataType: "json"
            });
            return response;
        },

        GrabarMarca: function (item) {
            var response = $http({
                method: "post",
                url: url + "/Add",
                data: JSON.stringify(item),
                dataType: "json"                
            });
            return response;
        }


    }
});