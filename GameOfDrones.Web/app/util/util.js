(function () {
    var arrayExtensions = {
        find: function (arr, callback) {
            var newArr = [],
                len = arr.length,
                i;
            for (i = 0; i < len; i++) {
                var e = arr[i];
                if (callback(e)) {
                    newArr.push(e);
                }
            }
            return newArr;
        },
        remove: function (arr, callback) {
            var newArr = [],
                len = arr.length,
                i;
            for (i = 0; i < len; i++) {
                var e = arr[i];
                if (!callback(e)) {
                    newArr.push(e);
                }
            }
            return newArr;
        },
        map: function (arr, callback) {
            var newArr = [],
                len = arr.length,
                i;
            for (i = 0; i < len; i++) {
                var e = arr[i];
                var n = callback(e);
                newArr.push(n);
            }
            return newArr;
        }
    };
    window.arrayExtensions = arrayExtensions;
})()
