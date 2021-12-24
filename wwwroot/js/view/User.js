﻿var _me = {

    init: function () {        
        //datatable config
        var config = {
            columns: [
                { data: 'Account' },
                { data: 'Name' },
                { data: 'DeptName' },
                { data: 'Status' },
                { data: '_Fun' },
            ],
            columnDefs: [
				{ targets: [3], render: function (data, type, full, meta) {
                    //return _crud.dtSetStatus(full.Id, data);
                    return _crud.dtStatusName(data);
                }},
				{ targets: [4], render: function (data, type, full, meta) {
                    return _crud.dtCrudFun(full.Id, full.Name, true, true, true);
                }},
            ],
        };

        //initial
        _me.mUserRole = new EditMany('Id');
        _crud.init(config, [null, _me.mUserRole]);

        _me.mUserRole.fnLoadJson = _me.mUserRole_loadJson;
        _me.mUserRole.fnGetUpdJson = _me.mUserRole_getUpdJson;

        _me.divRoles = $('#divRoles');
        _me.mUserRoleFids = ['Id', 'RoleId']; //key fid, child fid
    },

    //load json
    mUserRole_loadJson: function (json) {
        _me.mUserRole.urmLoadJson(json, _me.divRoles, _me.mUserRoleFids);
    },

    //getUpdJson
    mUserRole_getUpdJson: function (upKey) {
        return _me.mUserRole.urmGetUpdJson(upKey, _me.divRoles, _me.mUserRoleFids);
    },

}; //class