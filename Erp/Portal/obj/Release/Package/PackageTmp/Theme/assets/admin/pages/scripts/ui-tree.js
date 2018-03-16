var UITree = function () {
    var handleSample2 = function (orgTreeJsonData) {
    
        $('#tree_2').jstree({
            'plugins': ["wholerow", "checkbox", "types"],
            'core': {
                "themes": {
                    "responsive": false
                },
                'data': orgTreeJsonData
            },
            "types": {
                "default": {
                    "icon": "fa fa-folder icon-state-warning icon-lg"
                },
                "file": {
                    "icon": "fa fa-file icon-state-warning icon-lg"
                }
            },
        });
    }


    return {
        //main function to initiate the module
        init: function (orgTreeJsonData) {
            handleSample2(orgTreeJsonData);
        }

    };

}();



