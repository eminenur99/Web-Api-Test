vartestApp = angular
    .module("appOdev", [])
    .controller("OdevController", function ($scope, $http) {
        $scope.saveStatus = true;
        $scope.updateObjId = null;

        $scope.getOdev = function () {
            $http({
                method: "get",
                url: "/api/odev"
            }).then(function (response) {
                $scope.odev = response.data;
            }, function () {
                alert("Error Occur");
            })
        }; 
        $scope.getOdev();
        $scope.InsertData = function (Action) {
            
            if (Action == "Ekle") {
                $scope.odev = {};
              
                $scope.odev.Name = $scope.name;
                $scope.odev.StartDateTime =  ($scope.startdate ); //2019-01-06
                $scope.odev.EndDateTime = ( $scope.enddate); //2019-01-06
                $http({
                    method: "post",
                    url: "/api/odev/Create",
                    datatype: "json",
                    data: JSON.stringify($scope.odev)
                }).then(function (response) {
                    $scope.getOdev();
                })

            }



            else {
                $scope.odev = {};
                $scope.odev.Name = $scope.name;
                $scope.odev.StartDateTime = $scope.startdate;
                $scope.odev.EndDateTime = $scope.enddate;
                $http({
                    method: "put",
                    url: "api/odev/Update/" + $scope.updateObjId,
                    datatype: "json",
                    data: JSON.stringify($scope.odev)
                }).then(function (response) {
                   
                    $scope.getOdev();
                    $scope.name = "";
                    $scope.startdate = "";
                    $scope.enddate = "";
                    $scope.saveStatus = true;
                })
            }
        }
         

        
        $scope.DeleteEmp = function (odv) {
            $http({
                method: "delete",
                url: "/api/odev/Delete/" + odv.odevId,
                datatype: "json",
            }).then(function (response) {
              
                $scope.getOdev();
            })
        };

        $scope.UpdateEmp = function (odv) {
            $scope.updateObjId = odv.odevId;
            $scope.name = odv.name;
            $scope.startdate = odv.startdate;
            $scope.enddate = odv.enddate;
            $scope.saveStatus = false;
            };  

    }); 
        
