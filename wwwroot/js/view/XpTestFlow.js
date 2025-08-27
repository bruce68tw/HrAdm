var _me = {

    init: function () {        
        //datatable config
        var config = {
            columns: [
                { data: 'FlowName' },
                { data: 'FlowStatusName' },
                { data: 'NodeName' },
                { data: 'SignerName' },
                { data: '_Fun' },
                { data: 'Created' },
                { data: '_Crud' },
            ],
            columnDefs: [
				{ targets: [4], render: function (data, type, full, meta) {
                    return (full.CanSign == 1)
                        ? `<button type="button" class="btn btn-outline-secondary btn-sm" data-onclick="_me.crudR.onUpdateA" data-args="${full.Id}">審核</button>`
                        : '';
                }},
				{ targets: [5], render: function (data, type, full, meta) {
                    return _date.dtsToUiDt(data);
                }},
				{ targets: [6], render: function (data, type, full, meta) {
                    return _me.crudR.dtCrudFun(full.Id, 'Leave', false, false, true);
                }},
            ],
        };

        //initial
        _me.edit0 = new EditOne();
        new CrudR(config, [_me.edit0], '審核');

        //other variables
        //_me.eform = $('#eform');
        _me.divSignRows = $('#divSignRows');
    },

    //auto called !!
    fnAfterOpenEdit: async function (fun, json) {
        //reset form
        var form = _me.eform0;
        _iselect.set('SignStatus', '', form);
        _itext.set('Note', '', form);

        var box = _me.divSignRows;
        if (fun == _fun.FunC) {
            box.empty();
        } else {
            await _ajax.getViewA('GetSignRows', { id: _me.edit0.getKey() }, function (html) {
                box.html(html);
            });
        }
    },

    onSubmitA: async function () {
        var form = _me.eform0;
        var status = _iselect.get('SignStatus', form);
        if (_str.isEmpty(status)) {
            _tool.msg('審核結果不可空白。');
            return;
        }

        var data = {
            id: _itext.get('SignId', form),
            status: status,
            note: _itext.get('Note', form),
        };
        await _ajax.getJsonA('SignRow', data, function (data) {
            //??
            _me.crudE.afterSave(data);
        });
    },

}; //class