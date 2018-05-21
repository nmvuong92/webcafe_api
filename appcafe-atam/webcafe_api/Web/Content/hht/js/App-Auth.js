var __port = location.port || (location.protocol === 'https:' ? '443' : '80');
var __host = "http://" + window.location.hostname;
var __protocol = location.protocol;
var __slashes = __protocol.concat("//");

var VDAjax = new function () {
    var self = this;
    self.GetAjaxJson = function (__url) {
        var rs;
        fnAjax({
            async:false,
            url: __url,
            fnSuccess: function (data) {
                rs = data;
            }
        });
        return rs;
    };
}
var VDAuth = new function () {
    var self = this;
    self.CanLog = VDAjax.GetAjaxJson("/Ajax/CheckLoginForCandiddates").r;
    self.EmLog = VDAjax.GetAjaxJson("/Ajax/CheckLoginForEmployees").r;
}
var VDConfig = new function () {
    var self = this;
    self.__config = VDAjax.GetAjaxJson("/Ajax/Config");
}

var Auth = new function() {
    var self = this;
    self.fnLogin = function (urlReturn) {
        $GB_MODAL_DANGNHAP.modal('show');
        if (urlReturn != undefined) {
            $('#myModal_dnhap #ReturnUrl').val(urlReturn);
        }
       
        return false;
    };
    self.fnLog = function() {
        console.log(window.__host);
    };
    self.getFullUrl = function(url) {
        if (parseInt(__port) != 80) {
            return __host + ":" + __port + "/" + url;
        } else {
            return __host + "/" + url;
        }

    };
    self.fnGOCAN = function(relativeUrl) {
        var url = self.getFullUrl(relativeUrl);
        if (!VDAuth.CanLog) {
            self.fnLogin(url);
        } else {
            return window.location.href = url;
        }
    };
    self.fnGOEM = function(relativeUrl) {
        var url = self.getFullUrl(relativeUrl);
        if (!VDAuth.EmLog) {
            self.fnLogin(url);
        } else {
            return window.location.href = url;
        }
    };
}




