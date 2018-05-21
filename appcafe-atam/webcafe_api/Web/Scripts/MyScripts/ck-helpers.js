(function ($) {
    $.fn.myCkfinderStart = function (options) {
        this.each(function() {
            $(this).wrap("<div class='wrap_img_ck'></div>");
        });
        $(".wrap_img_ck").each(function () {
               // Establish our default settings
                var self = $(this);
                self.append('<button title="Clear" class="btn btn-dropbox btn-xs btn-clear" type="button"><i class="fa fa-times"></i> remove </button>');
                self.append('<button title="Browse" class="btn btn-dropbox btn-xs btn-browse" type="button"><i class="fa fa-folder-open"></i> Browse</button>');
                self.append(' <div class="show-img"></div>');
                var btnClear = self.find(".btn-clear").first();
                var btnBrowse = self.find(".btn-browse").first();
                var txtAnh = self.find(".txt-anh").first();
                var showImg = self.find(".show-img").first();
          
                if (txtAnh.val().length > 3) {
                    showImg.html("<img src='" + txtAnh.val() + "'/>");
                }
                btnClear.click(function () {
                    txtAnh.val("");
                    showImg.html("");
                });
                btnBrowse.click(function () {
                    myCkFinder.fnDuyetanh(txtAnh, showImg);
                });
        });
    };

    $.fn.myCkfinderStartFile = function (options) {
        // Establish our default settings
        var self = this;
        var btnBrowse = self.find(".btn-browse").first();
        var txtFile = self.find(".txt-file").first();
        btnBrowse.click(function () {
            myCkFinder.fnDuyetfile(txtFile);
        });
    }
})(jQuery);

var myCkFinder = new function () {
    var self = this;
    self.fnCheckImageExtension = function (url){
        return (url.match(/\.(jpeg|jpg|gif|png|JPG|JPEG|GIF|PNG)$/) != null);
    }
    self.fnDuyetfile = function (selecback) {
        var ckf = new CKFinder();
        ckf.selectActionFunction = function (fileUrl) {
            selecback.val(fileUrl);
        }
        ckf.popup();
    }

    self.fnDuyetanh = function (selectback, divAnh) {
        var ckf = new CKFinder();
        ckf.callback = function (api) {
            //api.openMsgDialog("", "Almost ready to go!"); //mo popup trong ckfinder
            console.log("duyet anh");
        };
        //ckf.selectActionData = "container";
        ckf.selectActionFunction = function (fileUrl, data) {
            
            // alert('Selected file: ' + fileUrl);
            // Using CKFinderAPI to show simple dialog.
            //this.openMsgDialog('', 'Additional data: ' + data['selectActionData']);
            //document.getElementById(data['selectActionData']).innerHTML = fileUrl;
            selectback.val(fileUrl);
            /*
            if (self.fnCheckImageExtension(fileUrl)) {
                selectback.val(fileUrl);
            } else {
                console.log("Vui lòng chọn ảnh");
            }*/
            
            divAnh.html("<img src='" + fileUrl + "' width='100px'/>");
            console.log(fileUrl);
        }
        ckf.popup();
    }
}