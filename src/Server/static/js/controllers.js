var docularControllers = angular.module('docularApp', ['ngResource']);

docularControllers.controller('SidebarController',  ['$scope', '$location', function($scope, $location){
    $scope.linksTop = [
        {name: 'Search', link: '/search', icon: 'pe-7s-search'},
        {name: 'Documents', link: '/documents', icon: 'pe-7s-box1'},
        {name: 'Categories', link: '/categories', icon: 'pe-7s-folder'},
        {name: 'Tags', link: '/tags', icon: 'pe-7s-ticket'}
    ];

    $scope.linksBottom = [
        {name: 'Settings', link: '/settings', icon: 'pe-7s-config'}
    ];

    $scope.isActive = function(path) {
        console.log($location);

        if ($location.path().substr(0, path.length) == path) {
            return "active"
        } else {
            return ""
        }
    }
}]);

docularControllers.controller('MainController', function($scope){

});

docularControllers.controller('SearchController', function($scope){

});

docularControllers.controller('DocumentsController', function($scope){

});

docularControllers.controller('CategoriesController', function($scope){

});

docularControllers.controller('TagsController', function($scope){

});

docularControllers.controller('SettingsController', function($scope){

});