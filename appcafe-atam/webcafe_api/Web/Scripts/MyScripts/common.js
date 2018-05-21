function IsValidDate(date) {
    var regex = /\d{1,2}\/\d{1,2}\/\d{4}/;
    if (!regex.test(date)) return false;
    var day = Number(date.split("/")[1]);
    date = new Date(date);
    if (date && date.getDate() != day) return false;
    return true;
}
function IsValidImage(str) {
    var filter = /^(([a-zA-Z]:)|(\\{2}\w+)\$?)(\\(\w[\w].*))(.jpg|.JPG|.gif|.GIF|.jpeg|.JPEG|.bmp|.BMP|.png|.PNG)$/;
    var flag = filter.test(str);
    return flag;
}
function CheckEmail(str) {
    var filter = /^[a-zA-Z0-9._-]+@([a-zA-Z0-9.-]+\.)[a-zA-Z]{2,4}$/;
    var flag = filter.test(str);
    return flag;
}
function IsNumeric(evt) {
    var theEvent = evt || window.event;
    var key = theEvent.keyCode || theEvent.which;
    key = String.fromCharCode(key);
    var regex = /[0-9]|\./;
    if (!regex.test(key)) {
        theEvent.returnValue = false;
        if (theEvent.preventDefault) theEvent.preventDefault();
    }
}
//chi cho go so
function isNumber(evt) {
    evt = (evt) ? evt : window.event;
    var charCode = (evt.which) ? evt.which : evt.keyCode;
    if (charCode > 31 && (charCode < 48 || charCode > 57)) {
        return false;
    }
    return true;
}
function isNumber(evt, thiss) {
    evt = (evt) ? evt : window.event;
    var charCode = (evt.which) ? evt.which : evt.keyCode;
    if (charCode > 31 && (charCode < 48 || charCode > 57)) {
        return false;
    }
    return true;
}
// WRITE THE VALIDATION SCRIPT IN THE HEAD TAG.
function isNumberKeyCode(evt) {
    var iKeyCode = (evt.which) ? evt.which : evt.keyCode;
    if (iKeyCode != 46 && iKeyCode > 31 && (iKeyCode < 48 || iKeyCode > 57))
        return false;
    return true;
}
function wopen_full(url) {
    window.open(url, '', 'fullscreen=yes, scrollbars=yes');
}

function wopen(url, title, w, h) {
    var title = typeof title !== 'undefined' ? title : "No title";
    var w = typeof w !== 'undefined' ? w : 1100;
    var h = typeof h !== 'undefined' ? h : 680;
    // Fixes dual-screen position                         Most browsers      Firefox
    var dualScreenLeft = window.screenLeft != undefined ? window.screenLeft : screen.left;
    var dualScreenTop = window.screenTop != undefined ? window.screenTop : screen.top;

    var width = window.innerWidth ? window.innerWidth : document.documentElement.clientWidth ? document.documentElement.clientWidth : screen.width;
    var height = window.innerHeight ? window.innerHeight : document.documentElement.clientHeight ? document.documentElement.clientHeight : screen.height;

    var left = ((width / 2) - (w / 2)) + dualScreenLeft;
    var top = ((height / 2) - (h / 2)) + dualScreenTop;
    var newWindow = window.open(url, title, 'scrollbars=yes, width=' + w + ', height=' + h + ', top=' + top + ', left=' + left);

    // Puts focus on the newWindow
    if (window.focus) {
        newWindow.focus();
    }
}

function wopenMax(url, name) {
    var win = window.open(url,
    name,
    'width=' + screen.width + ', height=' + screen.height + ', ' +
    'left=' + 0 + ', top=' + 0 + ', ' +
    'location=no, menubar=no, ' +
    'status=no, toolbar=no, scrollbars=yes, resizable=no,fullscreen=yes');
}
function filterElement(elem) { return document.getElementById(elem) } function IsAlphabet(Digit) { return /^[a-zA-Z]$/.test(Digit) } function Trim(temp) { if (temp == "") return temp; temp = temp + ""; return RTrim(LTrim(temp)) } function LTrim(temp) { if (temp == "") return temp; return temp.replace(/^\s+/, "") } function RTrim(temp) { if (temp == "") return temp; return temp.replace(/\s+$/, "") }
function FormatCurrency(num, currencyCode, isReplace, justFormat) {
    if (num == null) return ""; var num = num.toString().replace(/\$|\,/g, ""); if (isNaN(num)) num = "0"; var sign = num == (num = Math.abs(num)); num = Math.floor(num * 100 + 0.50000000001); cents = num % 100; num = Math.floor(num / 100).toString(); if (cents < 10) cents = "0" + cents; for (var i = 0; i < Math.floor((num.length - (1 + i)) / 3) ; i++) switch (Trim(currencyCode.toLowerCase())) {
        case "en-us": num = num.substring(0, num.length - (4 * i + 3)) + "," + num.substring(num.length - (4 * i + 3)); break; case "vi-vn": num =
num.substring(0, num.length - (4 * i + 3)) + "." + num.substring(num.length - (4 * i + 3)); break
    } var res = "0"; switch (Trim(currencyCode.toLowerCase())) {
        case "en-us": if (justFormat != null && justFormat == true) if (isReplace == false) res = (sign ? "" : "-") + num + "." + cents; else res = (sign ? "" : "-") + num; else if (isReplace == false) res = (sign ? "" : "-") + "$" + num + "." + cents; else res = (sign ? "" : "-") + "$" + num; break; case "vi-vn": if (justFormat != null && justFormat == true) if (isReplace == false) res = (sign ? "" : "-") + num + "," + cents; else res = (sign ? "" : "-") + num; else if (isReplace ==
false) res = (sign ? "" : "-") + num + "," + cents + "<u>\u0111</u>"; else res = (sign ? "" : "-") + num + "<u>\u0111</u>"; break
    } return res
}
function checkMoney(controlCheckCorrectID) { var input = Trim(filterElement(controlCheckCorrectID).value.toString()); if (input != "" && !IsAlphabet(input)) { var priceFor = Trim(Money2Long(input)); if (FormatCurrency(priceFor, "vi-vn", true, true) == "0") filterElement(controlCheckCorrectID).value = "0"; else filterElement(controlCheckCorrectID).value = FormatCurrency(priceFor, "vi-vn", true, true) } else filterElement(controlCheckCorrectID).value = input.substring(0, input.length - 1) }
function Money_OnBlurChange(controlCheckCorrectID) { var input = Trim(filterElement(controlCheckCorrectID).value.toString()); var price = Trim(Money2Long(input)); if (price == "" || parseInt(price) <= 0) filterElement(controlCheckCorrectID).value = "0" } function Money2Long(input) { return parseInt(input.replace(/\./ig, "")) }
function Money_OnBlurChangedMin(minControlCheckCorrectID, maxControlCheckCorrectID) {
    var inputMin = Trim(filterElement(minControlCheckCorrectID).value.toString()); var inputMax = Trim(filterElement(maxControlCheckCorrectID).value.toString()); var minPrice = ""; var arrMinPrice = inputMin.split("."); if (arrMinPrice.length > 1) for (var iMin = 0; iMin < arrMinPrice.length; iMin++) minPrice += arrMinPrice[iMin]; else minPrice = Money2Long(inputMin); minPrice = Trim(minPrice); var maxPrice = ""; var arrMaxPrice = inputMax.split("."); if (arrMaxPrice.length >
1) for (var iMax = 0; iMax < arrMaxPrice.length; iMax++) maxPrice += arrMaxPrice[iMax]; else maxPrice = Money2Long(inputMax); maxPrice = Trim(maxPrice); if (minPrice == "" || parseInt(minPrice) < 1E3) filterElement(minControlCheckCorrectID).value = "1.000"
}
function Money_OnBlurChangedMax(minControlCheckCorrectID, maxControlCheckCorrectID) {
    var inputMin = Trim(filterElement(minControlCheckCorrectID).value.toString()); var inputMax = Trim(filterElement(maxControlCheckCorrectID).value.toString()); var minPrice = ""; var arrMinPrice = inputMin.split("."); if (arrMinPrice.length > 1) for (var iMin = 0; iMin < arrMinPrice.length; iMin++) minPrice += arrMinPrice[iMin]; else minPrice = Money2Long(inputMin); minPrice = Trim(minPrice); var maxPrice = ""; var arrMaxPrice = inputMax.split("."); if (arrMaxPrice.length >
1) for (var iMax = 0; iMax < arrMaxPrice.length; iMax++) maxPrice += arrMaxPrice[iMax]; else maxPrice = Money2Long(inputMax); maxPrice = Trim(maxPrice); if (maxPrice == "" || parseInt(maxPrice) < 1E3) filterElement(maxControlCheckCorrectID).value = "1.000"
}

function formatMoney(num) {
    var p = num.toFixed(2).split(".");
    var chars = p[0].split("").reverse();
    var newstr = '';
    var count = 0;
    for (x in chars) {
        count++;
        if (count % 3 == 1 && count != 1) {
            newstr = chars[x] + '.' + newstr;
        } else {
            newstr = chars[x] + newstr;
        }
    }
    return newstr;
}
var mangso = ['không', 'một', 'hai', 'ba', 'bốn', 'năm', 'sáu', 'bảy', 'tám', 'chín'];
function dochangchuc(so, daydu) {
    var chuoi = "";
    chuc = Math.floor(so / 10);
    donvi = so % 10;
    if (chuc > 1) {
        chuoi = " " + mangso[chuc] + " mươi";
        if (donvi == 1) {
            chuoi += " mốt";
        }
    } else if (chuc == 1) {
        chuoi = " mười";
        if (donvi == 1) {
            chuoi += " một";
        }
    } else if (daydu && donvi > 0) {
        chuoi = " lẻ";
    }
    if (donvi == 5 && chuc >= 1) {
        chuoi += " lăm";
    } else if (donvi > 1 || (donvi == 1 && chuc == 0)) {
        chuoi += " " + mangso[donvi];
    }
    return chuoi;
}

function docblock(so, daydu) {
    var chuoi = "";
    tram = Math.floor(so / 100);
    so = so % 100;
    if (daydu || tram > 0) {
        chuoi = " " + mangso[tram] + " trăm";
        chuoi += dochangchuc(so, true);
    } else {
        chuoi = dochangchuc(so, false);
    }
    return chuoi;
}

function dochangtrieu(so, daydu) {
    var chuoi = "";
    trieu = Math.floor(so / 1000000);
    so = so % 1000000;
    if (trieu > 0) {
        chuoi = docblock(trieu, daydu) + " triệu";
        daydu = true;
    }
    nghin = Math.floor(so / 1000);
    so = so % 1000;

    if (nghin > 0) {
        chuoi += docblock(nghin, daydu) + " nghìn";
        daydu = true;
    }
    if (so > 0) {
        chuoi += docblock(so, daydu);
    }
    return chuoi;
}

//ĐỌC TIỀN
function docso(so) {
    if (so == 0) return mangso[0];
    var chuoi = "", hauto = "";
    do {
        ty = so % 1000000000;
        so = Math.floor(so / 1000000000);
        if (so > 0) {
            chuoi = dochangtrieu(ty, true) + hauto + chuoi;
        } else {
            chuoi = dochangtrieu(ty, false) + hauto + chuoi;
        }
        hauto = " tỷ";
    } while (so > 0);
    return chuoi + " đồng";
}

//
//Thêm dấu chấm
function them_dau_cham(x) {
    try {
        return x.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ".");
    } catch (err) {
        return "0";
    }
}
//Bỏ dấu chấm
function bo_dau_cham(numstring) {
    try {
        return numstring.replace(/\./g, '');
    } catch (err) {
        return "0";
    }
}
//Bỏ dấu chấm
function bo_dau_cham_parseFloat(numstring) {
    try {
        return parseFloat(numstring.replace(/\./g, ''));
    } catch (err) {
        return "0";
    }
}

function isNullorEmpty(obj) {
    if (obj.val().length == 0 || obj.val() == undefined) {
        return true; //erros
    }
    return false;
}
function isValid(p) { //kiem tra ma so thue
    var phoneRe = /^[0-9-_]+$/;
    return (p.match(phoneRe) !== null);
}
function isValidMST(p) { //kiem tra ma so thue
    var phoneRe = /^[0-9-_]{10,20}$/;
    return (p.match(phoneRe) !== null);
}

function ValidateDate(dtValue) {
    var dtRegex = new RegExp(/\b\d{1,2}[\/-]\d{1,2}[\/-]\d{4}\b/);
    return dtRegex.test(dtValue);
}
function IsEmail($email) {
    var emailReg = /^([\w-\.]+@([\w-]+\.)+[\w-]{2,4})?$/;
    if (!emailReg.test($email)) {
        return false;
    } else {
        return true;
    }
}

function GetDefaultID(value) {
    
    var idchon = -1;
    if (value != "" && value != undefined && value != null) {
        idchon = parseInt(value);
    }
    return idchon;
}
function GetCheckboxValue(checkbox) {
    return checkbox.is(":checked");
}

function returnDateFromJson(jsondate) {
    var dateString = jsondate.substr(6);
    var currentTime = new Date(parseInt(dateString));
    var month = currentTime.getMonth() + 1;
    var day = currentTime.getDate();
    var year = currentTime.getFullYear();
    var date = day + "/" + month + "/" + year;
    return date;
}
function IsNullOrUndefined(value) {
    return (value == null || value == undefined);
}

function IsLessOrZeroOrNull(value) {
    return (IsNullOrUndefined(value) || value == "" || value == 0);
}

//my first plugin
(function ($) {
    $.fn.GetMyNumber = function () {
        var g = this.autoNumeric("get");
        if (g == "") {
            return 0;
        }
        return parseFloat(g);
    };
    $.fn.overlay = function () {
        if (this.find('div.overlay').length == 0)
        {
            this.append("<div class=\"overlay\"><i class=\"fa fa-refresh fa-spin\"></i></div>");
        } 
    };

}(jQuery));
// This is a functions that scrolls to #{blah}link
function setHtmlLoading(id) {

        id.html("<img src='/Content/ajax-loading.gif'/>");

   
   
}


$(function() {
    $(".img-up[type=file]").change(function() {
        var self = this;
        var img = $(this).parent().find("img").first();
        if (self.files && self.files[0]) {
            var reader = new FileReader();
            reader.onload = function(e) {
                img.attr('src', e.target.result);
            }
            reader.readAsDataURL(self.files[0]);
        }
    });

});

function ScrollTo(selector,speed) {
    $('html, body').animate({
        scrollTop: selector.offset().top
    }, speed);
}
function activaTab(tab) {
    $('.nav-tabs a[href="#' + tab + '"]').tab('show');
};


var delay = (function () {
    var timer = 0;
    return function (callback, ms) {
        clearTimeout(timer);
        timer = setTimeout(callback, ms);
    };
})();


function ReadImageB64(img_id) {
    var b64Str = "";
    if (this.files && this.files[0]) {
        var FR= new FileReader();
        FR.onload = function(e) {
            document.getElementById(img_id).src = e.target.result;
            b64Str = e.target.result;
        };       
        FR.readAsDataURL( this.files[0] );
    }
    return b64Str;
}


/*myplugin-paging*/
/*
function mypaging(parent,fnReload) {
        parent.find(".colOrder").click(function () {
            var thiss = $(this);
            var cursortfield = thiss.data("col");
            if (thiss.hasClass("headerSortUp")) //ASC
            {
                self.cursortvalue = "desc";
                fnReload();
                thiss.removeClass("headerSortUp");
                thiss.addClass("headerSortDown");
            } else if (thiss.hasClass("headerSortDown")) //DESC
            {
                self.cursortvalue = "asc";
                fnReload();
                thiss.removeClass("headerSortDown");
                thiss.addClass("headerSortUp");
            } else {
                self.cursortvalue = "asc";
                fnReload();
                thiss.addClass("headerSortUp");
            }

            //remove all sort parameter class
            $(self.id_parent + " .colOrder").not(thiss).removeClass("headerSortUp");
            $(self.id_parent + " .colOrder").not(thiss).removeClass("headerSortDown");
        });
       
    }
    */

/*url helpers*/
var myUrlHelpers = new function () {
    var self = this;
    /**
     * get parameter of url by name
     * @param {name} key 
     * @param {url} default current url
     * @return {Number} sum
     */
    self.getParam = function(name, url) {
        if (!url) {
            url = window.location.href;
        }
        name = name.replace(/[\[\]]/g, "\\$&");
        var regex = new RegExp("[?&]" + name + "(=([^&#]*)|&|#|$)"),
            results = regex.exec(url);
        if (!results) return null;
        if (!results[2]) return '';
        return decodeURIComponent(results[2].replace(/\+/g, " "));
    }
    self.updateURLParameter = function(url, param, paramVal) {
        var newAdditionalURL = "";
        var tempArray = url.split("?");
        var baseURL = tempArray[0];
        var additionalURL = tempArray[1];
        var temp = "";
        if (additionalURL) {
            tempArray = additionalURL.split("&");
            for (i = 0; i < tempArray.length; i++) {
                if (tempArray[i].split('=')[0] != param) {
                    newAdditionalURL += temp + tempArray[i];
                    temp = "&";
                }
            }
        }
        var rows_txt = temp + "" + param + "=" + paramVal;
        return baseURL + "?" + newAdditionalURL + rows_txt;
    }
   
}


/*<input class="clearable" type="text" name="" value="" placeholder="" />*/
function tog(v){return v?'addClass':'removeClass';} 
$(document).on('input', '.clearable', function(){
    $(this)[tog(this.value)]('x');
}).on('mousemove', '.x', function( e ){
    $(this)[tog(this.offsetWidth-18 < e.clientX-this.getBoundingClientRect().left)]('onX');
}).on('touchstart click', '.onX', function( ev ){
    ev.preventDefault();
    $(this).removeClass('x onX').val('').change();
});

function fnInit() {
  
}


function bodauTiengViet(str) {
    str = str.toLowerCase();
    str = str.replace(/à|á|ạ|ả|ã|â|ầ|ấ|ậ|ẩ|ẫ|ă|ằ|ắ|ặ|ẳ|ẵ/g, 'a');
    str = str.replace(/è|é|ẹ|ẻ|ẽ|ê|ề|ế|ệ|ể|ễ/g, 'e');
    str = str.replace(/ì|í|ị|ỉ|ĩ/g, 'i');
    str = str.replace(/ò|ó|ọ|ỏ|õ|ô|ồ|ố|ộ|ổ|ỗ|ơ|ờ|ớ|ợ|ở|ỡ/g, 'o');
    str = str.replace(/ù|ú|ụ|ủ|ũ|ư|ừ|ứ|ự|ử|ữ/g, 'u');
    str = str.replace(/ỳ|ý|ỵ|ỷ|ỹ/g, 'y');
    str = str.replace(/đ/g, 'd');
    // str = str.replace(/\W+/g, ' ');
    str = str.replace(/\s/g, '-');
    return str;
}