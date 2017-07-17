app.factory('Posts', function($resource, apiConfig){
	return $resource(apiConfig.url+'/posts/:id');
});

app.factory('Comments', function($resource, apiConfig){
	return $resource(apiConfig.url+'/posts/comment/:id');
});