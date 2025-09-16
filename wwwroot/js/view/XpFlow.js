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
                    return _me.crudR.dtStatusName(data);
                }},
				{ targets: [3], render: function (data, type, full, meta) {
                    var html = '<a href="javascript:_me.onOpenTest(\'{0}\');">{1}</a>';
                    return _str.format(html, full.Code, '測試流程');
                }},
				{ targets: [4], render: function (data, type, full, meta) {
                    return _me.crudR.dtCrudFun(full.Id, full.Name, true, true, true);
                }},
            ],
        };

        //save, back button
        _me.divEditTbar = $('#divEditTbar');

        //initial edit one/many, rowsBox(參數2) 使用 eform
        _me.mNode = new EditMany('Id', 'eformNodes', 'tplNode', '.xd-tr');
        _me.mLine = new EditMany('Id', 'eformLines', 'tplLine', '.xd-tr', 'Sort');
        new CrudR(config, [null, _me.mNode, _me.mLine]);

        //initial flow edit form
        _me.flowMany = new FlowMany('divEdit', _me.mNode, _me.mLine);

        //custom function
        //_me.edit0.fnAfterSwap = _me.edit0_afterSwap;
        //_me.edit0.fnAfterOpenEdit = _me.edit0_afterOpenEdit;
        //
        _me.mNode.fnLoadRows = _me.mNode_loadRows;
        _me.mNode.fnGetUpdJson = _me.mNode_getUpdJson;
        _me.mNode.fnValid = _me.mNode_valid;
        //
        _me.mLine.fnLoadRows = _me.mLine_loadRows;
        _me.mLine.fnGetUpdJson = _me.mLine_getUpdJson;
        _me.mLine.fnValid = _me.mLine_valid;

        //for flow test
        _me.divFlowTest = $('#divFlowTest');
        _me.nowFlowCode = '';
    },

    //auto called
    fnAfterSwap: function (toRead) {
        if (toRead) {
            _obj.hide(_me.divEditTbar);
        } else {
            _obj.show(_me.divEditTbar);
        }
    },

    //auto called !!
    //reset when create
    fnAfterOpenEdit: function (fun, json) {
        var isAdd = (fun === EstrFun.Create);
        if (isAdd) {
            _me.flowMany.reset();
        }
        _me.flowMany.setEdit(isAdd || (fun === EstrFun.Update));
    },

    /**
     * auto called !!
     * jsPlumb line container must visible when rendering
     * see _me.crudE.js _updateOrViewA()
     * @param {string} fun
     * @param {string} key
     * @returns {bool}
     */
    fnUpdateOrViewA: async function (fun, key) {
        var act = (fun == EstrFun.Update)
            ? 'GetUpdJson' : 'GetViewJson';
        return await _ajax.getJsonA(act, { key: key }, function (json) {
            //show container first
            _me.crudR.toEditMode(fun, () => {
                _me.crudE.loadJson(json);
                _me.crudE.setEditStatus(fun);
                _me.crudE.afterOpen(fun, json);
            });
        });
    },

    //#region mNode/mLine custom function
    //load nodes
    mNode_loadRows: function (rows) {
        _me.flowMany.loadNodes(rows);
    },

    //getUpdJson
    mNode_getUpdJson: function (upKey) {
        return _me.mNode.getUpdJsonByRsb(upKey);
    },

    //return boolean
    mNode_valid: function () {
        return true;
    },

    mLine_loadRows: function (rows) {
        _me.flowMany.loadLines(rows);
    },

    //getUpdJson
    mLine_getUpdJson: function (upKey) {
        return _me.mLine.getUpdJsonByRsb(upKey);
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

    onSaveTestA: async function () {
        //check & save
        var data = {
            code: _me.nowFlowCode,
            data: _itextarea.get('Data', _me.divFlowTest),
        };
        await _ajax.getStrA('SaveTest', data, function (error) {
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
        _me.crudR.swap(toRead, _me.divFlowTest);
    },

}; //class