var _me = {

    init: function () {        
        //datatable config
        var config = {
            dom: _crud.dtDom,
            columns: [
                { data: 'Account' },
                { data: 'Name' },
                { data: 'DeptName' },
                { data: 'Status' },
                { data: '_F1' },
                { data: '_F2' },
            ],
            columnDefs: [
                _crud.dtColConfig,
				{ targets: [3], render: function (data, type, full, meta) {
                    return _crud.dtStatusName(data);
                }},
				{ targets: [4], render: function (data, type, full, meta) {
                    var html = '<a href="javascript:_me.onGenWord(\'{0}\')">{1}</a>';
                    return _str.format(html, full.Id, "產生Word文件");
                }},
				{ targets: [5], render: function (data, type, full, meta) {
                    return _crud.dtCrudFun(full.Id, full.Name, true, false, true);
                }},
            ],
        };

        //initial
        _me.mUserJob = new EditMany('Id', 'eformUserJob', 'tplUserJob', 'tr');
        _me.mUserSchool = new EditMany('Id', 'eformUserSchool', 'tplUserSchool', 'tr');
        _me.mUserLang = new EditMany('Id', 'eformUserLang', 'tplUserLang', 'tr', 'Sort');
        _me.mUserLicense = new EditMany('Id', 'eformUserLicense', 'tplUserLicense', 'tr');
        _me.mUserSkill = new EditMany('Id', 'eformUserSkill', 'tplUserSkill', 'tr', 'Sort');
		_crud.init(config, [null, _me.mUserJob, _me.mUserSchool, _me.mUserLang, _me.mUserLicense, _me.mUserSkill]);
    },

    //TODO: add your code
    //onclick viewFile, called by XiFile component
    onViewFile: function (fid, elm) {
        if (fid == 'PhotoFile')
            _me.edit0.onViewImage('', fid, elm);
        else if (fid == 'FileName')
            _me.mUserLicense.onViewImage('', fid, elm);
    },

    //generate docx file
    onGenWord: function (id) {
        _tool.ans("是否產生Word文件?", function () {
            window.location = 'GenWord?id=' + id;
        });
    },

}; //class