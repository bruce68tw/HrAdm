//resource for js base component
var _BR = {

    //=== moment.js convert these to UI format ===
    MmUiDateFmt: 'YYYY/MM/DD',          //match bootstrap-datepicker.js format property
    MmUiDtFmt: 'YYYY/MM/DD HH:mm:ss',   //datetime 
    MmUiDt2Fmt: 'YYYY/MM/DD HH:mm',     //datetime no second

    //row status
    StatusYes: '正常',
    StatusNo: '停用',
    Yes: '是',

    //check input
    InputWrong: '輸入錯誤。',

    //for crud form
    Create: '新增',
    Update: '修改',
    View: '檢視',
    UpdateOk: '資料更新完成。',
    DeleteOk: '資料刪除完成。',
    SaveOk: '資料儲存完成。',
    SaveNone: '無任何資料異動。',
    Done: '作業完成。',

    //find form
    FindOk: '查詢完成。',
    FindNone: '找不到資料。',

    //form tip
    TipUpdate: '修改這筆資料',
    TipDelete: '刪除這筆資料',
    TipView: '檢視這筆資料',

    //message-upload file
    UploadFileNotBig: '上傳檔案不可大於{0}M !',
    UploadFileNotMatch: '上傳檔案種類不符合 !',
    NewFileNotView: '新檔案尚未上傳, 無法檢視。',

    //message-others
    PlsSelectDeleted: '請選取要刪除的資料。',
    PlsSelectRows: '請先選取資料。',
    SureDeleteRow: '是否確定刪除這筆資料?',
    SureDeleteSelected: '是否確定刪除選取的資料?',

    //authority
    NoAuthUser: '您只能存取個人資料，請聯絡管理者。',
    NoAuthDept: '您只能存取同部門資料，請聯絡管理者。',

    //others
    Working: '作業處理中...',

};
/**
 * Traditional Chinese translation for bootstrap-datepicker
 * Rung-Sheng Jang <daniel@i-trend.co.cc>
 * FrankWu  <frankwu100@gmail.com> Fix more appropriate use of Traditional Chinese habit
 */
;(function($){
	$.fn.datepicker.dates['zh-TW'] = {
		days: ["星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六"],
		daysShort: ["週日", "週一", "週二", "週三", "週四", "週五", "週六"],
		daysMin:  ["日", "一", "二", "三", "四", "五", "六"],
		months: ["一月", "二月", "三月", "四月", "五月", "六月", "七月", "八月", "九月", "十月", "十一月", "十二月"],
		monthsShort: ["1月", "2月", "3月", "4月", "5月", "6月", "7月", "8月", "9月", "10月", "11月", "12月"],
		today: "今天",
		format: "yyyy/mm/dd",
		weekStart: 1,
		clear: "清除"
	};
}(jQuery));

(function ($) {
  $.extend($.summernote.lang, {
    'zh-TW': {
      font: {
        bold: '粗體',
        italic: '斜體',
        underline: '底線',
        clear: '清除格式',
        height: '行高',
        name: '字體',
        strikethrough: '刪除線',
        subscript: '下標',
        superscript: '上標',
        size: '字號'
      },
      image: {
        image: '圖片',
        insert: '插入圖片',
        resizeFull: '縮放至100%',
        resizeHalf: '縮放至 50%',
        resizeQuarter: '縮放至 25%',
        floatLeft: '靠左浮動',
        floatRight: '靠右浮動',
        floatNone: '取消浮動',
        shapeRounded: '形狀: 圓角',
        shapeCircle: '形狀: 圓',
        shapeThumbnail: '形狀: 縮略圖',
        shapeNone: '形狀: 無',
        dragImageHere: '將圖片拖曳至此處',
        selectFromFiles: '從本機上傳',
        maximumFileSize: '文件大小最大值',
        maximumFileSizeError: '文件大小超出最大值。',
        url: '圖片網址',
        remove: '移除圖片'
      },
      video: {
        video: '影片',
        videoLink: '影片連結',
        insert: '插入影片',
        url: '影片網址',
        providers: '(優酷, Instagram, DailyMotion, Youtube等)'
      },
      link: {
        link: '連結',
        insert: '插入連結',
        unlink: '取消連結',
        edit: '編輯連結',
        textToDisplay: '顯示文字',
        url: '連結網址',
        openInNewWindow: '在新視窗開啟'
      },
      table: {
        table: '表格'
      },
      hr: {
        insert: '水平線'
      },
      style: {
        style: '樣式',
        p: '一般',
        blockquote: '引用區塊',
        pre: '程式碼區塊',
        h1: '標題 1',
        h2: '標題 2',
        h3: '標題 3',
        h4: '標題 4',
        h5: '標題 5',
        h6: '標題 6'
      },
      lists: {
        unordered: '項目清單',
        ordered: '編號清單'
      },
      options: {
        help: '幫助',
        fullscreen: '全螢幕',
        codeview: '原始碼'
      },
      paragraph: {
        paragraph: '段落',
        outdent: '取消縮排',
        indent: '增加縮排',
        left: '靠右對齊',
        center: '靠中對齊',
        right: '靠右對齊',
        justify: '左右對齊'
      },
      color: {
        recent: '字型顏色',
        more: '更多',
        background: '背景',
        foreground: '前景',
        transparent: '透明',
        setTransparent: '透明',
        reset: '重設',
        resetToDefault: '默認'
      },
      shortcut: {
        shortcuts: '快捷鍵',
        close: '關閉',
        textFormatting: '文字格式',
        action: '動作',
        paragraphFormatting: '段落格式',
        documentStyle: '文件格式',
        extraKeys: '額外按鍵'
      },
      history: {
        undo: '復原',
        redo: '取消復原'
      }
    }
  });
})(jQuery);

(function( factory ) {
	if ( typeof define === "function" && define.amd ) {
		define( ["jquery", "../jquery.validate"], factory );
	} else if (typeof module === "object" && module.exports) {
		module.exports = factory( require( "jquery" ) );
	} else {
		factory( jQuery );
	}
}(function( $ ) {

/*
 * Translated default messages for the jQuery validation plugin.
 * Locale: ZH (Chinese; 中文 (Zhōngwén), 汉语, 漢語)
 * Region: TW (Taiwan)
 */
$.extend( $.validator.messages, {
	required: "必須填寫",
	remote: "請修正此欄位",
	email: "請輸入有效的電子郵件",
	url: "請輸入有效的網址",
	date: "請輸入有效的日期",
	dateISO: "請輸入有效的日期 (YYYY-MM-DD)",
	number: "請輸入正確的數值",
	digits: "只可輸入數字",
	creditcard: "請輸入有效的信用卡號碼",
	equalTo: "請重複輸入一次",
	extension: "請輸入有效的後綴",
	maxlength: $.validator.format( "最多 {0} 個字" ),
	minlength: $.validator.format( "最少 {0} 個字" ),
	rangelength: $.validator.format( "請輸入長度為 {0} 至 {1} 之間的字串" ),
	range: $.validator.format( "請輸入 {0} 至 {1} 之間的數值" ),
	step: $.validator.format( "請輸入 {0} 的整數倍值" ),
	max: $.validator.format( "請輸入不大於 {0} 的數值" ),
	min: $.validator.format( "請輸入不小於 {0} 的數值" )
} );
return $;
}));