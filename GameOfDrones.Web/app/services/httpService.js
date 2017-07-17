app.factory('Service', function($http, apiConfig){
    return {
        getPosts: function () {
            return $http.get(apiConfig.url + "/posts/");
        },
        getPost: function (id) {
            return $http.get(apiConfig.url + "/posts/" + id);
        },
        addComment: function (comment) {
            return $http.post(apiConfig.url + "/posts/comment/", comment);
        }
    }
});