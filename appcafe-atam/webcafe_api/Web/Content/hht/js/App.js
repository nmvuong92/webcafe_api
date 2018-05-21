var $GB_MODAL_DANGNHAP = $("#myModal_dnhap");
var $GB_MODAL_DANGKY = $("#myModal_dky");
var $GB_MODAL_APPLYJOB = $("#myModal_ApplyJob");
var $GB_MODAL_WALLET = $("#myModal_wallet");
var $GB_MODAL_ThanhToanJob = $("#myModal_ThanhToanJob");
var $GB_JOBMENU_HUNTING_SERVICE = $(".hht_cmd_use_hunting_service");
var $GB_MODAL_NOTIFICATION = $("#myModal_NOTIFICATION");
var CLSGB_MODAL = new function () {
    var self = this;
    self.fnShowModalDangKy = function () {
        $GB_MODAL_DANGKY.modal('show');

    }
    self.fnShowModalDangNhap = function () {
        $GB_MODAL_DANGNHAP.modal('show');
    }
    self.fnHideModalDangKy = function () {
        $("#myModal_dky").modal('hide');
    }
    self.fnHideModalDangNhap = function () {
        $GB_MODAL_DANGNHAP.modal('hide');
    }
    self.fnHideWallet = function () {
        $GB_MODAL_WALLET.modal('hide');
    }
    self.fnShowWallet = function () {
        //$GB_MODAL_WALLET.find(".modal-body").first().load();

        $GB_MODAL_WALLET.modal('show');
    }
}


var GB_SHOW_NOF = function () {
    CLSGB_MODAL.fnShowWallet();
}
var clsNotification = new function () {
    var self = this;
    self.fnShowModal = function () {
        $GB_MODAL_NOTIFICATION.modal('show');
    }
    self.fnHideModal = function () {
        $GB_MODAL_NOTIFICATION.modal('hide');
    }
}




function SetAutoWithImage() {
    var maxWidth = $('.container.content.about').width();
    $('.container.content.about .tab-content img').each(function () {
        var img = $(this);
        if (img.attr('data-width') == null) {
            img.attr('data-width', img.width());
            img.attr('data-height', img.height());
        }
        if (parseInt(img.attr('data-width')) < maxWidth) {
            img.css({
                width: img.attr('data-width'),
                height: img.attr('data-height')
            })
        }
        else if (img.width() > maxWidth) {
            img.css({ width: '100%', height: 'auto' });
            img.addClass('imgResize');
        }
    })
}

$(function () {
    SetAutoWithImage();
    $(window).resize(function () {
        SetAutoWithImage();
    });
})