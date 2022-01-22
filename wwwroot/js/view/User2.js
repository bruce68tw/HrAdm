var _me = {

    init: function () {        
        //datatable config
        var config = {
            columns: [
                { data: 'Account' },
                { data: 'Name' },
                { data: 'DeptName' },
                { data: 'Status' },
                { data: '_Fun' },
            ],
            columnDefs: [
				{ targets: [3], render: function (data, type, full, meta) {
                    return _crud.dtSetStatus(full.Id, data);
                }},
				{ targets: [4], render: function (data, type, full, meta) {
                    return _crud.dtCrudFun(full.Id, full.Name, true, true, true);
                }},
            ],
        };

        //initial
        _me.mCms = new EditMany('Id', 'eformCms', 'tplCms', 'tr');
		_crud.init(config, [null, _me.mCms]);
    },

}; //class