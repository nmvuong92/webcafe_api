/*MRV. nmvuong92@gmail.com*/
function fnPostPaging(_url, _method, _param, _datareturn, _fnBeforeSend, _fnSuccess, _fnCompelete) {

    $.ajax({
        //phương thức truy cập: POST/GET
        type: _method,
        /*
           kiểu dữ liệu mà ta gửi lên server vd:[application/x-www-form-urlencoded; charset=UTF-8]
           mặc định:application/x-www-form-urlencoded; charset=UTF-8
        */
        contentType: "application/json; charset=utf-8",

        /*kiểu dữ liệu mà ta nhận về (server trả về) [json, html, text]*/

        dataType: _datareturn,
        /*địa chỉ ajax*/
        url: _url,
        /*
           dữ liệu gửi đi
           ví dụ json: {"name":"John Doe"} 
        */
        data: _param,

        cache: false,

        //load ajax xong moi hien thi giao dien  
        async: true,

        //trước khi gửi đi
        beforeSend: _fnBeforeSend,
        //kết quả trả về
        success: _fnSuccess,
        //nếu gặp lỗi
        error: function (xhr) { // if error occured                                
            alert("Error: " + xhr.statusText + xhr.responseText);
        },
        //khi hoàn thành
        complete: _fnCompelete
    });
}
//http://stackoverflow.com/questions/18701282/what-is-content-type-and-datatype-in-an-ajax-request
function fnGetAjax(_url, _data, _fnSuccess)
{
    $.ajax({
        url:_url,
        type:'GET',
        dataType: "html",
        contentType: "application/x-www-form-urlencoded; charset=UTF-8", // this is the default value, so it's optional
        data: _data,
        success: _fnSuccess
    });
    
}
function fnAjax(options) {

    /* merge object2 into object1 */
    var settings = $.extend({
        method: "POST",
        datareturn: "json",
        param: {},
        fnBeforeSend: function () { },
        fnSuccess: function () { },
        fnCompelete: function () { },
        contentType: "application/json; charset=utf-8",
        async: true,
        cache:false
    }, options);
    
    $.ajax({
        //phương thức truy cập: POST/GET
        type: settings.method,
        /*
           kiểu dữ liệu mà ta gửi lên server vd:[application/x-www-form-urlencoded; charset=UTF-8]
           mặc định:application/x-www-form-urlencoded; charset=UTF-8
        */
        contentType: settings.contentType,

        /*kiểu dữ liệu mà ta nhận về (server trả về) [json, html, text]*/

        dataType: settings.datareturn,
        /*địa chỉ ajax*/
        url: settings.url,
        /*
           dữ liệu gửi đi
           ví dụ json: {"name":"John Doe"} 
        */
        data: settings.param,

        cache: settings.cache,

        //load ajax xong moi hien thi giao dien  
        async: settings.async,

        //trước khi gửi đi
        beforeSend: settings.fnBeforeSend,
        //kết quả trả về
        success: settings.fnSuccess,
        //nếu gặp lỗi
        error: function (xhr) { // if error occured                                
            alert("Error: " + xhr.statusText + xhr.responseText);
        },
        //khi hoàn thành
        complete: settings.fnCompelete
    });
}

var fnAjaxLoadHtml=function(_url,_callback) {
    fnAjax({
        url: _url,
        success:_callback
    });
}