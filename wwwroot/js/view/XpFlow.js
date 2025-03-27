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
        //_me.edit0 = new EditOne();
        //debugger; 
        _me.mNode = new EditMany('Id', 'eformNode', 'tplNode', '.xd-node');
        _me.mLine = new EditMany('Id', 'eformLine', 'tplLine', '.xd-line', 'Sort');
        _crudR.init(config, [null, _me.mNode, _me.mLine]);

        //initial flow(jsplumb)
        _me.flowForm = new FlowForm('divEdit', _me.mNode, _me.mLine);

        //custom function
        //_me.edit0.fnAfterSwap = _me.edit0_afterSwap;
        //_me.edit0.fnAfterOpenEdit = _me.edit0_afterOpenEdit;
        //
        _me.mNode.fnLoadJson = _me.mNode_loadJson;
        _me.mNode.fnGetUpdJson = _me.mNode_getUpdJson;
        _me.mNode.fnValid = _me.mNode_valid;
        //
        _me.mLine.fnLoadJson = _me.mLine_loadJson;
        _me.mLine.fnGetUpdJson = _me.mLine_getUpdJson;
        _me.mLine.fnValid = _me.mLine_valid;

        //for flow test
        _me.divFlowTest = $('#divFlowTest');
        _me.nowFlowCode = '';
    },

    //auto called
    fnAfterSwap: function (toRead) {
        if (toRead) {
            _me.divEditTbar.hide();
        } else {
            _me.divEditTbar.show();
        }
    },

    //auto called !!
    //reset when create
    fnAfterOpenEdit: function (fun, json) {
        if (fun === _fun.FunC) {
            _me.flowForm.reset();
        }
    },

    /**
     * auto called !!
     * jsPlumb line container must visible when rendering
     * see _crudE.js _updateOrViewA()
     * @param {string} fun
     * @param {string} key
     * @returns {bool}
     */
    fnUpdateOrViewA: async function (fun, key) {
        var act = (fun == _fun.FunU)
            ? 'GetUpdJson' : 'GetViewJson';
        return await _ajax.getJsonA(act, { key: key }, function (json) {
            //show container first
            _crudR.toEditMode(fun, () => {
                _crudE._loadJson(json);
                _crudE._setEditStatus(fun);
                _crudE._afterOpenEdit(fun, json);
            });
        });
    },

    //#region mNode/mLine custom function
    //load nodes
    mNode_loadJson: function (json) {
        //_me.mNode.loadJson(json);
        _me.flowForm.loadNodes(_crudE.getRowsByJson(json));

        //this.flowBox.loadNodes(rows);

    },

    //getUpdJson
    mNode_getUpdJson: function (upKey) {
        return _me.mNode.getUpdJson(upKey, _me.mNode.eform);
    },

    //return boolean
    mNode_valid: function () {
        return true;
    },

    mLine_loadJson: function (json) {
        //debugger;
        //_me.divEdit.show();
        //await _time.sleepA(10000);
        //_me.mNode.loadJson(json);
        _me.flowForm.loadLines(_crudE.getRowsByJson(json));
    },

    //getUpdJson
    mLine_getUpdJson: function (upKey) {
        return _me.mLine.getUpdJson(upKey, _me.flowForm.divLinesBox);
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
        await _ajax.getStrA('SaveFlowTest', data, function (error) {
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