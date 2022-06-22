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
                        ? _str.format('<button type="button" class="btn btn-outline-secondary btn-sm" onclick="_crudR.onUpdate(\'{0}\')">審核</button>', full.Id)
                        : '';
                }},
				{ targets: [5], render: function (data, type, full, meta) {
                    return _date.mmToUiDt(data);
                }},
				{ targets: [6], render: function (data, type, full, meta) {
                    return _crudR.dtCrudFun(full.Id, 'Leave', false, false, true);
                }},
            ],
        };

        //initial
        _me.edit0 = new EditOne();
        _me.edit0.fnAfterOpenEdit = _me.edit0_afterOpenEdit;
        _crudR.init(config, [_me.edit0], '審核');

        //other variables
        _me.eform = $('#eform');
        _me.divSignRows = $('#divSignRows');
    },

    edit0_afterOpenEdit: function (fun, json) {
        //reset form
        var form = _me.eform;
        _iselect.set('SignStatus', '', form);
        _itext.set('Note', '', form);

        var box = _me.divSignRows;
        if (fun == _fun.FunC) {
            box.empty();
        } else {
            _ajax.getView('GetSignRows', { id: _me.edit0.getKey() }, function (html) {
                box.html(html);
            });
        }
    },

    onSubmit: function () {
        var form = _me.eform;
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
        _ajax.getJson('SignRow', data, function (data) {
            //??
            _crudE.afterSave(data);
        });
    },

}; //class