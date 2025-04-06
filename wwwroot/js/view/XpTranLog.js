var _me = {

    init: function () {        
        //datatable config
        var config = {
            columns: [
                { data: 'TableName' },
                { data: 'ColName' },
                { data: 'RowId' },
                { data: 'Act' },
                { data: 'OldValue' },
                { data: 'NewValue' },
                { data: 'Created' },
            ],
            columnDefs: [
				{ targets: [6], render: function (data, type, full, meta) {
                    return _date.dtsToUiDt(data);
                }},
            ],
        };

        //initial
        new CrudR(config);
    },

}; //class