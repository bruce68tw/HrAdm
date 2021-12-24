var _me = {

    init: function () {        
        //datatable config
        var config = {
            dom: _crud.dtDom,
            columns: [
                { data: 'OkCount' },
                { data: 'FailCount' },
                { data: 'TotalCount' },
                { data: 'FileName' },
                { data: 'CreatorName' },
                { data: 'Created' },
            ],
            columnDefs: [
                _crud.dtColConfig,
				{ targets: [1], render: function (data, type, full, meta) {
                    return (data > 0)
                        ? _str.format('<a href="GetFail?id={0}&name={1}">{2}</a>', full.Id, full.FileName, data)
                        : data;
                }},
				{ targets: [3], render: function (data, type, full, meta) {
                    return _str.format('<a href="GetSource?id={0}&name={1}">{2}</a>', full.Id, full.FileName, data);
                }},
				{ targets: [5], render: function (data, type, full, meta) {
                    return _date.jsToUiDt(data);
                }},
            ],
        };

        //initial
        _crud.init(config);

        _me.modalImport = $('#modalImport');
    },

    //on open import modal
    onOpenImport: function () {
        _modal.showO(_me.modalImport);
    },

    //on run import
    onImport: function () {
        var modal = _me.modalImport;
        var fileObj = modal.find(':file');
        var file = _ifile.getUploadFile(fileObj);
        if (file == null) {
            _tool.msg('請選取檔案 !!');
            return;
        }

        var formData = new FormData();
        formData.append('file', file);
        _ajax.getJsonByFormData('Import', formData, function (data) {
            _modal.hideO(modal);
            _tool.msg(_str.format('匯入完成, 成功{0}筆, 失敗{1}筆', data.OkCount, data.FailCount));
            _me.dt.reload();
        });
    },

}; //class