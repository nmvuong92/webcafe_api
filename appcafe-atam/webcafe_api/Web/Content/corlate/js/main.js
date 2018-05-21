


var clsUser = new function () {
    var self = this;
    self.PloginSuccess = function (data) {
        if (data.r) {
            var re = $("#modalLogin").attr("data-redirect");
            if (re!=undefined && re != "") {
                window.location.href = re;
            } else {
                window.location.reload(false);
            }
        } else {
            alert("Tài khoản mật khẩu không chính xác!");
        }
    }
    self.PRegisterSuccess = function (data) {
        if (data.r) {
            window.location.href = "/home/index";
        } else {
            alert(data.m);
        }
    }
    self.CheckUserLogin = function (_url) {
        $.getJSON("/ajax/CheckUserLogin", function (data) {
            if (data.r) {
                window.location.href = _url;
            } else {
                alert(data.m);
            }
        });
    }
    self.showPopLogin = function (title,redirect) { //clsUser.openDangNhap
        $("#modalLogin").modal("show");
        $("#modalLogin").attr("data-redirect", redirect);
        if (title != "") {
            $("#modalLogin").find(".modal-title").html(title);
        }
    }
    self.fnShowDoiMatKhau = function() {
        $("#mymodal").find(".modal-content").load("/user/doimatkhau",function() {
            $("#mymodal").modal("show");
            $.validator.unobtrusive.parse($("#mymodal form"));
        });
    }
    self.fnDoiMatKhauSuccess = function(data) {
        alert(data.m);
        if (data.r) {
            $("#mymodal").modal("hide");
        }
    }

    self.fnShowCapNhatThongTin = function () {
        $("#mymodal").find(".modal-content").load("/user/capnhat", function () {
            $("#mymodal").modal("show");
            $.validator.unobtrusive.parse($("#mymodal form"));
        });
    }
    self.fnCapNhatThongTinSuccess = function (data) {
        alert(data.m);
        if (data.r) {
            $("#mymodal").modal("hide");
            window.location.reload(false);
        }
    }
}

var $loading = $('#loadingDiv').hide();
$(document)
  .ajaxStart(function () {
      $loading.show();
  })
  .ajaxStop(function () {
      $loading.hide();
  });




var clsThongBao = new function () {
    var self = this;
    self.modalThongBao = $("#modalThongBao");

    self.hienthithongbao= function() {
        $.getJSON("/thongbao/laythongbao", function(data) {
            if (data != null) {
                console.log(data);
                self.modalThongBao.find(".modal-title").html(data.TieuDe);
                self.modalThongBao.find(".modal-body").html(data.NoiDung);
                self.modalThongBao.modal("show");
            }
        });
    }
    self.anthongbao=function() {
        
    }
}


//clsThongBao.hienthithongbao();