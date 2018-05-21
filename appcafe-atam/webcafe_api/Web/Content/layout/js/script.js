(function($){
    "use strict"; // Start of use strict
    /* ---------------------------------------------
     Scripts initialization
     --------------------------------------------- */
    $(window).load(function() {
        // auto width megamenu
        auto_width_megamenu();
        resizeTopmenu();
        js_height_full();
    });
    /* ---------------------------------------------
     Scripts ready
     --------------------------------------------- */
    $(document).ready(function() {
        js_height_full();
        if($('.parallax').length >0){
            $('.parallax').each(function(){
                $(this).parallax("50%",0.1);
            })  
        }
        $('[data-toggle="tooltip"]').tooltip();
        /* Resize top menu*/
		
		/*$('.vertical-menu-content').hover(function() {
			$('#jsMenuMarkLayer').stop().delay(20).fadeIn(100);
		}, function() {
			$('#jsMenuMarkLayer').stop().delay(20).fadeOut(100);
		});*/
		var widthIframe = $(window).width();
		if(widthIframe<480)
		{
			$(".tab-container iframe").attr('width','100%');
			$(".tab-container iframe").attr('height','100%');
		}

		$(".content-text img").attr('width',"");
		$(".content-text img").attr('height',"");
		
		$(".content-text img").attr('style','');

		$("a[rel=lightbox]").fancybox({
			'transitionIn'		: 'elastic',
			'transitionOut'		: 'elastic',
			'titlePosition' 	: 'over',
			'titleFormat'		: function(title,  currentArray, currentIndex, currentOpts) {
			}
		});
		
		// -------------------------------------------------------------------------------------------------------
		// AUTO SEARCH
		// -------------------------------------------------------------------------------------------------------
		$(".btn-search").click(function(){
			var q = $('.txtsearch').val();
			var idCate = $('.select-category').val();
			if(q=="") {
				alert("Vui lòng nhập từ khóa tìm kiếm");
				$('.txtsearch').focus();
				return false;
			} else {
				ReURL(url_site+"tim-kiem.html?q="+q+"&idCate="+idCate);
			}
		});
		
		$(".txtsearch").keyup(function() 
		{
			var searchbox = $(this).val();
			var idCate = $('.select-category').val();
			var dataString = 'searchword='+ searchbox + "&idCate="+ idCate;
	
			if(searchbox=='')
			{
				
			}
			else
			{
				$.ajax({
						type: "POST",
						url: url_site+"?Ajax=Ajax&opt=searchAuto",
						data: dataString,
						cache: false,
						success: function(html)
						{
							$("#display").html(html).show();
						}
					});
			}
			return false;    
		});
		
		$(document).mouseup(function()
		{
			$("#display").hide();
		});
		
        resizeTopmenu();
        /* Zoom image */
        if($('#product-zoom').length >0){
            $('#product-zoom').elevateZoom({
                zoomType: "inner",
                cursor: "crosshair",
                zoomWindowFadeIn: 500,
                zoomWindowFadeOut: 750,
                gallery:'gallery_01'
            }); 
        }

        /* Popup sizechart */
        if($('#size_chart').length >0){
            $('#size_chart').fancybox();
        }
		
		

        /** OWL CAROUSEL**/
        $(".owl-carousel").each(function(index, el) {
          var config = $(this).data();
          config.navText = ['<i class="fa fa-angle-left"></i>','<i class="fa fa-angle-right"></i>'];
          config.smartSpeed="300";
          if($(this).hasClass('owl-style2')){
            config.animateOut="fadeOut";
            config.animateIn="fadeIn";    
          }
          $(this).owlCarousel(config);
        });
        
        $(".owl-carousel-vertical").each(function(index, el) {
          var config = $(this).data();
          config.navText = ['<span class="icon-up"></spam>','<span class="icon-down"></span>'];
          config.smartSpeed="900";
          config.animateOut="";
            config.animateIn="fadeInUp";
          $(this).owlCarousel(config);
        });
        /** COUNT DOWN **/
        $('[data-countdown]').each(function() {
           var $this = $(this), finalDate = $(this).data('countdown');
           $this.countdown(finalDate, function(event) {
             var fomat ='<span>%H</span><b></b><span>%M</span><b></b><span>%S</span>';
             $this.html(event.strftime(fomat));
           });
        });
        if($('.countdown-lastest').length >0){
            var labels = ['Years', 'Months', 'Weeks', 'Days', 'Hrs', 'Mins', 'Secs'];
            var layout = '<span class="box-count"><span class="number">{dnn}</span> <span class="text">Days</span></span><span class="dot">:</span><span class="box-count"><span class="number">{hnn}</span> <span class="text">Hrs</span></span><span class="dot">:</span><span class="box-count"><span class="number">{mnn}</span> <span class="text">Mins</span></span><span class="dot">:</span><span class="box-count"><span class="number">{snn}</span> <span class="text">Secs</span></span>';
            $('.countdown-lastest').each(function() {
                var austDay = new Date($(this).data('y'),$(this).data('m') - 1,$(this).data('d'),$(this).data('h'),$(this).data('i'),$(this).data('s'));
                $(this).countdown({
                    until: austDay,
                    labels: labels, 
                    layout: layout
                });
            });
        }
        /* Close top banner*/
        $(document).on('click','.btn-close',function(){
            $(this).closest('.top-banner').animate({ height: 0, opacity: 0 },1000);
            return false;
        })
        /** SELECT CATEGORY **/
        $('.select-category').select2();
        /* Toggle nav menu*/
        $(document).on('click','.toggle-menu',function(){
            $(this).closest('.nav-menu').find('.navbar-collapse').toggle();
            return false;
        })
        /** HOME SLIDE**/
        if($('#home-slider').length >0 && $('#contenhomeslider').length >0){
            var slider = $('#contenhomeslider').bxSlider(
                {
                    nextText:'<i class="fa fa-angle-right"></i>',
                    prevText:'<i class="fa fa-angle-left"></i>',
                    auto: true,
                }

            );
        }
        /** Custom page sider**/
        if($('#home-slider').length >0 && $('#contenhomeslider-customPage').length >0){
            var slider = $('#contenhomeslider-customPage').bxSlider(
                {
                    nextText:'<i class="fa fa-angle-right"></i>',
                    prevText:'<i class="fa fa-angle-left"></i>',
                    auto: true,
                    pagerCustom: '#bx-pager',
                    nextSelector: '#bx-next',
                    prevSelector: '#bx-prev',
                }

            );
        }

        if($('#home-slider').length >0 && $('#slide-background').length >0){
            var slider = $('#slide-background').bxSlider(
                {
                    nextText:'<i class="fa fa-angle-right"></i>',
                    prevText:'<i class="fa fa-angle-left"></i>',
                    auto: true,
                    onSlideNext: function ($slideElement, oldIndex, newIndex) {
                       var corlor = $($slideElement).data('background');   
                       $('#home-slider').css('background',corlor);     
                    },
                    onSlidePrev: function ($slideElement, oldIndex, newIndex) {
                       var corlor = $($slideElement).data('background');   
                       $('#home-slider').css('background',corlor);     
                    }
                }

            );
            //slider.goToNextSlide();
        }
        
        /* elevator click*/ 
        $(document).on('click','a.btn-elevator',function(e){
            e.preventDefault();
            var target = this.hash;
            if($(document).find(target).length <=0){
                return false;
            }
            var $target = $(target);
            $('html, body').stop().animate({
                'scrollTop': $target.offset().top-50
            }, 500);
            return false;
        })
        /* scroll top */ 
        $(document).on('click','.scroll_top',function(){
            $('body,html').animate({scrollTop:0},400);
            return false;
        })
        /** #brand-showcase */
        $(document).on('click','.brand-showcase-logo li',function(){
            var id = $(this).data('tab');
            $(this).closest('.brand-showcase-logo').find('li').each(function(){
                $(this).removeClass('active');
            });
            $(this).closest('li').addClass('active');
            $('.brand-showcase-content').find('.brand-showcase-content-tab').each(function(){
                $(this).removeClass('active');
            })
            $('#'+id).addClass('active');
            return false;
        })
        // CATEGORY FILTER 
        $('.slider-range-price').each(function(){
            var min             = $(this).data('min');
            var max             = $(this).data('max');
            var unit            = $(this).data('unit');
            var value_min       = $(this).data('value-min');
            var value_max       = $(this).data('value-max');
            var label_reasult   = $(this).data('label-reasult');
            var t               = $(this);
            $( this ).slider({
              range: true,
              min: min,
              max: max,
              values: [ value_min, value_max ],
              slide: function( event, ui ) {
                var result = label_reasult +" "+ unit + ui.values[ 0 ] +' - '+ unit +ui.values[ 1 ];
                console.log(t);
                t.closest('.slider-range').find('.amount-range-price').html(result);
              }
            });
        })
        
        /** ALL CAT **/
        $(document).on('click','.open-cate',function(){
            $(this).closest('.vertical-menu-content').find('li.cat-link-orther').each(function(){
                $(this).slideDown();
            });
            $(this).addClass('colse-cate').removeClass('open-cate').html('Close');
        })
        /* Close category */
        $(document).on('click','.colse-cate',function(){
            $(this).closest('.vertical-menu-content').find('li.cat-link-orther').each(function(){
                $(this).slideUp();
            });
            $(this).addClass('open-cate').removeClass('colse-cate').html('All Categories');
            return false;
        })
        // bar ontop click
        $(document).on('click','.vertical-megamenus-ontop-bar',function(){
            $('#vertical-megamenus-ontop').find('.box-vertical-megamenus').slideToggle();
            $('#vertical-megamenus-ontop').toggleClass('active');
            return false;
        })
        // View grid list product 
        $(document).on('click','.display-product-option .view-as-grid',function(){
            $(this).closest('.display-product-option').find('li').removeClass('selected');
            $(this).addClass('selected');
            $(this).closest('#view-product-list').find('.product-list').removeClass('list').addClass('grid');
            return false;
        })
        // View list list product 
        $(document).on('click','.display-product-option .view-as-list',function(){
            $(this).closest('.display-product-option').find('li').removeClass('selected');
            $(this).addClass('selected');
            $(this).closest('#view-product-list').find('.product-list').removeClass('grid').addClass('list');
            return false;
        })
        /// tre menu category
        $(document).on('click','.tree-menu li span',function(){
            $(this).closest('li').children('ul').slideToggle();
            if($(this).closest('li').haschildren('ul')){
                $(this).toggleClass('open');
            }
            return false;
        })
        /* Open menu on mobile */
        $(document).on('click','.btn-open-mobile',function(){
            var width = $(window).width();
            if(width >1024){
                if($('body').hasClass('home')){
                    if($('#nav-top-menu').hasClass('nav-ontop') || $('#header').hasClass('optop')){
                        
                    }else{

                        return false;
                    }
                }
            }
            $(this).closest('.box-vertical-megamenus').find('.vertical-menu-content').slideToggle();
            $(this).closest('.title').toggleClass('active');
            return false;
        })
        /* Product qty */
        $(document).on('click','.btn-plus-down',function(){
            var value = parseInt($('#option-product-qty').val());
            value = value -1;
            if(value <=0) return false;
            $('#option-product-qty').val(value);
            return false;
        })
        $(document).on('click','.btn-plus-up',function(){
            var value = parseInt($('#option-product-qty').val());
            value = value +1;
            if(value <=0) return false;
            $('#option-product-qty').val(value);
            return false;
        })
        /* Close vertical */
        $(document).on('click','*',function(e){
            var container = $("#box-vertical-megamenus");
            if (!container.is(e.target) && container.has(e.target).length === 0){
                if($('body').hasClass('home')){
                    if($('#nav-top-menu').hasClass('nav-ontop')){
                    }else{
                        return;
                    }
                }
                container.find('.vertical-menu-content').hide();
                container.find('.title').removeClass('active');
            }
        })
        /* Send conttact*/
        $(document).on('click','#btn-send-contact',function(){
            var subject = $('#subject').val(),
                email   = $('#email').val(),

                order_reference = $('#order_reference').val(),
                message = $('#message').val();
            var data = {
                subject:subject,
                email:email,
                order_reference:order_reference,
                message:message
            }
            $.post('ajax_contact.php',data,function(result){
                if(result.trim()=="done"){
                    $('#email').val('');
                    $('#order_reference').val('');
                    $('#message').val('');
                    $('#message-box-conact').html('<div class="alert alert-info">Your message was sent successfully. Thanks</div>');
                }else{
                    $('#message-box-conact').html(result);
                }
            })
        })
        // Quick view
        $(document).on('click','.quick-view .search,a.quick-view',function(){
            var id   = $(this).attr('data-id');
			var data = {
				id:id,
            }
            $.post(url_site+'quick_view.html', data, function(response){
                $.fancybox(response, {
                  // fancybox API options
				  width: 1200,
				  height:800,
                  fitToView: false,
                  autoSize: false,
                  closeClick: false,
                  openEffect: 'none',
                  closeEffect: 'none'
                }); // fancybox
                // OWL Product thumb
                $('.product-img-thumb .owl-carousel').owlCarousel(
                    {
                        dots:false,
                        nav:true,
                        navText:['<i class="fa fa-angle-left"></i>','<i class="fa fa-angle-right"></i>'],
                        margin:21,
                        responsive : {
                          // breakpoint from 0 up
                          0 : {
                              items : 2,
                          },
                          // breakpoint from 480 up
                          480 : {
                              items : 2,
                          },
                          // breakpoint from 768 up
                          768 : {
                              items : 2,
                          },
                          1000 : {
                              items : 4,
                          }
                      }
                    }
                );
            })
            return false;
        })
		
		$(document).on('click','.block-quickview .product-img-thumb a',function(){
			var image = $(this).data('image');
			$(this).closest('.product-image').find('.product-full img').attr('src',image);
			return false;
		})

        // Poppup video
        if( $('.video-btn').length > 0){
            $('.video-btn').fancybox();
        }
        // Open form search in header 10
        $(document).on('click','.form-search .icon',function(){
            $(this).closest('.form-search').find('.form-search-inner').fadeIn(600);
            $(this).closest('.form-search').find('.form-search-inner .input-serach input').focus();
        })
        /* Close form search in header 10*/
        $(document).on('click','*',function(e){
            var container = $(".form-search");
            var icon = $(".form-search .icon");
            if (!container.is(e.target) && container.has(e.target).length === 0 && !icon.is(e.target) && icon.has(e.target).length === 0){
                container.find('.form-search-inner').fadeOut(600);
            }
        })

        //SLIDE FULL SCREEN
       var slideSection = $(".slide-fullscreen .item-slide");
        slideSection.each(function(){
            if ($(this).attr("data-background")){
                $(this).css("background-image", "url(" + $(this).data("background") + ")");
            }
        });

        // 
        $(document).on('click','.block-tab-category .bar',function(){
            $(this).toggleClass('active');
            $(this).closest('.block-tab-category').find('.tab-cat').toggleClass('show');
        })
        //testimonial-carousel
        if($('.testimonial-carousel').length >0){
            var owl = $('.testimonial-carousel');
            owl.owlCarousel(
                {
                    margin:30,
                    autoplay:false,
                    dots:false,
                    loop:true,
                    items:3,
                    nav:true,
                    smartSpeed:1000,
                    navText:['<i class="fa fa-angle-left"></i>','<i class="fa fa-angle-right"></i>']
                }
            );
            owl.trigger('next.owl.carousel');
            owl.on('changed.owl.carousel', function(event) {
                owl.find('.owl-item.active').removeClass('item-center');
                var caption=owl.find('.owl-item.active').first().next().find('.info').html();
                owl.closest('.block-testimonials,.block-testimonials2').find('.testimonial-caption').html(caption).addClass('zoomIn animated').one('webkitAnimationEnd mozAnimationEnd MSAnimationEnd oanimationend animationend', function(){
                         $(this).removeClass('zoomIn animated');
                });;
                setTimeout(function(){
                    owl.find('.owl-item.active').first().next().addClass('item-center');
                    owl.find('.owl-item.active').first().next().addClass('zoomIn animated').one('webkitAnimationEnd mozAnimationEnd MSAnimationEnd oanimationend animationend', function(){
                         $(this).removeClass('zoomIn animated');
                    });
                }, 100);
            })

        }
        if($('.testimonial-carousel2').length >0){
            var owl = $('.testimonial-carousel2');
            owl.owlCarousel(
                {
                    margin:0,
                    autoplay:true,
                    dots:false,
                    loop:true,
                    items:3,
                    nav:false,
                    smartSpeed:1000,
                    navText:['<i class="fa fa-angle-left"></i>','<i class="fa fa-angle-right"></i>']
                }
            );
            owl.trigger('next.owl.carousel');
            owl.on('changed.owl.carousel', function(event) {
                owl.find('.owl-item.active').removeClass('item-center');
                var caption=owl.find('.owl-item.active').first().next().find('.info').html();
                owl.closest('.block-testimonials,.block-testimonials2').find('.testimonial-caption').html(caption).addClass('fadeIn animated').one('webkitAnimationEnd mozAnimationEnd MSAnimationEnd oanimationend animationend', function(){
                         $(this).removeClass('fadeIn animated');
                });;
                setTimeout(function(){
                    owl.find('.owl-item.active').first().next().addClass('item-center');
                    owl.find('.owl-item.active').first().next().addClass('fadeIn animated').one('webkitAnimationEnd mozAnimationEnd MSAnimationEnd oanimationend animationend', function(){
                         $(this).removeClass('fadeIn animated');
                    });
                }, 100);
            })
        }
        $('.list-brand').bxSlider({
          mode: 'vertical',
            minSlides: 4,
            maxSlides: 3,
            pager:false,
            useCSS:false
        });

        //
        $(document).on('click','.block-top-brands2 .list-brands a',function(){
            var tab = $(this).attr('href');
            $(this).closest('.list-brands').find('a.tab-nav').each(function(){
                $(this).removeClass('active');
            })
            $(this).addClass('active');
            $(this).closest('.block-top-brands2').find('.brand-products .tab-panel').each(function(){
                $(this).removeClass('active');
            })
            $(tab).addClass('active');
            return false;
        })
    });
    /* ---------------------------------------------
     Scripts resize
     --------------------------------------------- */
    $(window).resize(function(){
        // auto width megamenu
        auto_width_megamenu();
        // Remove menu ontop
        remove_menu_ontop();
        // resize top menu
        resizeTopmenu();
        js_height_full();
    });
    /* ---------------------------------------------
     Scripts scroll
     --------------------------------------------- */
    $(window).scroll(function(){
        resizeTopmenu();
        /* Show hide scrolltop button */
        if( $(window).scrollTop() == 0 ) {
            $('.scroll_top').stop(false,true).fadeOut(600);
        }else{
            $('.scroll_top').stop(false,true).fadeIn(600);
        }
        /* Main menu on top */
        var h = $(window).scrollTop();
        var max_h = $('#header').height() + $('#top-banner').height();
        var width = $(window).width();
        if(width > 991){
            if( h > 45 ){
                $('#header').addClass('optop');
            }else{
                $('#header').removeClass('optop');
            }
            if( h > (max_h + vertical_menu_height)-50){
                // fix top menu
                $('#nav-top-menu').addClass('nav-ontop');
                $('#header').find('.vertical-menu-content').hide();
                //$('#nav-top-menu').find('.title').removeClass('active');
                // add cart box on top menu
                $('#cart-block .cart-block').appendTo('#shopping-cart-box-ontop .shopping-cart-box-ontop-content');
                $('#shopping-cart-box-ontop').fadeIn();
                $('#user-info-top').appendTo('#user-info-opntop');
                $('#header .header-search-box form').appendTo('#form-search-opntop');
            }else{
                $('#nav-top-menu').removeClass('nav-ontop');
                if($('body').hasClass('home')){
                    $('#nav-top-menu').find('.vertical-menu-content').removeAttr('style');
                    if(width > 1024){
                        $('#nav-top-menu').find('.vertical-menu-content').show();
                        $('.home #header').find('.vertical-menu-content').show();
                    }else{
                        $('#nav-top-menu').find('.vertical-menu-content').hide();
                    }
                     $('#nav-top-menu').find('.vertical-menu-content').removeAttr('style');
                }
                ///
                $('#shopping-cart-box-ontop .cart-block').appendTo('#cart-block');
                $('#shopping-cart-box-ontop').fadeOut();
                $('#user-info-opntop #user-info-top').appendTo('.top-header .container');
                $('#form-search-opntop form').appendTo('#header .header-search-box');
            }
        }
    });
    var vertical_menu_height = $('#box-vertical-megamenus .box-vertical-megamenus').innerHeight();
    /**==============================
    ***  Auto width megamenu
    ===============================**/
    function auto_width_megamenu(){
        var full_width = parseInt($('.container').innerWidth());
        //full_width = $( document ).width();
        var menu_width = parseInt($('.vertical-menu-content').actual('width'));
        $('.vertical-menu-content').find('.vertical-dropdown-menu').each(function(){
            $(this).width((full_width - menu_width)-270);
        });
    }
    /**==============================
    ***  Remove menu on top
    ===============================**/
    function remove_menu_ontop(){
        var width = parseInt($(window).width());
        if(width < 768){
            $('#nav-top-menu').removeClass('nav-ontop');
            if($('body').hasClass('home')){
                if(width > 1024)
                    $('#nav-top-menu').find('.vertical-menu-content').show();
                else{
                    $('#nav-top-menu').find('.vertical-menu-content').hide();
                }
            }
            ///
            $('#shopping-cart-box-ontop .cart-block').appendTo('#cart-block');
            $('#shopping-cart-box-ontop').fadeOut();
            $('#user-info-opntop #user-info-top').appendTo('.top-header .container');
            $('#form-search-opntop form').appendTo('#header .header-search-box');
        }
    }
    /* Top menu*/
    function scrollCompensate(){
        var inner = document.createElement('p');
        inner.style.width = "100%";
        inner.style.height = "200px";
        var outer = document.createElement('div');
        outer.style.position = "absolute";
        outer.style.top = "0px";
        outer.style.left = "0px";
        outer.style.visibility = "hidden";
        outer.style.width = "200px";
        outer.style.height = "150px";
        outer.style.overflow = "hidden";
        outer.appendChild(inner);
        document.body.appendChild(outer);
        var w1 = parseInt(inner.offsetWidth);
        outer.style.overflow = 'scroll';
        var w2 = parseInt(inner.offsetWidth);
        if (w1 == w2) w2 = outer.clientWidth;
        document.body.removeChild(outer);
        return (w1 - w2);
    }

    function resizeTopmenu(){
        if($(window).width() + scrollCompensate() >= 768){
            var main_menu_w = $('#main-menu .navbar').innerWidth();

            if($('#main-menu').hasClass('menu-option9') || $('#main-menu').hasClass('menu-option10') || $('#main-menu').hasClass('menu-option11') || $('#main-menu').hasClass('menu-option14')){
                return false;
            }

            $("#main-menu ul.mega_dropdown").each(function(){
                var menu_width = $(this).innerWidth();
                var offset_left = $(this).position().left;
                if(menu_width > main_menu_w){
                    $(this).css('width',main_menu_w+'px');
                    $(this).css('left','0');
                }else{
                    if((menu_width + offset_left) > main_menu_w){
                        var t = main_menu_w-menu_width;
                        var left = parseInt((t/2));
                        $(this).css('left',left);
                    }
                }
            });
        }

        if($(window).width()+scrollCompensate() < 1025){
            $("#main-menu li.dropdown:not(.active) >a").attr('data-toggle','dropdown');
        }else{
            $("#main-menu li.dropdown >a").removeAttr('data-toggle');
        }
    }
    /* ---------------------------------------------
     Height Full
     --------------------------------------------- */
    function js_height_full(){
        (function($){
            var heightSlide = $(window).outerHeight();
            $(".full-height").css("height",heightSlide);
        })(jQuery);
    }
	
	function share_facebook() {
        u = location.href;
        t = document.title;
        window.open('http://www.facebook.com/sharer.php?u=' + encodeURIComponent(u) + '&t=' + encodeURIComponent(t), 'sharer', ',width=980,height=600');
        return false;
    }

    function share_twitter() {
        var uvnn = location.href;
        var tvnn = document.title;
        window.open("http://twitter.com/home?status=" + encodeURIComponent(uvnn));
    }

    function share_google() {
        u = location.href;
        t = document.title;
        window.open("https://www.google.com/bookmarks/mark?op=add&bkmk=" + encodeURIComponent(u) + "&title=" + encodeURIComponent(t));
    }
	function share_zing() {
			u = location.href;
			t = document.title;
			window.open("http://link.apps.zing.vn/pro/view/conn/share?fl=&u=" + encodeURIComponent(u) + "&t=" + encodeURIComponent(t) + "&desc=" + encodeURIComponent(t));
	}
	
	

	
})(jQuery); // End of use strict