$(document).ready(function () {

    if ($.browser.mozilla || $.browser.webkit) {

        try {

            // showPrintButton();

        }
        catch (e) { alert(e); }
    }

});
var matched, browser;
jQuery.uaMatch = function (ua) {
    ua = ua.toLowerCase();
    var match = /(chrome)[ \/]([\w.]+)/.exec(ua) ||
        /(webkit)[ \/]([\w.]+)/.exec(ua) ||
        /(opera)(?:.*version|)[ \/]([\w.]+)/.exec(ua) ||
        /(msie) ([\w.]+)/.exec(ua) ||
        ua.indexOf("compatible") < 0 && /(mozilla)(?:.*? rv:([\w.]+)|)/.exec(ua) ||
        [];
    return {
        browser: match[1] || "",
        version: match[2] || "0"
    };
};
matched = jQuery.uaMatch(navigator.userAgent);
browser = {};
if (matched.browser) {
    browser[matched.browser] = true;
    browser.version = matched.version;
}
// Chrome is Webkit, but Webkit is also Safari.
if (browser.chrome) {
    browser.webkit = true;
} else if (browser.webkit) {
    browser.safari = true;
}
jQuery.browser = browser;

function pageLoad() {
    if ((browser.mozilla || browser.chrome) && !$("#ff_print").length) {
        try {

            var innerTbodyxx = "<input type='image' onclick='PrintReport();' title='Print' src='/Reserved.ReportViewerWebControl.axd?OpType=Resource&Version=9.0.30729.1&Name=Microsoft.Reporting.WebForms.Icons.Print.gif' alt='Print' style='border-width: 0px; padding: 3px;margin-top:2px; height:16px; width: 16px;'>";
            var ControlName = 'ReportViewerGeneral';
            var innerTable = '<table title="Print" onclick="PrintReport(\'' + ControlName + '\'); return false;" id="ff_print" style="border: 1px solid rgb(236, 233, 216); background-color: rgb(236, 233, 216); cursor: default;">' + innerTbodyxx + '</table>';
            var outerDiv = '<div style="display: inline-block; font-size: 8pt; height: 30px;" class=" "><table cellspacing="0" cellpadding="0" style="display: inline;"><tbody><tr><td height="28px">' + innerTable + '</td></tr></tbody></table></div>';
            $("#ReportViewer1_ctl05 > div").append(outerDiv);
            var element = document.getElementById("ReportViewer1_ctl09");

            if (element) {
                element.style.overflow = "visible";
            }
        }
        catch (e) { alert(e); }
    }
}

function PrintFunc() {
    var strFrameName = ("printer-" + (new Date()).getTime());
    var jFrame = $("<iframe name='" + strFrameName + "'>");
    jFrame
        .css("width", "1px")
        .css("height", "1px")
        .css("position", "absolute")
        .css("left", "-2000px")
        .appendTo($("body:first"));
    var objFrame = window.frames[strFrameName];
    var objDoc = objFrame.document;
    var jStyleDiv = $("<div>").append($("style").clone());
    objDoc.open();
    objDoc.write($("head").html());
    objDoc.write($("#VisibleReportContentReportViewer1_ctl09").html());
    objDoc.close();
    objFrame.print();
    setTimeout(function () { jFrame.remove(); }, (60 * 1000));
}
function showPrintButton() {

    var table = $("table[title='Refresh']");

    var parentTable = $(table).parents('table');

    var parentDiv = $(parentTable).parents('div').parents('div').first();

    parentDiv.append('<input type="image" style="border-width: 0px; padding: 3px;margin-top:2px; height:16px; width: 16px;" alt="Print" src="/Reserved.ReportViewerWebControl.axd?OpType=Resource&amp;Version=9.0.30729.1&amp;Name=Microsoft.Reporting.WebForms.Icons.Print.gif";title="Print" onclick="PrintReport();">');



}

// Print Report function

function PrintReport() {
    //get the ReportViewer Id

    var rv1 = $('#ReportViewer1_ctl09');

    var iDoc = rv1.parents('html');



    // Reading the report styles

    var styles = iDoc.find("head style[id$='ReportControl_styles']").html();

    if ((styles == undefined) || (styles == '')) {

        iDoc.find('head script').each(function () {

            var cnt = $(this).html();

            var p1 = cnt.indexOf('ReportStyles":"');

            if (p1 > 0) {

                p1 += 15;

                var p2 = cnt.indexOf('"', p1);

                styles = cnt.substr(p1, p2 - p1);

            }

        });

    }

    if (styles == '') { alert("Cannot generate styles, Displaying without styles.."); }

    styles = '<style type="text/css">' + styles + "</style>";



    // Reading the report html

    var table = rv1.find("div[id$='_oReportDiv']");

    if (table == undefined) {

        alert("Report source not found.");

        return;

    }



    // Generating a copy of the report in a new window

    var docType = '<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01//EN" "http://www.w3.org/TR/html4/loose.dtd">';

    var docCnt = styles + table.parent().html();

    var docHead = '<head><style>body{margin:5;padding:0;}</style></head>';

    var winAttr = "location=yes, statusbar=no, directories=no, menubar=no, titlebar=no, toolbar=no, dependent=no, width=720, height=600, resizable=yes, screenX=200, screenY=200, personalbar=no, scrollbars=yes";;

    var newWin = window.open("", "_blank", winAttr);

    writeDoc = newWin.document;

    writeDoc.open();

    writeDoc.write(docType + '<html>' + docHead + '<body onload="window.print();">' + docCnt + '</body></html>');

    writeDoc.close();

    newWin.focus();

    // uncomment to autoclose the preview window when printing is confirmed or canceled.

    // newWin.close();

};