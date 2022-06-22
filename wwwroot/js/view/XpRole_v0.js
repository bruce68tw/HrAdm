var _me = {

    init: function () {        
        //datatable config
        var config = {
            columns: [
                { data: 'Name' },
                { data: '_Fun' },
            ],
            columnDefs: [
				{ targets: [1], render: function (data, type, full, meta) {
                    return _crudR.dtCrudFun(full.Id, full.Name, true, true, true);
                }},
            ],
        };

        //initial
        _me.mUserRole = new EditMany('Id');
        _me.mRoleProg = new EditMany('Id', 'eformRoleProg', 'tplRoleProg', 'tr');
        _crudR.init(config, [null, _me.mUserRole, _me.mRoleProg]);

        _me.mUserRole.fnLoadJson = _me.mUserRole_loadJson;
        _me.mUserRole.fnGetUpdJson = _me.mUserRole_getUpdJson;

        _me.divUsers = $('#divUsers');
        _me.mUserRoleFids = ['Id', 'UserId']; //key fid, child fid
    },

    //load json
    mUserRole_loadJson: function (json) {
        _me.mUserRole.urmLoadJson(json, _me.divUsers, _me.mUserRoleFids);
    },

    //getUpdJson
    mUserRole_getUpdJson: function (upKey) {
        return _me.mUserRole.urmGetUpdJson(upKey, _me.divUsers, _me.mUserRoleFids);
    },

}; //class