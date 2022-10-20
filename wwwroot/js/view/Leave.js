var _me = {

    init: function () {        
        //datatable config
        var config = {
            columns: [
                { data: 'UserName', sortable: true },
                { data: 'AgentName' },
                { data: 'LeaveName', sortable: true },
                { data: 'StartTime', sortable: true },
                { data: 'EndTime' },
                { data: 'Hours' },
                { data: 'SignStatusName', sortable: true },
                { data: 'Created' },
                { data: '_Fun' },
            ],
            columnDefs: [
				{ targets: [3], render: function (data, type, full, meta) {
                    return _date.mmToUiDt2(data);
                }},
				{ targets: [4], render: function (data, type, full, meta) {
                    return _date.mmToUiDt2(data);
                }},
				{ targets: [7], render: function (data, type, full, meta) {
                    return _date.mmToUiDt(data);
                }},
				{ targets: [8], render: function (data, type, full, meta) {
                    return _crudR.dtCrudFun(full.Id, 'Leave', true, true, true);
                }},
            ],
        };

        //initial
        _me.edit0 = new EditOne();
        _me.edit0.fnAfterOpenEdit = _me.edit0_afterOpenEdit;
        _crudR.init(config, [_me.edit0]);

        //other variables
        _me.divSignRows = $('#divSignRows');
    },

    //TODO: add your code
    //onclick viewFile, called by XiFile component
    onViewFile: function (table, fid, elm) {
        _me.edit0.onViewFile(table, fid, elm);
    },

    //開啟畫面後會執行這個函數
    edit0_afterOpenEdit: function (fun, json) {
        var box = _me.divSignRows;
        if (fun == _fun.FunC) {     //表示新增
            box.empty();

            //設定初始值
            var eform = _me.edit0.eform;    //get edit form object
            _iselect.set('LeaveType', 'S', eform);          //設定下拉式欄位
            _idt.set('StartTime', '2022/10/1 9:00', eform); //設定 "日期時間" 欄位
        } else {
            _ajax.getView('GetSignRows', { id: _me.edit0.getKey() }, function (html) {
                box.html(html);
            });
        }
    },

}; //class