var _me = {

    init: function () {        
        //datatable config
        var config = {
            columns: [
                { data: 'Name' },
                { data: 'Status' },
                { data: 'TplFile' },
                { data: '_Crud' },
            ],
            columnDefs: [
				{ targets: [1], render: function (data, type, full, meta) {
                    return _crud.dtStatusName(data);
                }},
				{ targets: [3], render: function (data, type, full, meta) {
                    return _crud.dtCrudFun(full.Id, full.Name, true, true, true);
                }},
            ],
        };

        //initial
        _crud.init(config);
    },

}; //class