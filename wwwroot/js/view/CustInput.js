﻿var _me = {

    init: function () {        
        //datatable config
        var config = {
            columns: [
                { data: 'Id' },
                { data: 'FldText' },
                { data: 'FldInt' },
                { data: 'FldDec' },
                { data: 'FldDate' },
                { data: 'FldDt' },
                { data: '_Fun' },
            ],
            columnDefs: [
				{ targets: [4], render: function (data, type, full, meta) {
                    return _date.dtsToUiDate(data);
                }},
				{ targets: [5], render: function (data, type, full, meta) {
                    return _date.dtsToUiDt2(data);
                }},
				{ targets: [6], render: function (data, type, full, meta) {
                    return _me.crudR.dtCrudFun(full.Id, full.Name, true, true, true);
                }},
            ],
        };

        //initial
        new CrudR(config);

        //initial html editor
        _ihtml.init(_me.edit0, 'CustInput');

    },

    //TODO: add your code
    //onclick viewFile, called by XiFile component
    onViewFile: function (table, fid, elm) {
        _me.edit0.onViewFile(table, fid, elm);
    },

}; //class