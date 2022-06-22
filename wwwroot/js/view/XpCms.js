var _me = {

    init: function () {        
        //datatable config
        var config = {
            columns: [
                { data: 'Title' },
                { data: 'StartTime' },
                { data: 'EndTime' },
                { data: 'Status' },
                { data: 'Created' },
                { data: '_Fun' },
            ],
            columnDefs: [
				{ targets: [1], render: function (data, type, full, meta) {
                    return _date.mmToUiDt2(data);
                }},
				{ targets: [2], render: function (data, type, full, meta) {
                    return _date.mmToUiDt2(data);
                }},
				{ targets: [3], render: function (data, type, full, meta) {
                    return _crudR.dtStatusName(data);
                }},
				{ targets: [4], render: function (data, type, full, meta) {
                    return _date.mmToUiDt(data);
                }},
				{ targets: [5], render: function (data, type, full, meta) {
                    return _crudR.dtCrudFun(full.Id, '', true, true, true);
                }},
            ],
        };

        //initial
        _crudR.init(config);

        //initial html editor
        _ihtml.init(_me.edit0, 'Html');
    },

    onViewFile: function (table, fid, elm) {
        _me.edit0.onViewFile(table, fid, elm);
    },

}; //class