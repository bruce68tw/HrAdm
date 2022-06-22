var _me = {

    init: function () {        
        //datatable config
        var config = {
            columns: [
                { data: 'FldText' },
                { data: 'FldInt' },
                { data: 'FldDec' },
                { data: 'FldDate' },
                { data: 'FldDt' },
                { data: '_Fun' },
            ],
            columnDefs: [
				{ targets: [3], render: function (data, type, full, meta) {
                    return _date.mmToUiDate(data);
                }},
				{ targets: [4], render: function (data, type, full, meta) {
                    return _date.mmToUiDt2(data);
                }},
				{ targets: [5], render: function (data, type, full, meta) {
                    return _crudR.dtCrudFun(full.Id, full.Name, true, true, true);
                }},
            ],
        };

        //initial
        _crudR.init(config);

        //initial html editor
        _ihtml.init(_me.edit0, 'CustInput');

    },

    //TODO: add your code
    //onclick viewFile, called by XiFile component
    onViewFile: function (table, fid, elm) {
        _me.edit0.onViewFile(table, fid, elm);
    },

}; //class