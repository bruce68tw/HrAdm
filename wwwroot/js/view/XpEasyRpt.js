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
                    return _me.crudR.dtStatusName(data);
                }},
				{ targets: [3], render: function (data, type, full, meta) {
                    return _me.crudR.dtCrudFun(full.Id, full.Name, true, true, true);
                }},
            ],
        };

        //initial
        new CrudR(config);
    },

}; //class