var app = angular.module("FetchNStore", []);

var start;
//alternate
/*app.controller("MyCtrl", ['$scope', '$http', function ($scope, $http) {

}])*/

app.controller("FetchCtrl", function ($scope, $http, FetchFactory) {
    $scope.view = () => { $scope; debugger };

    $scope.Fetch = function () {
        FetchFactory.FetchURL($scope.UserURL).then(function (response) {
            var end = Date.now();

            $scope.status = response.status
            $scope.method = response.config.method
            $scope.url = response.config.url
            $scope.responseTime = end - start
            $scope.milliseconds = "milliseconds"

        }, function (error) {
            var end = Date.now();

            $scope.status = error.status
            $scope.method = error.config.method
            $scope.url = error.config.url
            $scope.responseTime = end - start
            $scope.milliseconds = "milliseconds"
        });
    }

    $scope.StoreResponse = function () {
        var responseObject = 
            {
                statusCode: $scope.status,
                httpMethod: $scope.method,
                url: $scope.url,
                responseTime: $scope.responseTime
            }

        $http({
            method: 'POST',
            url: '/api/Response',
            data: responseObject
        }).then(function (response) {
            console.log("Success")
        }, function (error) {
            alert("Post Failed!!")
        });

    }
})

app.service("FetchFactory", function($http){


    var FetchURL = function (UserURL) {
        start = Date.now();

        return $http.get(UserURL)

    }

    var ShowData = function () {
        $http({
            method: 'GET',
            url: '/api/Response'
        }).then(function (response) {
            console.log(response)
        })
    }

    return {
        FetchURL:FetchURL, ShowData:ShowData
    }
})


