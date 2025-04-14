
//靜態類別 for FlowBase.js only
var _flow = {

	//靜態屬性 node type enum
	TypeStart: 'S',
	TypeEnd: 'E',
	TypeNode: 'N',
	//TypeAuto: 'A',	//auto
};

/**
 * 自定函數:
 * void fnMoveNode(node, x, y): after move node to (x,y)
 * void fnAddLine(startNodeId, endNodeId): when add line
 * void fnDropLineEnd(oldNode, newNode): after drop line end point
 */
//控制 FlowNode、FlowLine for 外部程式
function FlowBase(boxId) {	

	/**
	 屬性:
	 boxElm: box element
	 svg: svg
	 nodes: nodes
	 lines: lines
	 startNode: start node
	 onMoveNode: event onMoveNode(node)
	*/

	this._init = function (boxId) {
		this.boxElm = document.getElementById(boxId);
		this.svg = SVG().addTo(this.boxElm).size('100%', '100%');

		this.fnMoveNode = null;
		this.fnAddLine = null;
		this.fnShowMenu = null;
		//this.onMoveNode = onMoveNode;
		//this._reset();
	};

	//清除全部UI元件
	this._reset = function () {
		this.nodes = [];
		this.lines = [];
		this.startNode = null;

		//刪除 svg 裡面的全部子元素
		Array.from(this.svg.node.childNodes).forEach(node => {
			node.remove();
		});
	};

	//載入nodes & lines
	this.loadNodes = function (rows) {
		this._reset();
		for (var i = 0; i < rows.length; i++)
			this.addNode(rows[i]);
	};

	this.loadLines = function (rows) {
		for (var i = 0; i < rows.length; i++)
			this.addLine(rows[i]);
	};

	this.addNode = function (json) {
		//this.nodeCount++;
		//if (json.id == null)
		//	json.id = (this.nodes.length + 1) * (-1);
		let node = new FlowNode(this, json);
		this.nodes.push(node);
		return node;
	};
	
	//addLine(startNode, endNode, id, lineType) {
	this.addLine = function (json) {
		//this.lineCount++;
		//if (id == null)
		//	id = (this.lines.length + 1) * (-1);
		let startNode = this.findNode(json.StartNode);
		let endNode = this.findNode(json.EndNode);
		return new FlowLine(this, startNode, endNode, json.Id, 'A');
	};
	
	this.drawLineStart = function (startNode) {
		this.startNode = startNode;
	};

	//return new line
	this.drawLineEnd = function (endNode) {
		var line = new FlowLine(this, this.startNode, endNode);
		this.startNode = null;
		return line;
	};
	
	this.findNode = function (id) {
		//elm.node 指向dom
		return this.nodes.find(node => node.getId() == id);
	};

	//call last
	this._init(boxId);

} //class FlowBase

/**
 * 流程節點
 * param flowBase {object} FlowBase
 * param json {json} 流程節點資料
 */ 
function FlowNode(flowBase, json) {
	/**
	 屬性:
	 self: this
	 flowBase: FlowBase object
	 svg: svg
	 json: node json, 欄位與後端XgFlowE相同: Id, FlowId, NodeType, Name, PosX, PosY, Width, Height
	 elm: svg group element(與 html element不同)
	 boxElm: border element
	 textElm: text element
	 lines: 進入/離開此節點的流程線
	 width: width
	 height: height
	*/

	//drag evnet
	this.DragStart = 'dragstart';
	this.DragMove = 'dragmove';
	this.DragEnd = 'dragend';

	//start/end node radius
	this.MinRadius = 20;

	//normal node size
	this.MinWidth = 100;
	this.MinHeight = 50;
	this.Padding = 15;

	this._init = function (flowBase, json) {
		this.self = this;
		this.flowBase = flowBase;
		this.svg = flowBase.svg;
		this.json = Object.assign({
			Name: 'Node',
			NodeType: _flow.TypeNode,
			PosX: 50,
			PosY: 50,
			Width: 100,	//??
			Height: 50,	//??
		}, json);

		//set instance variables
		this.lines = [];

		this._render();		//draw node first
		//this._setNodeDrag();	//set node draggable
		//this._setEventJoint();   //讓connector可拖拉
	};

	//繪製完整節點, called by initial
	this._render = function () {
        let nodeType = this.json.NodeType;
        let cssClass = '';
        let nodeName = '';

		// 建立一個 group(有x,y, 沒有大小, 含文字的節點框線), 才能控制文字拖拉
		this.elm = this.svg.group();

		let startEnd = this._isStartEnd();
		if (startEnd) {
            if (nodeType == _flow.TypeStart) {
                cssClass = 'xf-start';
				nodeName = _flow.TypeStart;
            } else {
                cssClass = 'xf-end';
				nodeName = _flow.TypeEnd;
            }

			//circle大小不填, 由css設定, 這時radius還沒確定, 不能move(因為會用到radius)
			this.boxElm = this.elm.circle()
                .addClass(cssClass);
				
			//移動circle時會參考radius, 所以先更新, 從css讀取radius, 而不是從circle建立的屬性 !!
			let style = window.getComputedStyle(this.boxElm.node);	//不能直接讀取circle屬性
            let radius = parseFloat(style.getPropertyValue("r"));	//轉浮點
			this.boxElm.attr("r", radius);
			
			let width = radius * 2;
            this.width = width;		//寫入width, 供後面計算位置
            this.height = width;	//畫流程線時會用到
		} else {
            nodeName = this.json.Name;
            cssClass = 'xf-node';
			this.boxElm = this.elm.rect()
				.addClass(cssClass);
				//.move(this.json.PosX, this.json.PosY);
        }

		this.elm.move(this.json.PosX, this.json.PosY);

		//set data-id = node id
		this._setId(this.json.Id);

		//add 節點文字
		this.textElm = this.elm.text(nodeName)
			.addClass(cssClass + '-text')
			.font({ anchor: 'middle' });

		this._setSize(startEnd);

		//add 連接點 connector(在文字右側), 小方塊, data-nodeElm 記錄節點元素
		if (nodeType != _flow.TypeEnd){
			this.pointElm = this.elm.rect(12, 12).addClass('xf-point');
			this.pointElm.node.dataset.nodeElm = this.elm;
		}
		
		this._setChildPos(startEnd);
		this._setEvent();
	};

	//是否為起迄節點
	this._isStartEnd = function () {
		return (this.json.NodeType == _flow.TypeStart || this.json.NodeType == _flow.TypeEnd);
	};

	//設定長寬
	this._setSize = function (startEnd) {
		if (!startEnd) {
			let bbox = this.textElm.bbox();
			this.width = Math.max(this.MinWidth, bbox.width + this.Padding * 2);
			this.height = Math.max(this.MinHeight, bbox.height + this.Padding * 2);
		}
		this.boxElm.size(this.width, this.height);
	};

	this.nodeType = function () {
		return this.json.NodeType;
	};

	this.getPos = function () {
		let elm = this.elm;
		return { x: elm.x(), y: elm.y() };
	};

	this.getSize = function () {
		let elm = this.boxElm;
		return { w: elm.width(), h: elm.height() };
	};

	this.getCenter = function () {
		let elm = this.boxElm;
		return { x: elm.cx(), y: elm.cy() };
	};

	//設定子元素位置
	//param startEnd: 如果不是起迄節點要考慮最小寬高
	this._setChildPos = function (startEnd) {
		//文字
		let bbox = this.textElm.bbox();
		//let centerX = this.elm.x() + this.width / 2;
		//let centerY = this.elm.y() + this.height / 2;
		//var box = this.boxElm;
		//let centerX = box.cx();
		//let centerY = box.cy();
		let center = this.getCenter();
		let size = this.getSize();
		//let centerY = box.cy();
        //this.textElm.move(centerX - bbox.width / 2, centerY - bbox.height / 2);
		//this.textElm.move(bbox.width / 2, bbox.height / 2)
		//	.center(centerX, centerY);
		this.textElm.move(size.w / 2, size.h / 2).center(center.x, center.y);

        //連接點
		if (this.pointElm)
			this.pointElm.move(center.x + bbox.width / 2 + 3, center.y - 5);
	};

	this._setEvent = function () {
		//enable right click menu
		var me = this;	//FlowNode
		this.elm.node.addEventListener('contextmenu', function (event) {
			event.preventDefault(); // 阻止瀏覽器的右鍵功能表
			var flowBase = me.flowBase;
			if (flowBase.fnShowMenu)
				flowBase.fnShowMenu(true, me.getId(), event.pageX, event.pageY);
		});

		//set node draggable, drag/drop 為 boxElm, 不是 elm(group) !!
		this.elm.draggable().on(this.DragMove, () => {
			this._setChildPos(this._isStartEnd());
			this.lines.forEach(line => line.render());
		}).on(this.DragEnd, (event) => {
			let { x, y } = event.detail.box;
			//console.log(`x=${x}, y=${y}`);

			//trigger event
			if (this.flowBase.fnMoveNode)
				this.flowBase.fnMoveNode(this.getId(), x, y);
		});

		//set connector draggable
		this._setEventJoint();
	};

	//set event of node connector
	//joint表示起始節點內的連接點
	this._setEventJoint = function () {
		if (!this.pointElm)
			return;
		
		let startElm, startX, startY;
		let tempLine;
		let endElm = null;

		// 啟用 pointElm 的拖拽功能, 使用箭頭函數時 this 會指向類別實例 !!, 使用 function則會指向 pointElm !!
		this.pointElm.draggable().on(this.DragStart, (event) => {
			// 初始化線條
			let { x, y } = this.pointElm.rbox(this.svg); // 使用SVG畫布的座標系
			startX = x;
			startY = y;
			startElm = this.self.elm;	//this.self指向這個FlowNode

			tempLine = this.svg.line(startX, startY, startX, startY)
				.addClass('xf-line off');
				
			this.flowBase.drawLineStart(this.self);
				
		}).on(this.DragMove, (event) => {
			//阻止 connector 移動
			event.preventDefault();
			
			// 獲取拖拽的目標座標（相對於 SVG 畫布）
			let { x, y } = event.detail.box;
			let endX = x;
			let endY = y;

			// 更新線條的終點
			tempLine.plot(startX, startY, endX, endY);

			// 檢查座標值是否有效
			if (isFinite(endX) && isFinite(endY)) {
				// 將 SVG 座標轉換為檢視座標
				let svgRect = this.svg.node.getBoundingClientRect();
				let viewPortX = endX + svgRect.x;
				let viewPortY = endY + svgRect.y;

				// 檢查是否懸停在節點上
				let overDom = document.elementsFromPoint(viewPortX, viewPortY)
					.find(elm => elm != startElm && (elm.classList.contains('xf-node') || elm.classList.contains('xf-end')));
				if (overDom) {
					let overElm = overDom.instance;	//svg element
					if (endElm !== overElm) {
						if (endElm) 
							this._markNode(endElm, false);
						endElm = overElm;
						this._markNode(endElm, true);
					}
				} else if (endElm) {
					this._markNode(endElm, false);
					endElm = null;
				}
			}
			
		}).on(this.DragEnd, (event) => {
			// 檢查座標值是否有效
			if (endElm) {
				this._markNode(endElm, false);					
				//this.flowBase.drawLineEnd(this.flowBase.findNode(endElm.node.dataset.id));
				var line = this.flowBase.drawLineEnd(this.flowBase.findNode(this._getIdByElm(endElm)));
				endElm = null;

				//trigger event
				if (this.flowBase.fnAddLine)
					this.flowBase.fnAddLine(line.startNode.getId(), line.endNode.getId());
			}
			tempLine.remove();
		});
	};

	//high light node
	this._markNode = function (elm, status){
		if (status){
			elm.node.classList.add('on');
		} else {
			elm.node.classList.remove('on');
		}
	};

	//id記錄在 boxElm !!
	this.getId = function () {
		return this._getIdByElm(this.boxElm);
	};

	//called by node DragEnd
	this._getIdByElm = function (boxElm) {
		return boxElm.node.dataset.id;
		//return boxElm.dataset.id;
	};

	//id記錄在 boxElm !!
	this._setId = function (id) {
		this.boxElm.node.dataset.id = id;
		//this.boxElm.dataset.id = id;
	};

	this.addLine = function (line) {
		this.lines.push(line);
	};

	this.deleteLine = function (line) {
		let index = this.lines.findIndex(item => item.Id == line.Id);
		this.lines.splice(index, 1);
	};

	//call last
	this._init(flowBase, json);

}//class FlowNode

//名詞使用 startNode/endNode
function FlowLine(flowBase, fromNode, toNode, lineType) {
	//Cnt:中心點, Side:節點邊界, 數值20大約1公分
	this.Max1SegDist = 6;	//2中心點的最大距離, 小於此值可建立1線段(表示在同一水平/垂直位置), 同時用於折線圓角半徑
	this.Min2NodeDist = 25;	//2節點的最小距離, 大於此值可建立line(1,3線段)
	this.Min2SegDist = 20;	//建立2線段的最小距離, 中心點和邊

	//末端箭頭
	this.ArrowLen = 10; 	//長度
	this.ArrowWidth = 5; 	//寬度	

	//line type, 起點位置
	this.TypeAuto = 'A';	//自動
	this.TypeV = 'V';	//垂直(上下)
	this.TypeH = 'H';	//水平(左右)

	/**
	 flowBase: FlowBase object
	 svg: svg
	 path: line path
	 fromNode: from node
	 toNode: to node
	 lineType: 起點位置, A(auto),U(上下),L(左右)
	 isTypeAuto:
	 isTypeV:
	 isTypeH:
	*/
	this._init = function (flowBase, fromNode, toNode, lineType) {
		this.flowBase = flowBase;
		this.svg = flowBase.svg;
		this.fromNode = fromNode;
		this.toNode = toNode;
		this.path = this.svg.path('').addClass('xf-line');
		// 透明的寬線作為觸發區域（放在下面）
		this.path2 = this.svg.path('')
			.fill('none')
			.stroke({ width: 10, color: 'transparent' }) // 注意：透明但可接收事件
			.attr({ 'pointer-events': 'stroke' });       // 只針對 stroke 有事件


		// 用來儲存箭頭的路徑
		this.arrowPath = this.svg.path('').addClass('xf-arrow');
		//this.arrowPath2 = this.svg.path('').addClass('xf-arrow');

		//add line to from/to node
		fromNode.addLine(this);
		toNode.addLine(this);
		this._setEvent();
		this._setType(lineType);
		this.render();
	};

	this._setEvent = function () {
		var me = this;	//FlowLine
		this.path2.node.addEventListener('contextmenu', function (event) {
			event.preventDefault(); // 阻止瀏覽器的右鍵功能表
			var flowBase = me.flowBase;
			if (flowBase.fnShowMenu)
				flowBase.fnShowMenu(false, 'me.getId()', event.pageX, event.pageY);
		});
	}

	this._setType = function (lineType) {
		lineType = lineType || this.TypeAuto;
		this.lineType = lineType;
		this.isTypeV = (lineType == this.TypeV);
		this.isTypeH = (lineType == this.TypeH);
		//this.isTypeAuto = (!this.isTypeV && !this.isTypeH) || (lineType == this.TypeAuto);
	};

	/**
	 * 依次考慮使用1線段、2線段、3線段
	 * public for FlowBase.js
	 */
	this.render = function () {

		//=== from Node ===
		// 位置和尺寸, x/y為左上方座標
		const fromPos = this.fromNode.getPos();
		//const fromY = this.fromNode.boxElm.y();
		const fromSize = this.fromNode.getSize();
		//const fromHeight = this.fromNode.height;
		const fromCntX = fromPos.x + fromSize.w / 2;		//中心點
		const fromCntY = fromPos.y + fromSize.h / 2;
		// 四個邊的中間點
		const fromUp = { x: fromPos.x + fromSize.w / 2, y: fromPos.y }; // 上邊中點
		const fromDown = { x: fromPos.x + fromSize.w / 2, y: fromPos.y + fromSize.h };
		const fromLeft = { x: fromPos.x, y: fromPos.y + fromSize.h / 2 };
		const fromRight = { x: fromPos.x + fromSize.w, y: fromPos.y + fromSize.h / 2 };

		//=== to Node ===
		const toPos = this.toNode.getPos();
		//const toY = this.toNode.elm.y();
		const toSize = this.toNode.getSize();
		//const toHeight = this.toNode.height;
		const toCntX = toPos.x + toSize.w / 2;
		const toCntY = toPos.y + toSize.h / 2;
		// 四個邊的中間點
		const toUp = { x: toPos.x + toSize.w / 2, y: toPos.y };
		const toDown = { x: toPos.x + toSize.w / 2, y: toPos.y + toSize.h };
		const toLeft = { x: toPos.x, y: toPos.y + toSize.h / 2 };
		const toRight = { x: toPos.x + toSize.w, y: toPos.y + toSize.h / 2 };

		// 判斷 fromNode 和 toNode 的相對位置
		const isEndRight = toCntX > fromCntX; 	// toNode 在 fromNode 的右側
		const isEndDown = toCntY > fromCntY; 	// toNode 在 fromNode 的下方

		// 是否符合垂直/水平最小距離, 字尾H/V表示距離量測方向
		const match2NodeDistH = (isEndRight ? toLeft.x - fromRight.x : fromLeft.x - toRight.x) >= this.Min2NodeDist;
		const match2NodeDistV = (isEndDown ? toUp.y - fromDown.y : fromUp.y - toDown.y) >= this.Min2NodeDist;

		// 是否符合2中心點之間最小距離 for 1線段(否則為3線段)
		const match1SegDistH = Math.abs(fromCntX - toCntX) <= this.Max1SegDist;
		const match1SegDistV = Math.abs(fromCntY - toCntY) <= this.Max1SegDist;

		// 是否符合中心點-邊線之間最小距離 for 2線段
		const match2SegDistIn = Math.abs(fromCntX - toCntX) - toSize.w / 2 >= this.Min2SegDist;
		const match2SegDistOut = Math.abs(fromCntY - toCntY) - fromSize.h / 2 >= this.Min2SegDist;

		//判斷線段數目(1,2,3), 有4個象限, 先考慮上下再左右
		let fromPnt, toPnt;
		let points;
		//let pathStr;
		if (!this.isTypeH && match1SegDistH && match2NodeDistV) {
			//1線段-垂直
			if (isEndDown) {
				fromPnt = fromDown;
				toPnt = toUp;
			} else {
				fromPnt = fromUp;
				toPnt = toDown;
			}
			//pathStr = `M ${fromPnt.x} ${fromPnt.y} V ${toPnt.y}`;	//取垂直線
			points = [fromPnt, { x: fromPnt.x, y: toPnt.y }];
		} else if (!this.isTypeV && match1SegDistV && match2NodeDistH) {
			//1線段-水平
			if (isEndRight) {
				fromPnt = fromRight;
				toPnt = toLeft;
			} else {
				fromPnt = fromLeft;
				toPnt = toRight;
			}
			//pathStr = `M ${fromPnt.x} ${fromPnt.y} H ${toPnt.x}`;	//取水平線
			points = [fromPnt, { x: toPnt.x, y: fromPnt.y }];
		} else if (!this.isTypeV && match2NodeDistH && match2SegDistOut) {
			//2線段-水平
			fromPnt = isEndRight ? fromRight : fromLeft;
			toPnt = isEndDown ? toUp : toDown;
			//pathStr = `M ${fromPnt.x} ${fromPnt.y} H ${toPnt.x} V ${toPnt.y}`;
			points = [fromPnt, { x: toPnt.x, y: fromPnt.y }, toPnt];
		} else if (!this.isTypeH && match2NodeDistV && match2SegDistIn) {
			//2線段-垂直
			fromPnt = isEndDown ? fromDown : fromUp;
			toPnt = isEndRight ? toLeft : toRight;
			//pathStr = `M ${fromPnt.x} ${fromPnt.y} V ${toPnt.y} H ${toPnt.x}`;
			points = [fromPnt, { x: fromPnt.x, y: toPnt.y }, toPnt];
		} else if (!this.isTypeH && match2NodeDistV) {
			//3線段-垂直(2節點內側)
			if (isEndDown) {
				fromPnt = fromDown;
				toPnt = toUp;
			} else {
				fromPnt = fromUp;
				toPnt = toDown;
			}

			let midY = (fromPnt.y + toPnt.y) / 2;
			//pathStr = `M ${fromPnt.x} ${fromPnt.y} V ${midY} H ${toPnt.x} V ${toPnt.y}`;
			points = [fromPnt, { x: fromPnt.x, y: midY }, { x: toPnt.x, y: midY }, toPnt];
		} else if (!this.isTypeV && match2NodeDistH) {
			//3線段-水平(2節點內側)
			if (isEndRight) {
				fromPnt = fromRight;
				toPnt = toLeft;
			} else {
				fromPnt = fromLeft;
				toPnt = toRight;
			}

			let midX = (fromPnt.x + toPnt.x) / 2;
			//pathStr = `M ${fromPnt.x} ${fromPnt.y} H ${midX} V ${toPnt.y} H ${toPnt.x}`;
			points = [fromPnt, { x: midX, y: fromPnt.y }, { x: midX, y: toPnt.y }, toPnt];
		} else if (!this.isTypeV) {
			//3線段-水平(2節點外側)
			if (isEndRight) {
				fromPnt = fromRight;
				toPnt = toRight;
			} else {
				fromPnt = fromLeft;
				toPnt = toLeft;
			}
			let midX = isEndRight ? Math.max(fromPnt.x, toPnt.x) + this.Min2NodeDist : Math.min(fromPnt.x, toPnt.x) - this.MinSideSide;
			//pathStr = `M ${fromPnt.x} ${fromPnt.y} H ${midX} V ${toPnt.y} H ${toPnt.x}`;
			points = [fromPnt, { x: midX, y: fromPnt.y }, { x: midX, y: toPnt.y }, toPnt];
		} else {
			//其他狀況: 用直線(非折線)連接起迄點
			if (isEndDown) {
				if (isEndRight) {
					fromPnt = !this.isTypeH ? fromDown : fromRight;
					toPnt = toLeft;
				} else {
					fromPnt = !this.isTypeH ? fromDown : fromLeft;
					toPnt = toRight;
				}
			} else {
				if (isEndRight) {
					fromPnt = !this.isTypeH ? fromUp : fromRight;
					toPnt = toLeft;
				} else {
					fromPnt = !this.isTypeH ? fromUp : fromLeft;
					toPnt = toRight;
				}
			}
			//pathStr = `M ${fromPnt.x} ${fromPnt.y} L ${toPnt.x} ${toPnt.y}`;
			points = [fromPnt, toPnt];
		}

		// 繪製流程線
		this._drawLine(points);
		//this.path.plot(pathStr);
	};

	/**
	 * 繪製流程線部分
	 */
	this._drawLine = function (points) {
		// 生成帶有圓角的折線路徑
		let pathStr = `M ${points[0].x} ${points[0].y}`; // 移動到起點
		let pntLen = points.length;
		let radius = this.Max1SegDist;
		for (let i = 1; i < pntLen; i++) {
			const prevPnt = points[i - 1];
			const nowPnt = points[i];

			// 計算圓角的路徑
			if (i < pntLen - 1) {
				const nextPnt = points[i + 1];

				// 計算圓角的起始點和結束點
				const fromAngle = Math.atan2(nowPnt.y - prevPnt.y, nowPnt.x - prevPnt.x);
				const toAngle = Math.atan2(nextPnt.y - nowPnt.y, nextPnt.x - nowPnt.x);

				const fromOffsetX = radius * Math.cos(fromAngle);
				const fromOffsetY = radius * Math.sin(fromAngle);
				const toOffsetX = radius * Math.cos(toAngle);
				const toOffsetY = radius * Math.sin(toAngle);

				const arcStartX = nowPnt.x - fromOffsetX;
				const arcStartY = nowPnt.y - fromOffsetY;
				const arcEndX = nowPnt.x + toOffsetX;
				const arcEndY = nowPnt.y + toOffsetY;

				// 添加直線到圓角的起始點
				pathStr += ` L ${arcStartX} ${arcStartY}`;

				// 判斷圓弧的方向（順時針或逆時針）
				const angleDiff = toAngle - fromAngle;
				const sweepFlag = angleDiff > 0 ? 1 : 0; // 根據角度差決定 sweep-flag

				// 添加圓角（A 指令）
				pathStr += ` A ${radius} ${radius} 0 0 ${sweepFlag} ${arcEndX} ${arcEndY}`;
			} else {
				// 最後一段直線
				pathStr += ` L ${nowPnt.x} ${nowPnt.y}`;
			}
		}

		// 繪製流程線
		this.path.plot(pathStr);
		this.path2.plot(pathStr);

		//畫末端箭頭
		this._drawArrow(points[pntLen - 2], points[pntLen - 1]);
		/*
		// 繪製帶有圓角的折線
		const path = svg.path(pathStr)
		  .stroke({ width: 2, color: '#000', linecap: 'round', linejoin: 'round' })
		  .fill('none');
		*/

	};

	/**
	 * 繪製末端箭頭部分, 利用2個傳入端點計算斜率
	 */
	this._drawArrow = function (fromPnt, toPnt) {
		// 計算箭頭的方向
		const angle = Math.atan2(toPnt.y - fromPnt.y, toPnt.x - fromPnt.x); // 計算角度

		// 計算箭頭的2個點
		const arrowPnt1 = {
			x: toPnt.x - this.ArrowLen * Math.cos(angle) + this.ArrowWidth * Math.cos(angle - Math.PI / 2),
			y: toPnt.y - this.ArrowLen * Math.sin(angle) + this.ArrowWidth * Math.sin(angle - Math.PI / 2)
		};
		const arrowPnt2 = {
			x: toPnt.x - this.ArrowLen * Math.cos(angle) + this.ArrowWidth * Math.cos(angle + Math.PI / 2),
			y: toPnt.y - this.ArrowLen * Math.sin(angle) + this.ArrowWidth * Math.sin(angle + Math.PI / 2)
		};

		// 更新箭頭路徑
		this.arrowPath.plot(`M ${toPnt.x} ${toPnt.y} L ${arrowPnt1.x} ${arrowPnt1.y} M ${toPnt.x} ${toPnt.y} L ${arrowPnt2.x} ${arrowPnt2.y}`);
		//this.arrowPath1.plot(`M ${fromPnt.x} ${fromPnt.y} L ${toPnt.x} ${toPnt.y} M ${toPnt.x} ${toPnt.y} L ${arrowPnt1.x} ${arrowPnt1.y} M ${toPnt.x} ${toPnt.y} L ${arrowPnt2.x} ${arrowPnt2.y}`);
	};

	//call last
	this._init(flowBase, fromNode, toNode, lineType);

}//class FlowLine
