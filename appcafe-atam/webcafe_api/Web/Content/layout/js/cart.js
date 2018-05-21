
jQuery(document).ready(function() {
	
	LoginForm();
	RegisterForm();
	forgetPasswordForm();
	InfoAccountForm();
	changePasswordForm();
	changeTabHome();
	checkContactForm();
	checkReviewsForm();
	
	$("#account_").click(function(){
		ReURL(url_site+'nguoi-dung/thong-tin-tai-khoan.html');
	});
	$("#orderAdmin").click(function(){
		ReURL(url_site+'nguoi-dung/quan-ly-don-hang.html');
	});
    $("#resetPass").click(function(){
		ReURL(url_site+'nguoi-dung/thay-doi-mat-khau.html');
	});
	$("#accountDoitrahang").click(function(){
		ReURL(url_site+'nguoi-dung/doi-tra-hang.html');
	});
	
	$(".close-adtocart").click(function()
	{
		$("#resultAddCart").fadeOut(400);	
	});
	// Chọn option 1 ở trang chi tiết sản phẩm
	$('.listOption1').click(function()
	{
		var star=$(this).attr('data-option');
		$(".listOption1").removeClass("starActive");
		$(this).addClass("starActive");
		$('#dataOptionChoose1').attr('value',star);
		
		// Xem hinh lien quan
		var id   = $(this).attr('data-id');
		var data = {
			id:id,
		}
		$.post(url_site+'?Ajax=Ajax&opt=changeOption', data, function(response){
			$("#box-changeOption").html(response);
		})
		return false;
		
	});
	$('.listOption2').click(function()
	{
		var star=$(this).attr('data-option');
		var image=$(this).attr('data-img');
		$(".listOption2").removeClass("starActive");
		$(this).addClass("starActive");
		$('#dataOptionChoose2').attr('value',star);
		//$("#showImage").html('<a href="javascript:void(0);" data-image="'+url_site+'upload/products_option/'+image+'" data-zoom-image="'+url_site+'upload/products_option/'+image+'"><img id="product-zoom" src="'+url_site+'upload/products_option/'+image+'" /> </a>');
		$("#product-zoom-show").attr('src',url_site+'upload/products_option/'+image);
		//$("#product-zoom").attr('data-zoom-image',url_site+'upload/products_option/'+image);
		
	});
	intShoppingCart();
	
	// Kiem tra thong tin don hang 
	$("#buttonCheckOrder").click(function(){
		var codeID = jQuery("#codeID").val();
		if(codeID=="") {
			alert("Xin vui lòng nhập mã đơn hàng.");
			$("#codeID").focus();
			return false;
		}
		else if(codeID.length>15){
			alert("Mã đăng ký nhập vào không hợp lệ.");
			$("#codeID").focus();
			return false;
		}
		else {
			$("#load_").html('Đang tải dữ liệu ...');
			$.ajax({  
				type: "POST",  
				url: url_site+"?Ajax=Ajax&opt=CheckOrder",  
				data: "codeID="+ codeID,  
				success: function(msg)
				{  
					$("#load_").html('');
					
					$("#box-resultOrder").html(msg);
				} 
			}); 	
		}
		//Mã xác nhận không hợp lệ, xin bạn vui lòng nhập lại
	});
});
function is_digit(input){
	if (isNaN(input)) {
    		return false;
	}else{
    		return true;
	}
}
function Add_Cart(id)
{
	var order_quantity=$("#order_quantity").attr("value");
	var option1=$("#dataOptionChoose1").attr("value");
	var option2=$("#dataOptionChoose2").attr("value");
	if(order_quantity>1) {
		quantity = order_quantity;	
	} 
	else {
		quantity = 1;	
	}
	$.get(url_site+"?Ajax=Ajax&opt=addCart", {id:id,quantity:quantity,option1:option1,option2:option2}, function(data){
		$("#resultAddCart").fadeIn(400);
		//ReURL(url_site+"shopping.html");
	});
	
}
function RemoveCart(pro_id)
{
	confirmRemoveCart(pro_id);
}
function RemoveAllCart()
{
	confirmRemoveAllCart();	
}

function confirmRemoveCart(pro_id)
{
	$.confirm({
			'title'		: lang_cart["cart_confirm"],
			'message'	: lang_cart["cart_note_on_delete"],
			'buttons'	: {
				'OK'	: {
					'class'	: 'blue',
					'action': function(){
						ReURL(url_site+"shopping/delete.html?id="+pro_id);
					}
				},
				'Cancel'	: {
					'class'	: 'gray',
					'action': function(){}
				}
			}
		});	
}
function confirmRemoveAllCart()
{
	$.confirm({
			'title'		: lang_cart["cart_confirm"],
			'message'	: lang_cart["cart_note_all_delete"],
			'buttons'	: {
				'OK'	: {
					'class'	: 'blue',
					'action': function(){
						ReURL(url_site+"shopping/emptyCart.html"); 
					}
				},
				'Cancel'	: {
					'class'	: 'gray',
					'action': function(){}
				}
			}
		});	
}
function intShoppingCart()
{
	/* 
		SHOPPING CONTROLLER
	*/
	$("#ShopContinueShopping").click(function(){
		ReURL(url_site);
	});
	
	$("#ShopCheckOut").click(function(){
		ReURL(url_site+"shopping/checkout.html");
	});
	
	$('#updateShopCart').click(function(){
		$('#formShopCart').attr('action', url_site+"shopping/update.html");
		$('#formShopCart').submit();
	});
	
	$('#backTocart').click(function(){
		ReURL(url_site + 'shopping.html');
	});
	/// Chọn tỉnh xuất hiện thông tin chi phí giao hàng
	$("#kh_address_city").change(function()
	{
		var id = $("#kh_address_city").val();
		var dataString = 'id='+ id;
		$.ajax
		({
			type: "GET",
			url: url_site+"?Ajax=Ajax&opt=ChangeCityPrice",
			data: dataString,
			cache: false,
			success: function(html)
			{
				$(".showcityPrice").html(html);
			} 
		});	
	});
	
	$("#SubmitOrderContinue").click(function(){
		
		checked = 0;
		var kh_email = $("#kh_email").val();
		if($('#kh_name').val() == ''){
			$("#errName").html(lang_cart["cart_err_name"]);	
			$('#kh_name').focus();
			checked = 1;
				
		} else if(kh_email == ''){
			$("#errName").html("");	
			$("#errEmail").html(lang_cart["cart_err_email"]);	
			$('#kh_email').focus();
			checked = 1;
		}
		else if(!validateEmail(kh_email)){
			$("#errEmail").html(lang_cart["cart_err_email_not"]);
			$('#kh_email').focus();
			checked = 1;
			
		} else if($("#kh_address").val() == ''){
			$("#errEmail").html("");	
			$("#errAddress").html(lang_cart["cart_err_address"]);	
			$('#kh_address').focus();
			checked = 1;
		}else if($("#kh_address_city").val() == 0){
			$("#errAddress").html("");	
			$("#errAddressCity").html(lang_cart["cart_err_address_city"]);	
			$('#kh_address_city').focus();
			checked = 1;
		}
		else if($("#kh_phone").val() == ''){
			$("#errAddress").html("");	
			$("#errPhone").html(lang_cart["cart_err_phone"]);	
			$('#kh_phone').focus();
			checked = 1;
			
		}
		else if(!is_digit($('#kh_phone').val()) )
		{
			$("#errPhone").html(lang_cart["cart_err_phone_not"]);
			$('#kh_phone').focus();
			checked = 1;
			
		} 
		if(checked==0) {
			$('#formCheckout').attr('action', url_site+"shopping/saveinfo.html");
			$('#formCheckout').submit();
		}
		else return false;
		
	});
	
	$('#confirmCheckout').click(function(){
		$('#formSubmitOrder').attr('action', url_site+"shopping/send_order.html");
		$('#formSubmitOrder').submit();
	});
	
	$('#formShopCart').submit(function(){
		return validateFormShopCart();
	});

}
function _ShopCheckOut(customers,callBack)
{
	var formOk = true;

	$('.price-item').each(function()
	{
		if($(this).val() == 0)
		{
			var idError = $(this).attr("data-id");
			alert("Vui lòng loại bỏ sản phẩm không tồn tại giá trong giỏ hàng trước khi thực hiện chức năng thanh toán. ");
			$("#table_"+idError).addClass("row-price-error");
			formOk = false;
			return false;
		}
		return formOk;
	});
	if(formOk==true){
		if(customers==0) {
			ReURL(url_site+'nguoi-dung/dang-nhap.html?next='+callBack);
			return false;
		}
		else
		{
			ReURL(url_site+"shopping/checkout.html");
		}
	}

}

function checkMsg()
{
	$("#_ags_msg").html('');
	$("#_ags_").attr("value","0");
}

function clearMsg()
{
	$("#_ags_").attr("value","1");
	$("#_ags_msg").html('<div class="red">Bạn chưa chấp nhận những điều khoản của website</div>');
}
function validateFormShopCart()
{
	var formOk = true;

	$('.mandatoryQuantity').each(function(){
		if($(this).val() < 1){
			$.Zebra_Dialog('<h3>Thông báo</h3><strong>Vui lòng nhập số lượng, số lượng phải ít nhất bằng 1</strong>');
			$(this).focus();
			formOk = false;
			return false;
		}
	});
	return formOk;
}
function ReURL(url)
{
	window.location=url;
}
function changerColor(url,id)
{
	ReURL(url+','+id);
}
function changerTinhnang(url,id)
{
	ReURL(url+','+id);
}
function changerBrand(url,id)
{
	ReURL(url+','+id);
}
function changerFlavors(url,id)
{
	ReURL(url+','+id);
}
function removeAllSelectCate(url)
{
	ReURL(url);
}
function removeSelectCate(url)
{
	ReURL(url);
}
function validateEmail(email) 
{
  var emailReg = /^([\w-\.]+@([\w-]+\.)+[\w-]{2,4})?$/;
  if( !emailReg.test( email ) ) 
  {
   	return false;
  } else {
    return true;
  }
}

function LoginForm() {
	var next = $("#next").val();
	if ($(".login-form").length > 0) {
		
		var formStatus = $(".login-form").validate();
		//   ===================================================== 
		$(".login-form").submit(function(e) {
			e.preventDefault();
			
			if (formStatus.errorList.length === 0)
			{
				$(".login-form .submit").fadeOut(function() {
					$('#loading').css('visibility', 'visible');
					$.post(url_site+'?Ajax=Ajax&opt=ConfirmLogin', $(".login-form").serialize(),
							function(data) {
								$(".login-form input").not('.submit').val('');
								if(data==0) {
									$('.message-box-login').html('<div class="alert alert-error">'+ lang_cart["customers_login_err"] +'</div>');	
								}
								else if(data==1) {
									var url = document.location;
									if(next!="") ReURL(next);
									else ReURL(url);
								}
								else {
									var url = document.location;
									ReURL(url);
								}

								$('#loading').css('visibility', 'hidden');
								$(".login-form .submit").removeClass('disabled').css('display', 'block');
							}

					);
				});
			}

	   });
	}
}

	function RegisterForm() {
        if ($(".register-form").length > 0) {
            var formStatus = $(".register-form").validate({
				rules: {
						repassword: {
							equalTo: "#password"
						}
					}	
			});
			
            $(".register-form").submit(function(e) {
                e.preventDefault();
	
                if (formStatus.errorList.length === 0)
                {
                    $(".register-form .submit").fadeOut(function() {
                        $('#loading').css('visibility', 'visible');
						$.post(url_site+'?Ajax=Ajax&opt=ConfirmRegister', $(".register-form").serialize(),
                                function(data) {
                                    $(".register-form input").not('.submit').val('');
									if(data=="NO") {
										$('.message-box-register').html('<div class="alert alert-error">Email đã được đăng ký</div>');	
									}
									
									else {
										$('.message-box-register').html('<div class="alert alert-succes">Đăng ký thành công, vui lòng đăng nhập để mua sắm.</div>');
									}
                                    $('#loading').css('visibility', 'hidden');
                                    $(".register-form .submit").removeClass('disabled').css('display', 'block');
                                }

                        );
                    });
                }

            });
        }
    }
	function forgetPasswordForm() {
        if ($(".forgetPassword-form").length > 0) {
            var formStatus = $(".forgetPassword-form").validate();
			
            $(".forgetPassword-form").submit(function(e) {
                e.preventDefault();
	
                if (formStatus.errorList.length === 0)
                {
                    $(".forgetPassword-form .submit").fadeOut(function() {
                        $('#loading').css('display', 'block');
						$.post(url_site+'?Ajax=Ajax&opt=forgetPassword', $(".forgetPassword-form").serialize(),
                                function(data) {
									alert(data);
                                    $(".forgetPassword-form input").not('.submit').val('');
									if(data=="fgot_account_disable") {
										$('.message-box-forgetPassword').html('<div class="alert alert-error"><a href="'+url_site+'nguoi-dung/kich-hoat-tai-khoan.html?type=renew" id="reActiveLogin">'+lang_cart["customers_active_not"]+'</a></div>');
									}
									else if(data=="fgot_not_email") {
										$('.message-box-forgetPassword').html('<div class="alert alert-error">Email này không tồn tại. Vui lòng kiểm tra lại</div>');	
									}
									else {
										$('.message-box-forgetPassword').html('<div class="alert alert-success">'+lang_cart["customers_forgot_pass_ok"]+'</div>');
									}
                                    $('#loading').css('display', 'none');
                                    $(".forgetPassword-form .submit").removeClass('disabled').css('display', 'block');
                                }

                        );
                    });
                }
				

            });
        }
		
    }
	
	function InfoAccountForm() {
        if ($(".infoAccount-form").length > 0) {
            var formStatus = $(".infoAccount-form").validate();
			
            $(".infoAccount-form").submit(function(e) {
                e.preventDefault();
	
                if (formStatus.errorList.length === 0)
                {
                    $(".infoAccount-form .submit").fadeOut(function() {
                        $('#loading').css('visibility', 'visible');
						$.post(url_site+'?Ajax=Ajax&opt=confirmInfoAccount', $(".infoAccount-form").serialize(),
                                function(data) {
									$(".infoAccount-form input").not('.submit').val('');
									
									$('.message-box-infoAccount').html('<div class="alert alert-succes">Thay đổi mật khẩu thành công.</div>');

                                    $('#loading').css('visibility', 'hidden');
                                    $(".infoAccount-form .submit").removeClass('disabled').css('display', 'block');
                                }

                        );
                    });
                }
            });
        }
    }
	function changePasswordForm() {
        if ($(".changePassword-form").length > 0) {
            var formStatus = $(".changePassword-form").validate();
			
            $(".changePassword-form").submit(function(e) {
                e.preventDefault();
	
                if (formStatus.errorList.length === 0)
                {
                    $(".changePassword-form .submit").fadeOut(function() {
                        $('#loading').css('visibility', 'visible');
						$.post(url_site+'?Ajax=Ajax&opt=confirmChangePass', $(".changePassword-form").serialize(),
                                function(data) {
									$(".changePassword-form input").not('.submit').val('');
									
									$('.message-box-changePassword').html('<div class="alert alert-succes">'+lang_cart["customers_change_pass_ok"]+'</div>');

                                    $('#loading').css('visibility', 'hidden');
                                    $(".changePassword-form .submit").removeClass('disabled').css('display', 'block');
                                }

                        );
                    });
                }
            });
        }
    }
	
function changeTabHome()
{
	$("#showProductsBestSelling").click(function()
	{
		$("#showProductsNew").removeClass("active");
		$("#showProductsBestSelling").addClass("active");
		
		$("#productsBestSelling").show();
		$("#productsNew").hide();	
	});
	$("#showProductsNew").click(function()
	{
		$("#showProductsBestSelling").removeClass("active");
		$("#showProductsNew").addClass("active");
		
		$("#productsBestSelling").hide();
		$("#productsNew").show();	
	});	
}
function orderReturn(order_products, order_status, page)
{
	if(order_status==5)
	{
		$.Zebra_Dialog('<h3>Thông báo</h3><strong>Đơn hàng đã được đổi trả</strong>');	
	}
	else if(order_status!=2 && order_status!=3)
	{
		$.Zebra_Dialog('<h3>Thông báo</h3><strong>Bạn không thể đổi trả sản phẩm trong đơn hàng này vì sản phẩm vẫn chưa được giao. Vui lòng liên hệ Bộ phận chăm sóc khách hàng để được hỗ trợ thêm.</strong>');	
	}
	else
	{
		$('#page_loading').show(300);
		$.get(url_site+"?Ajax=Ajax&opt=orderReturn", {order_products:order_products}, function(data)
		{
			$.Zebra_Dialog('<h3>Thông báo</h3><strong>'+data+'</strong>');
			$('#page_loading').fadeOut(300);
			ReURL(url_site+"nguoi-dung/quan-ly-don-hang.html?order_id="+order_products+"&page="+page);
		});
	}
}
function orderCancel(order_products, order_status, page)
{
	if(order_status==4)
	{
		$.Zebra_Dialog('<h3>Thông báo</h3><strong>Đơn hàng đã được đổi trả</strong>');	
	}
	else
	{
		$('#page_loading').show(300);
		$.get(url_site+"?Ajax=Ajax&opt=orderCancel", {order_products:order_products}, function(data)
		{
			$.Zebra_Dialog('<h3>Thông báo</h3><strong>'+data+'</strong>');
			$('#page_loading').fadeOut(300);
			ReURL(url_site+"nguoi-dung/quan-ly-don-hang.html?order_id="+order_products+"&page="+page);
		});
	}
}
function checkContactForm() {
	if ($(".contact-form").length > 0) {
		//  triggers contact form validation
		var formStatus = $(".contact-form").validate();
		//   ===================================================== 
		//sending contact form
		$(".contact-form").submit(function(e) {
			e.preventDefault();

			if (formStatus.errorList.length === 0)
			{
				$(".contact-form .submit").fadeOut(function() {
					$('#loading').css('display', 'block');
					$.post(url_site+'?Ajax=Ajax&opt=ConfirmContact', $(".contact-form").serialize(),
							function(data) {
								$(".contact-form input,.contact-form textarea").not('.submit').val('');
								$('.message-box').html(data);
								$('#loading').css('display', 'none');
								$(".contact-form .submit").removeClass('disabled').css('display', 'block');
							}

					);
				});


			}

		});
	}
}
	function listOption2(id)
	{
		$(".listOption2").removeClass("starActive");
		$(".list-"+id).addClass("starActive");
		$('#dataOptionChoose2').attr('value',id);	
		var image=$('.list-'+id).attr('data-img');	
		$("#product-zoom-show").attr('src',url_site+'upload/products_option/'+image);
	}
function changeLang(lang)
{
	var urlLang = document.location;
	$.get(url_site+"?Ajax=Ajax&opt=changeLang", {lang:lang}, function(data)
	{
		ReURL(urlLang);	
	});
		
}
function goToReviewsScroll(){
		$('html,body').animate({scrollTop: $("#showReviews").offset().top},'slow');
	}
function checkReviewsForm() 
{
	if ($(".proreviews-form").length > 0) 
	{
		var formStatus = $(".proreviews-form").validate();
		$(".proreviews-form").submit(function(e) 
		{
			e.preventDefault();

			if (formStatus.errorList.length === 0)
			{
				$(".proreviews-form .submit").fadeOut(function() 
				{
					$('#loading').css('display', 'block');
					$.post(url_site+'?Ajax=Ajax&opt=confirmReviews', $(".proreviews-form").serialize(),
							function(data) 
							{
								$(".proreviews-form input,.proreviews-form textarea").not('.submit').val('');
								$('.message-box-proreviews').html('<div class="alert alert-success">Gửi bình luận thành công</div>');
								$('#loading').css('display', 'none');
								$(".proreviews-form .submit").removeClass('disabled').css('display', 'block');
								$(".recent-reviews").prepend(data);
							}

					);
				});
			}
		});
	}
}