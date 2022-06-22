var _me = {

    init: function () {        
        //datatable config
        var config = {
            columns: [
                { data: 'Code' },
                { data: 'Name' },
                { data: 'Status' },
                { data: '_Fun' },
                { data: '_Crud' },
            ],
            columnDefs: [
				{ targets: [2], render: function (data, type, full, meta) {
                    return _crudR.dtStatusName(data);                    
                }},
				{ targets: [3], render: function (data, type, full, meta) {
                    var html = '<a href="javascript:_me.onOpenTest(\'{0}\');">{1}</a>';
                    return _str.format(html, full.Code, '測試流程');
                }},
				{ targets: [4], render: function (data, type, full, meta) {
                    return _crudR.dtCrudFun(full.Id, full.Name, true, true, true);
                }},
            ],
        };

        _me.divEditTbar = $('#divEditTbar');

        //initial edit one/many
        _me.edit0 = new EditOne();
        _me.mNode = new EditMany('Id', null, 'tplNode', '.xf-node');
        _me.mLine = new EditMany('Id', null, 'tplLine', '.xd-line', 'Sort');
        _crudR.init(config, [_me.edit0, _me.mNode, _me.mLine]);

        //initial flow(jsplumb)
        _me.flow = new Flow('divEdit', _me.mNode, _me.mLine);

        //custom function
        _me.edit0.fnAfterSwap = _me.edit0_afterSwap;
        _me.edit0.fnAfterOpenEdit = _me.edit0_afterOpenEdit;
        //
        _me.mNode.fnLoadJson = _me.mNode_loadJson;
        _me.mNode.fnGetUpdJson = _me.mNode_getUpdJson;
        _me.mNode.fnValid = _me.mNode_valid;
        //
        _me.mLine.fnLoadJson = _me.mLine_loadJson;
        _me.mLine.fnGetUpdJson = _me.mLine_getUpdJson;
        _me.mLine.fnValid = _me.mLine_valid;

        //flow test
        _me.divFlowTest = $('#divFlowTest');
        _me.nowFlowCode = '';
    },

    edit0_afterSwap: function (toRead) {
        if (toRead) {
            _me.divEditTbar.hide();
        } else {
            _me.divEditTbar.show();
        }
    },

    //reset when create
    edit0_afterOpenEdit: function (fun, json) {
        if (fun === _fun.FunC) {
            _me.flow.reset();
        }
    },

    //#region mNode/mLine custom function
    //load nodes
    mNode_loadJson: function (json) {
        _me.flow.loadNodes(json);
    },

    //getUpdJson
    mNode_getUpdJson: function (upKey) {
        return _me.mNode.getUpdJson(upKey, _me.flow.divFlowBox);
    },

    //return boolean
    mNode_valid: function () {
        return true;
    },

    mLine_loadJson: function (json) {
        _me.flow.loadLines(json);
    },

    //getUpdJson
    mLine_getUpdJson: function (upKey) {
        return _me.mLine.getUpdJson(upKey, _me.flow.divLinesBox);
    },

    //return boolean
    mLine_valid: function () {
        return true;
    },
    //#endregion

    //測試流程
    onOpenTest: function (code) {
        //read old row if need
        _me.nowFlowCode = code;

        //show div
        _me.testToRead(false)
    },

    onSaveTest: function () {
        //check & save
        var data = {
            code: _me.nowFlowCode,
            data: _itextarea.get('Data', _me.divFlowTest),
        };
        _ajax.getStr('SaveFlowTest', data, function (error) {
            if (_str.isEmpty(error)) {
                _tool.msg('作業完成。');
                _me.testToRead(true);
            } else {
                _tool.msg(error);
            }
        });
    },

    //show Read form or not
    testToRead: function (toRead) {
        _crudR.swap(toRead, _me.divFlowTest);
    },

}; //class