/// <reference path="/component/angular/angular.min.js" />

angular.module("iso19030")
    .constant("shipdataActiveClass", "active")
    .constant("shipdataPageCount", 500)
    .controller("shipDataListController", function ($scope, shipdataPageCount, shipdataActiveClass) {

        $scope.selectedPage = 1;
        $scope.pageSize = shipdataPageCount;

        $scope.selectPage = function (newPage) {
            console.log("newpage : "+newPage)
            $scope.selectedPage = newPage;
        }

        $scope.getPageClass = function (page) {
            return $scope.selectedPage == page ? shipdataActiveClass : "";
        }
        



}
)