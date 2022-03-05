﻿var _me = {

    init: function () {        
        //datatable config
        var config = {
            columns: [
                { data: 'Name' },
                { data: '_Fun' },
            ],
            columnDefs: [
				{ targets: [1], render: function (data, type, full, meta) {
                    return _crud.dtCrudFun(full.Id, full.Name, true, true, true);
                }},
            ],
        };

        //initial
        _me.mUserRole = new EditMany('Id', 'eformUserRole', 'tplUserRole', 'tr');
        _me.mRoleProg = new EditMany('Id', 'eformRoleProg', 'tplRoleProg', 'tr');
        _crud.init(config, [null, _me.mUserRole, _me.mRoleProg]);

        //_me.mUserRole.fnLoadJson = _me.mUserRole_loadJson;
        //_me.mUserRole.fnGetUpdJson = _me.mUserRole_getUpdJson;

        //_me.divUsers = $('#divUsers');
        //_me.mUserRoleFids = ['Id', 'UserId']; //key fid, child fid
        _me.divUrBody = $('#tbodyUserRole');    //tbody of user role
        _me.tplUr = $('#tplUserRole').html();   //tpl of user role
        _me.modalUser = $('#modalUser');        //modal for select user
        _me.modalUserBody = _me.modalUser.find('tbody');
        _me.tplUser = $('#tplUser').html(); //tpl of modal user row
    },

    //on open select user modal
    onOpenUser: function () {
        _modal.showO(_me.modalUser);
    },

    //onclick find user
    onFindUser: function () {        
        var data = {
            account: _itext.get('Account', _me.modalUser),
            deptId: _iselect.get('DeptId', _me.modalUser),
        };
        _ajax.getJson('GetUsers', data, function (rows) {
            _me.modalUserBody.empty();
            for (var i = 0; i < rows.length; i++) {
                _me.modalUserBody.append($(Mustache.render(_me.tplUser, rows[i])));
            }
        });
    },

    //onclick ok at Item(R/Q/E) modal
    onUserModalOk: function () {
        //get checked columns list
        //var crudId = _itext.get('Id', _crud.getEform0());
        var rows = [];
        _me.modalUserBody.find(':checkbox:checked').each(function (idx) {
            var obj = $(this);
            var tr = obj.closest('tr');
            //data 屬性不區分大小寫 !!
            rows[idx] = {
                UserId: tr.data('id'),
                Account: tr.data('account'),
                UserName: tr.data('username'),
                DeptName: tr.data('deptname'),
            };
        });
        var rowLen = rows.length;
        if (rowLen === 0) {
            _tool.msg('請先選取資料。');
            return;
        }

        //append rows if not existed
        for (var i = 0; i < rowLen; i++) {
            //check existed
            var row = rows[i];
            if (_me.divUrBody.find('[value=' + row.UserId + ']').length > 0)
                continue;

            var tr = $(Mustache.render(_me.tplUr, row));
            _form.loadJson(tr, row);
            _me.mUserRole.boxSetNewId(tr);
            _me.divUrBody.append(tr);
        }

        //remove checked for next usage, hide modal
        _me.modalUser.find(':checkbox:checked').prop('checked', false);
        _modal.hideO(_me.modalUser);
    },

    /*
    //load json
    mUserRole_loadJson: function (json) {
        _me.mUserRole.urmLoadJson(json, _me.divUsers, _me.mUserRoleFids);
    },

    //getUpdJson
    mUserRole_getUpdJson: function (upKey) {
        return _me.mUserRole.urmGetUpdJson(upKey, _me.divUsers, _me.mUserRoleFids);
    },
    */

}; //class