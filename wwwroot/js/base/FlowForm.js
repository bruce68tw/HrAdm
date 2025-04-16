﻿/**
 * 處理 flow UI 元素和資料(mNode, mLine)之間的轉換
 * workflow component
 * param boxId {string} edit canvas id
 * param mNode {EditMany}
 * param mLine {EditMany}
 * return {FlowForm}
 */ 
function FlowForm(boxId, mNode, mLine) {

    //是否可編輯
    this.isEdit = false;

    /**
     * initial flow
     */ 
    this._init = function () {
        //#region constant
        //node types
        //this.StartNode = 'S';
        //this.EndNode = 'E';
        //this.NormalNode = 'N';
        //this.AutoNode = 'A';

        //and/or seperator for line condition
        //js only replace first found, so use regular, value is same to code.type=AndOr
        this.OrSep = '{O}';  
        this.AndSep = '{A}';
        this.ColSep = ',';

        //html filter/class
        //this.NodeFilter = '.xf-node';   //for find node object
        this.MenuFilter = '.xf-menu';   //menu for node/line property
        //this.EpFilter = '.xf-ep';       //??node end point
        this.StartNodeFilter = '.xf-start';    //start node class
        //this.EndNodeCls = 'xf-end';        //??end node class
        //this.AutoNodeCls = 'xf-auto-node';      //auto node class

        //connection(line) style: start, agree, disagree
        this.InitLineCfg = { stroke: 'blue', strokeWidth: 2 };  //??initial
        //this.OkLineCfg = { stroke: 'green', strokeWidth: 2 };   //??ok
        //this.DenyLineCfg = { stroke: 'red', strokeWidth: 2 };   //??deny(reject)

		/*
        //??start node config
        this.StartNodeCfg = {
            filter: this.EpFilter,
            //anchor: 'Continuous',
            anchor: ['Bottom', 'Left', 'Right'],
            //outlineWidth not work !!
            connectorStyle: {
                stroke: '#5c96bc',
                strokeWidth: 2,
                outlineStroke: 'transparent',
                outlineWidth: 3,
            },
            connectionType: 'basic',
            extract: {
                'action': 'the-action'
            },
            maxConnections: 10,
        };

        //??end node config
        this.EndNodeCfg = {
            dropOptions: { hoverClass: 'dragHover' },
            //anchor: 'Continuous',
            anchor: ['Top', 'Bottom', 'Left', 'Right'],
            allowLoopback: true,
        };
		*/
        //#endregion

        //#region variables
        //editMany
        this.mNode = mNode;
        this.mLine = mLine;

        //this.popupMenu = $('.xf-menu');
        //this.divFlowBox = $('#' + boxId);	//??
        this.divLinesBox = $('#divLinesBox');       //??hidden
        this.tbodyLineCond = $('#tbodyLineCond');     //modalLineProp tbody for line conds
        this.eformNode = $('#eformNode');           //nodes edit form for editMany
        this.eformLine = $('#eformLine');           //lines edit form for editMany
        this.modalNodeProp = $('#modalNodeProp');
        this.modalLineProp = $('#modalLineProp');

        //node/line template        
        this.tplNode = $('#tplNode').html();
        this.tplLine = $('#tplLine').html();
        this.tplLineCond = $('#tplLineCond').html();

        //now selected type & element
        this.nowIsNode = false;     //true:node, false:line
        this.nowFlowItem = null;    //now selected FlowNode/FlowLine
        //#endregion

        //for FlowLine, 對應 XpCode.Type=LineOp, 數對內容為:儲存值/顯示文字(label)
        var condOpMaps = [
            this.OrSep, ') || (',  	//or, 會自動加上外括號
            this.AndSep, ' && ',    //and
            ',EQ,', '=',
            ',NEQ,', '!=',
            ',GT,', '>',
            ',GE,', '>=',
            ',ST,', '<',
            ',SE,', '<=',
        ];
        this.condOpExprs = [];   //condition op regular expression
        this.condOpShows = [];   //condition op show text
        var j = 0;
        for (var i = 0; i < condOpMaps.length; i = i + 2) {
            this.condOpExprs[j] = new RegExp(condOpMaps[i], 'g');	//for find/replace
            this.condOpShows[j] = condOpMaps[i + 1];
            j++;
        }

        //set instance first
        //this.flowBase = new FlowBase(boxId, (nodeId, x, y) => this.onMoveNode(nodeId, x, y));
        var flowBase = new FlowBase(boxId);
        flowBase.fnMoveNode = (node, x, y) => this.onMoveNode(node, x, y);
        flowBase.fnAddLine = (startNode, endNode) => this.onAddLine(startNode, endNode);
        flowBase.fnShowMenu = (isNode, flowItem, event) => this.onShowMenu(isNode, flowItem, event);
        this.flowBase = flowBase;

        //set event
        this._setFlowEvent();
    };

    this.onMoveNode = function (node, x, y) {
        var rowBox = this.mNode.idToRowBox(node.getId());
        _form.loadRow(rowBox, { PosX: Math.floor(x), PosY: Math.floor(y) });    //座標取整數
    };

    this.onAddLine = function (startNode, endNode) {
        alert('onAddLine');
    };

    /**
     * on show right menu
     * param isNode {bool} 
     * param elm {FlowNode/FlowLine} 
     * param mouseX {int} 
     * param mouseY {int} 
     */
    this.onShowMenu = function (isNode, flowItem, event) {
        //set instance variables
        this.nowIsNode = isNode;
        this.nowFlowItem = flowItem;

        //set edit status
        var canEdit = isNode
            ? (this.isEdit && flowItem.getNodeType() == _flow.TypeNormal)
            : this.isEdit;

        var menu = $(this.MenuFilter);
        if (canEdit) {
            menu.find('.xd-edit').removeClass('disabled');
            menu.find('.xd-delete').removeClass('disabled');
        } else {
            menu.find('.xd-edit').addClass('disabled');
            menu.find('.xd-delete').addClass('disabled');
        }

        // Show contextmenu
        menu.finish()
            .toggle(100)
            .css({
                position: 'fixed',  //使用 fixed 定位
                left: event.clientX + 'px',
                top: event.clientY + 'px',
            });
    };

	//set editable or not
    this.setEdit = function (status) {
        this.isEdit = status;
        this.flowBase.setEdit(status);
    };

    /**
     * set flow events:
     *   1.line right click to show context menu
     *   2.mouse down to hide context menu
     */
    this._setFlowEvent = function () {
        var flowBase = this.flowBase;
        var me = this;

        // bind a click listener to each connection; the connection is deleted. you could of course
        // just do this: jsPlumb.bind('click', jsPlumb.detach), but I wanted to make it clear what was
        // happening.
        //(定義)Notification a Connection was clicked.
        /*
        flowBase.bind('click', function (c) {
            //this.showNodeProp();
            this.modalNodeProp.modal('show');
        });
        */

        /* todo: temp remark
        //line(connection) show context menu
        flowBase.bind('contextmenu', function (elm, event) {
            //"this" not work here !!
            me.showPopupMenu(elm, event, false);
        });
        */

        /*
        //event: before build connection
        //info: connection        
        //flowBase.bind('connection', function (info) {
        flowBase.bind('beforeDrop', function (info) {
            //if (this.loading)
            //    return true;

            //if connection existed, return false for stop 
            //info.source did not work here !!
            var conn = info.connection;
            if (flowBase.getConnections({ source: conn.source, target: conn.target }).length > 0)
                return false;

            //get source node & type
            var prop = me.getLineProp('');

            //set conn style & label
            conn.setPaintStyle(prop.style);    //real connection
            me._setLineLabel(conn, prop.label);

            //add parameters(line model) into connection
            var row = {
                StartNode: me._elmToNodeValue(conn.source, 'Id'),
                EndNode: me._elmToNodeValue(conn.target, 'Id'),
                CondStr: '',
                Sort: 9,
            };
            me._setLineKey(conn, me.addLine(row));

            return true;
        });
        */

        //hide context menu (jsPlumb no mousedown event !!)
        $(document).bind('mousedown', function (e) {
            //if (_obj.isShow(me.popupMenu))
            //    me.popupMenu.hide(100);
            
            //"this" is not work here !!
            var filter = me.MenuFilter;
            if (!$(e.target).parents(filter).length > 0)
                $(filter).hide(100);
            
        });
    };

    /**
     * load nodes into UI
     * param rows {json} 後端傳回的完整json
     */
    this.loadNodes = function (rows) {
        //EditMany load rows by rowsBox
        this.mNode.loadRowsByRsb(rows, true);
		
		//flow loadNodes
        this.flowBase.loadNodes(rows);
    };

    /**
     * load nodes into UI(hide)
     * param rows {rows} line rows
     */
    this.loadLines = function (rows) {
        this.mLine.loadRowsByRsb(rows, true);
        this.flowBase.loadLines(rows);
    };

    //#region node function

    //add new node
    this.addNode = function (name, nodeType) {
        //json row initial value
        var json = {
            Name: name,
            NodeType: nodeType,
            PosX: 100,
            PosY: 100,
        };

		//mNode新筆一筆資料, 會產生新id
        var row = this.mNode.addRow(this._setNodeClass(json));
		
		//flow add node
		this.flowBase.addNode(row);
        //this._setNodeEvent(node);   //set node event
    };

    /**
     * node id to node object
    this._idToNode = function (id) {
        return this.divFlowBox.find('.xf-node [value=' + id + ']').closest('.xf-node');
    };
     */

    /**
     * inside element to node object
    this._elmToNode = function (elm) {
        return $(elm).closest(this.NodeFilter);
    };
    this._elmToNodeValue = function (elm, fid) {
        var node = this._elmToNode(elm);
        return this._boxGetValue(node, fid);
    };
     */

    /**
     * node get field value
     * param node {object} node object
     * param fid {string} field id
     * return {string}
     */ 
    this._boxGetValue = function (node, fid) {
        return _itext.get(fid, node);
    };

    /**
     * node get field values
     * param node {object} node object
     * param fids {strings} field id array
     * return {json}
     */ 
    this._boxGetValues = function (node, fids) {
        var json = {};
        for (var i = 0; i < fids.length; i++) {
            var fid = fids[i];
            json[fid] = _itext.get(fid, node);
        }
        return json;
    };

    this.deleteNode = function (nodeElm) {
        //delete from & to lines
        var flowBase = this.flowBase;
        this.deleteLines(flowBase.getConnections({ source: nodeElm }));
        this.deleteLines(flowBase.getConnections({ target: nodeElm }));

        //add deleted row of node
        var node = $(nodeElm);
        this.mNode.deleteRow(this._getObjKey(node));

        //delete node 
        $(nodeElm).remove();
    };
    //#endregion (node function)

    //#region line function
    /**
     * ?? add one line(connector)
     * param row {json} line row
     * return void
    this._renderLine = function (row) {

        //param 2(reference object) not work here !!
        var prop = this.getLineProp(row.CondStr);    //get line style & label
        //debugger;
        var conn = this.flowBase.connect({
            //type: 'basic',
            source: this._idToNode(row.StartNode),
            target: this._idToNode(row.EndNode),
            paintStyle: prop.style,
            //anchors: ["Right", "Left"],
        });

        //add custom attributes: whole line model(big camel), only this way workable !!
        //this.connSetParas(conn, row, isNew); 
        this._setLineKey(conn, row.Id);

        //set label
        this._setLineLabel(conn, prop.label);
    };
     */ 

    /**
     * add flow line into hide UI for crud
     * param row {json}
     * return {string} line key
    this.addLine = function (row) {
        var newLine = $(this.tplLine);      //create row object, no need mustache()
        _form.loadRow(newLine, row);        //row objec to UI
        var key = this.mLine.setNewIdByBox(newLine);   //set new key
        this.divLinesBox.append(newLine);   //append row object
        return key;
    };
     */

    /**
     * set connection key
     */ 
    this._setLineKey = function (conn, key) {
        var row = {};
        row['Id'] = key;
        conn.setParameters(row);
    };

    //is line source node a condition mode(true) or yes/no type(false)
    this._isSourceCondMode = function (sourceType) {
        //return (sourceType == this.StartNode || sourceType == this.AutoNode);
        return (sourceType == this.StartNode);
    };

    /**
     * get line property: style, label
     * return {json} 
     */ 
    this.getLineProp = function (condStr) {
        return {
            //type: type,
            style: this.InitLineCfg,
            label: this._condStrToLabel(condStr),
        }
    };

    this._getLineElmKey = function (conn) {
        return conn.getParameters()['Id'];
    };

    /**
     * get object(node/line) key
     * param obj {object}
     * return {string} key value
     */
    this._getObjKey = function (obj) {
        return _itext.get('Id', obj);
    };

    //set connection label
    this._setLineLabel = function (conn, label) {
        var obj = conn.getOverlay('label');
        obj.setVisible(_str.notEmpty(label));
        obj.setLabel(label);
        //conn.getOverlay('label').setLabel(label);
    };

    //delete line with warning msg
    this.deleteLineWithMsg = function (conn) {
        _tool.ans('delete this line ?', function () {
            this.deleteLine(conn);
        });
    };
    //delete line without warning msg
    this.deleteLine = function (conn) {
        //add deleted row
        var json = conn.getParameters();    //model
        this.mLine.deleteRow(json.Id);

        //delete conn
        this.flowBase.deleteConnection(conn);
    };
    this.deleteLines = function (conns) {
        for (var i = 0; i < conns.length; i++) {
            this.deleteLine(conns[i]);
        }
    };
    //#endregion (line function)

    //convert condiction string to label string
    this._condStrToLabel = function (str) {
        if (_str.isEmpty(str))
            return '';

        var hasOr = str.indexOf(this.OrSep) > 0;
        for (var i = 0; i < this.condOpExprs.length; i++)
            str = str.replace(this.condOpExprs[i], this.condOpShows[i]);
        if (hasOr)
            str = '(' + str + ')';
        return str;
    };

    //convert condStr to List<Cond>
    this._condStrToList = function (str) {
        if (_str.isEmpty(str))
            return null;

        var list = [];
        var k = 0;
        var orList = str.split(this.OrSep);
        var orLen = orList.length;
        var hasOr = (orLen > 1);
        for (var i = 0; i < orLen; i++) {
            var andList = orList[i].split(this.AndSep);
            for (var j = 0; j < andList.length; j++) {
                var cols = andList[j].split(this.ColSep);
                list[k] = {
                    //AndOr: hasOr ? 'O' : 'A',
                    AndOr: hasOr ? this.OrSep : this.AndSep,
                    Fid: cols[0],
                    Op: cols[1],
                    Value: cols[2],
                };
                k++;
            }
        }
        return list;
    };

    //get line condition string
    this._getLineLabel = function () {
        var me = this;
        var condStr = '';
        this.tbodyLineCond.find('tr').each(function (idx) {
            var tr = $(this);
            var str = (idx == 0 ? '' : _iselect.get('AndOr', tr)) +
                _itext.get('Fid', tr) + me.ColSep +
                _iselect.get('Op', tr) + me.ColSep +
                _itext.get('Value', tr);
            condStr += str;
        });
        return condStr;
    };

    this.showNodeProp = function (nodeType) {
        var node = this._elmToNode(this.nowFlowItem);
        var row = this._boxGetValues(node, ['NodeType', 'Name', 'SignerType', 'SignerValue']);
        _form.loadRow(this.modalNodeProp, row);

        //show modal
        _modal.showO(this.modalNodeProp);   //.modal('show');
    };

    //param line {FlowLine} flow line 
    this.showLineProp = function (line) {
        //debugger;
        var form = this.modalLineProp.find('form');
        //var line = conn.getParameters();   //line model
        //var line = this._connToLine(conn);
        //var lineType = line.LineType;

		var id = line.getId();
		var rowBox = this.mLine.idToRowBox(id);
		
        //show fields
        //_iradio.set('LineType', lineType, form);
        //this.onChangeLineType(lineType); //switch input
        _iread.set('FromNodeName', line.fromNode.getValue('Name'), form);
        _iread.set('ToNodeName', line.toNode.getValue('Name'), form);
        _iselect.set('FromType', line.getValue('FromType'), form);
        _itext.set('Sort', _itext.get('Sort', rowBox), form);

        //show modal
        _modal.showO(this.modalLineProp);

        //if (!this.isLineCondMode(lineType))
        //    line.CondStr = '';

        //load line conditions rows
        this.tbodyLineCond.empty();
        var condList = this._condStrToList(this._boxGetValue(line, 'CondStr'));
        if (condList != null) {
            for (var i = 0; i < condList.length; i++) {
                var newCond = $(this.tplLineCond);
                _form.loadRow(newCond, condList[i]);
                this.tbodyLineCond.append(newCond);
            }
        }
    };

    //jsplumb connection to line object
    this._connToLine = function (conn) {
        return this._idToLine(this._getLineElmKey(conn));
    };

    //id to line object
    this._idToLine = function (id) {
        return this.divLinesBox.find('.xd-line [value=' + id + ']').closest('.xd-line');
    };

    this._idToLineBox = function (id) {
        return this.eformLine.find('.xd-line [value=' + id + ']').closest('.xd-line');
    };

    //#region events
    //on add start node
    this.onAddStartNode = function () {
        //check, only one start node allow
        if (this.eformNode.find(this.StartNodeFilter).length > 0) {
            //_tool.msg(this.R.StartNodeExist);
            _tool.msg('Start Node Already Existed !');
            return;
        }

        //add node
        this.addNode('Start', this.StartNode);
    };
    //on add end node
    this.onAddEndNode = function () {
        this.addNode('End', this.EndNode);
    };
    /*
    this.onAddAutoNode = function () {
        this.addNode('Auto', this.AutoNode);
    };
    */
    //on add normal node
    this.onAddNormalNode = function () {
        this.addNode('Node', this.NormalNode);
    };

    //context menu event
    this.onMenuEdit = function () {
        if (this.nowIsNode)
            this.showNodeProp(this.nowFlowItem.getNodeType());
        else
            this.showLineProp(this.nowFlowItem);
    };

    this.onMenuDelete = function () {
        var me = this;
        if (me.nowIsNode) {
            _tool.ans('delete this node ?', function () {
                me.deleteNode(me.nowFlowItem);
            });
        } else {
            _tool.ans('delete this line ?', function () {
                me.deleteLine(me.nowFlowItem);
            });
        }
    };

    //onclick add line condition
    this.onAddLineCond = function () {
        var row = {
            AndOr: this.AndSep,
            Op: 'eq',
        };
        var cond = $(Mustache.render(this.tplLineCond, row));
        _form.loadRow(cond, row);        //row objec to UI
        this.tbodyLineCond.append(cond);
    };

    this.onDeleteLineCond = function (btn) {
        $(btn).closest('tr').remove();
    };

    //node prop onclick ok
    this.onModalNodeOk = function () {
        //check input

        //hide modal
        _modal.hideO(this.modalNodeProp);

        //set new value
        var row = _form.toRow(this.eformNode);

        //update node display name
        var nodeObj = $(this.nowFlowItem);
        nodeObj.find('.xd-name').text(row.Name);

        //update node form fields
        _itext.set('Name', row.Name, nodeObj);
        _itext.set('SignerType', row.SignerType, nodeObj);
        _itext.set('SignerValue', row.SignerValue, nodeObj);

        //change node style, has xf-ep div at the end !!
        //var html = row.Name + '<div class="xf-ep" action="begin"></div>';
        //nodeObj.html(html);

        /*
        //reset auto node class
        if (row.NodeType == this.AutoNode)
            nodeObj.addClass(this.AutoNodeCls);
        else
            nodeObj.removeClass(this.AutoNodeCls);
        */
    };

    //line prop click ok
    this.onModalLineOk = function () {
        //check input
		var form = this.modalLineProp;
		
        //var lineType = _iradio.get('LineType', this.eformLine);
        //_assert.inArray(lineType, ['0','1','2']);

        //conds to string
        //var condStr = this._getLineLabel();

        //set new value
        //write into line, this.nowFlowItem is line connection
        //var form = this.eformLine;
        //var conn = this.nowFlowItem;
        //conn.setParameter('LineType', lineType);
		
		//update mLine
		var flowLine = this.nowFlowItem;
        var row = {
            CondStr: this._getLineLabel(),
            Sort: _itext.get('Sort', form),
        };
        //var line = this._connToLine(conn);
        //_form.loadRow(line, row);
		var id = flowLine.getId();
		var lineBox = this._idToLineBox(id);
        _form.loadRow(lineBox, row);
		
		//update flowLine
		flowLine.setLabel(row.CondStr);
		
        //hide modal
        _modal.hideO(form);

		/*
        //change line label
        var prop = this.getLineProp(condStr)
        this._setLineLabel(conn, prop.label);
        conn.setPaintStyle(prop.style);
		*/
    };
    //#endregion (events)

	//call last
    this._init();

}//class