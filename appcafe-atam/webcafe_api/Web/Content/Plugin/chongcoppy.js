//Tắt chuột phải....
function clickIE() {
    if (document.all) {
        return false;
    }
}
function clickNS(e) {
    if (document.layers || (document.getElementById && !document.all)) {
        if (e.which == 2 || e.which == 3) {
            return false;
        }
    }
}
if (document.layers) {
    document.captureEvents(Event.MOUSEDOWN);
    document.onmousedown = clickNS;
}
else {
    document.onmouseup = clickNS;
    document.oncontextmenu = clickIE;
}
document.oncontextmenu = new Function("return false")

//khóa ctrl
function disableCtrlKeyCombination(e) {
    //list all CTRL + key combinations you want to disable
    var forbiddenKeys = new Array('a', 'n', 'c', 'x', 'v', 'j');
    var key;
    var isCtrl;

    if (window.event) {
        key = window.event.keyCode;     //IE
        if (window.event.ctrlKey)
            isCtrl = true;
        else
            isCtrl = false;
    }
    else {
        key = e.which;     //firefox
        if (e.ctrlKey)
            isCtrl = true;
        else
            isCtrl = false;
    }
    //alert(isCtrl);
    //if ctrl is pressed check if other key is in forbidenKeys array
    if (isCtrl) {
        for (i = 0; i < forbiddenKeys.length; i++) {
            //case-insensitive comparation
            if (forbiddenKeys[i].toLowerCase() == String.fromCharCode(key).toLowerCase()) {

                return false;
            }
        }
    }
    return true;
}