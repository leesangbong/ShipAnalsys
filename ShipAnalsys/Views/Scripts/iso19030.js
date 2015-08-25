/// <reference path="/component/angular/angular.min.js" />

angular.module("iso19030")
    .constant("dataUrl", "http://localhost:55147/api/shipdatas/")
    .controller("shipDataController", function ($scope, $resource, dataUrl) {

        $scope.startDate_input;
        $scope.endDate_input;
        $scope.data = {};
        $scope.interval_input;
        $scope.loading = false;
        $scope.rqShipData = $resource(dataUrl + ':startDate/:endDate/:interval',
            {
                startDate: '@startDate',
                endDate: '@endDate',
                interval : '@interval'
                
            },
            {
                getByFilter: { method: "GET", isArray: true }

            });

        $scope.listShipData = function () {
            console.log("interval : "+$scope.interval_input);
            $('.ui.dimmer').dimmer('show')
            $scope.loading = true;
            $scope.listByFilter();
        }

        $scope.listByFilter = function () {
            $scope.rqShipData.getByFilter({ startDate: $scope.startDate_input, endDate: $scope.endDate_input, interval:$scope.interval_input}, function (data) {
                $scope.loading = false;
                $('.ui.dimmer').dimmer('hide')
                $scope.data.shipDatas = data;

            });
           
        }
    });


