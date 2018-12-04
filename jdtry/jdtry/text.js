function getBtn(s_class,s_attr,s_click){
	var btn;
	var objs = document.getElementsByClassName(s_class);
	if(objs){
		for(var o in objs){
			if(objs[o].getAttribute){
				var str = objs[o].getAttribute(s_attr) + "";
				if(str.indexOf(s_click)!=-1){
					btn = objs[o];
					break;
				}
			}
		}
	}
	return btn;
}
function clickrq(){
	var btn = getBtn('y','clstag','try');
	if(btn){
		btn.click();
	}
}
function init(){
	var btn = getBtn('app-btn btn-application','clstag','try');
	if(btn){
		btn.click();
		window.setTimeout("clickrq()",1000);
	}
	window.setTimeout("init()",4000);
}
init();