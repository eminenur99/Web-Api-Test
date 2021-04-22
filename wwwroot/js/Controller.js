// <reference path="Module.js">
// <reference path="Service.js">


vartestApp = angular
    .module("app", [])
    .controller("OgrenciController", function ($scope, $http) {
        $scope.saveStatus = true;
        $scope.updateObjId = null;

        $scope.getOgrenci = function () {
            $http.get('/api/ogrenci').then(function (response) {
                $scope.ogrenci = response.data;
            });
        }

        $scope.InsertData = function (Action) {
           //  var Action = document.getElementById("save").getAttribute("value");
            if (Action == "Ekle") {
                $scope.ogrenci = {};
                //$scope.ogrenci.OgrenciId = 'test';
                $scope.ogrenci.FirstName = $scope.firstname;
                $scope.ogrenci.LastName = $scope.lastname;
                $scope.ogrenci.OdevId = parseInt($scope.odevid);
                $http({
                    method: "post",
                    url: "/api/ogrenci/Create",
                    datatype: "json",
                    data: JSON.stringify($scope.ogrenci)
                }).then(function (response) {
                    $scope.getOgrenci();
                })

            }
            else {
                $scope.ogrenci = {};
                $scope.ogrenci.FirstName = $scope.firstname;
                $scope.ogrenci.LastName = $scope.lastname;
                $scope.ogrenci.OdevId = parseInt($scope.odevid);
                $http({
                    method: "put",
                    url: "api/ogrenci/Update/" + $scope.updateObjId,
                    datatype: "json",
                   data: JSON.stringify($scope.ogrenci)
                }).then(function (response) {
                  //  alert(response.data);
                    $scope.getOgrenci();
                    $scope.firstname = "";
                    $scope.lastname = "";
                    $scope.odevid = "";
                    $scope.saveStatus = true;
                })
            }
         }  

        $scope.DeleteEmp = function (ogr) {
            $http({
                method: "delete",
                url: "/api/ogrenci/Delete/" + ogr.ogrenciId,
                datatype: "json",
            }).then(function (response) {
               // alert(response.data);
                $scope.getOgrenci();
            })
        }; 

        $scope.UpdateEmp = function (ogr) {
            $scope.updateObjId = ogr.ogrenciId;
            $scope.firstname = ogr.firstName;
            $scope.lastname = ogr.lastName;
            $scope.odevid = ogr.odevId;
            $scope.saveStatus = false;
        }  










        $scope.getOgrenci();



  }); 