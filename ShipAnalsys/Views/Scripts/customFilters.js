/// <reference path="/component/angular/angular.min.js" />

angular.module("iso19030")
    .filter("range", function ($filter) {
        return function (data, page, size) {
            ; if (angular.isArray(data) && angular.isNumber(page) && angular.isNumber(size)) {
                var start_index = (page - 1) * size;
                if (data.length < start_index) {
                    return [];
                } else {
                    console.log(page+" & "+start_index)
                    return $filter('limitTo')(data, size, start_index);
                }
            } else {
                return data;
            }
        }
    })
    .filter("pageCount", function () {
        return function (data, size) {
            if (angular.isArray(data)) {
                var result = [];
                for (var i = 0; i < Math.ceil(data.length / size) ; i++) {
                    result.push(i);
                }
                return result;
            } else {
                return data;
            }
        }
    });