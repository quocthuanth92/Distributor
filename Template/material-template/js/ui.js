$(document).ready(function() {
	checkNav();
	checkScreen();
	checkTheme();
	checkScreenMode();
	checkTableFixed();
	setThumbScroller();
	setTabContentHeight();
	setMapOptionHeight();
	setMapOptionConentHeight();
	$(window).resize(function(resize) {
		if (resize.isTrigger !== 3) {
			checkNav();
			checkScreen();
			checkTableFixed();
			checkScheduleHeight();
			setThumbScroller();
			setTabContentHeight();
			setMapOptionHeight();
			setMapOptionConentHeight();
		}
		if (!fullScreenApi.isFullScreen()) {
            $('body').removeClass('fullscreen');
        } else {
			$('body').addClass('fullscreen');
		}
	});
	
	if ($('.monthpicker').length) {
		var d = new Date();
		var maxYear = d.getFullYear();
		var minYear = maxYear - 10;
		$('.monthpicker').monthpicker({
			minYear: minYear,
			maxYear: maxYear,
		});
	}
	
	if($('*').hasClass('draggable')) {
		$('.draggable').draggable();
	}
	if($('.tab-content table').hasClass('tablesorter')) {
		$('.tab-content .tablesorter').not('.no-dragtable').dragtable();
	}
	$('.btn-edit').click(function() {
		$('.sortable li, table tr').removeClass('selected');
		$(this).closest('table').find('tr').removeClass('selected');
		$(this).closest('li, tr').addClass('selected');
	});
	
	$('.type').change(function() {
		target = $(this).attr('data-target');
		if (target == '#routine') {
			$('#sale-area-treeview').hide();
		} else {
			$('#sale-area-treeview').show();
		}
	});
	$('.btn-map-note').click(function() {
		setMapOptionHeight();
	});
	$('a[data-toggle="tab"]').click(function(){
		$.tablesorter.window_resize();
	});
	
	/* Navigation status */
	$('.menu-box').on('click', '.btn-navigation', function() {
		if ($('html').hasClass('nav-mini')) {
			$('html').removeClass('nav-mini');
		} else {
			$('html').addClass('nav-mini');
		}
		// Check tablesorter width
		setTimeout(function(){
			$.tablesorter.window_resize();
		}, 700);
		
		//nav_width = $('')
	});
	$('.navigation ul li a').click(function() {
		is_active = 0;
		if ($(this).hasClass('active')) {
			is_active = 1;
		}
		$('.navigation ul li a').removeClass('active');
		if (!is_active) {
			$(this).addClass('active');
		}
		setTimeout(function() {
			checkNav();
		}, 300);
		
	});
	$('.content *, .header').click(function() {
		if ($('html').hasClass('nav-mini')) {
			$('.navigation a').removeClass('active');
		}
	});
	$('.content *').click(function() {
		if ($(window).width() < 1170 && !$('html').hasClass('nav-mini')) {
			$('html').addClass('nav-mini');
		}
	});
	
	/* Notice toggle */
	$('.notice>a').click(function() {
		if (!$(this).hasClass('active')) {
			$(this).addClass('active');
		} else {
			$(this).removeClass('active');
		}
	});
	$('.notice .btn-close').click(function(){
		$(this).closest('.notice').find('a.active').removeClass('active');
	});
	
	/* Change theme color */
	$('.circle').click(function(){
		theme = $(this).attr('theme');
		$('body').removeClass('red orange yellow cyan blue magenta');
		$('body').addClass(theme);
		$.cookie('theme', theme, { expires: 7, path: '/' });
	});
	
	/* Toggle box */
	$('.toggle-button').click(function() {
		temp = $(this);
		if ($(this).closest('.toggle-box').hasClass('disable')) {
			$(this).closest('.toggle-box.disable').removeClass('disable');
		} else {
			$(this).closest('.toggle-box').find('.toggle-content').height('auto');
			setTimeout(function() {
				$(temp).closest('.toggle-box').addClass('disable');
			}, 300);	
		}
		setTimeout(function() {
				checkTableFixed();
				setTabContentHeight();
				//setTableContentHeight();
				$.tablesorter.window_resize();
			}, 600);	
		
	});
	
	/* Map option */
	$('.map-option-toggle').click(function() {
		if (!$(this).closest('.map-option-full').hasClass('disable')) {
			$(this).closest('.map-option-full').addClass('disable');
		} else {
			$(this).closest('.map-option-full').removeClass('disable');
		}
		
	});
	$('.map-toggle-left').click(function() {
		$(this).closest('.map-option-full').removeClass('right');
		if (!$(this).closest('.map-option-full').hasClass('left')) {
			$(this).closest('.map-option-full').addClass('left');
		}
		map_option_docked = 'left';
		$.cookie('map_option_docked', map_option_docked, { expires: 7, path: '/' });
	});
	$('.map-toggle-right').click(function() {
		$(this).closest('.map-option-full').removeClass('left');
		if (!$(this).closest('.map-option-full').hasClass('right')) {
			$(this).closest('.map-option-full').addClass('right');
		}
	});
	
	/* Map bottom toggle */
	$('.map-bottom-toggle').click(function() {
		if (!$(this).closest('.map-bottom').hasClass('disable')) {
			$(this).closest('.map-bottom').addClass('disable');
		} else {
			$(this).closest('.map-bottom').removeClass('disable');
		}
		
	});
	
	/* Toggle family */
	$('.toggle-family-button').click(function() {
		current_id = $(this).attr('pinid');
		if ($(this).closest('.toggle-family').hasClass('disable')) {
			$(this).closest('.toggle-family').removeClass('disable');
		} else {
			$(this).closest('.toggle-family').addClass('disable');
		}
		$('.toggle-child').removeClass('enable');
		$.each($('.toggle-child'), function() {
			if ($(this).attr('id') == current_id) {
				$(this).addClass('enable');
			}
		});
	});
	
	
	/* Full screen toggle */
	$('.btn-screenmode').click(function() {
		if ($('body').hasClass('fullscreen')) {
			$('body').removeClass('fullscreen');
			fullscreen = 0;
			fullScreenApi.cancelFullScreen(document.documentElement);
		} else {
			$('body').addClass('fullscreen');
			fullscreen = 1;
			fullScreenApi.requestFullScreen(document.documentElement);
		}
		$.cookie('fullscreen', fullscreen, { expires: 7, path: '/' });
	});
	
	/* Report master */
	$('.font-family').change(function() {
		value = $('.font-family option:selected').val();
		$('.content-body').attr('font-family', value);
	});
	$('.font-size').change(function() {
		value = $('.font-size option:selected').val();
		$('.content-body').attr('font-size', value);
	});
	$('.align').click(function() {
		align = $(this).attr('align');
		$('.content-body').removeClass('align-left align-center align-right');
		$('.content-body').addClass('align-' + align);
	});
	
	/* Rotate image */
	$('.clockwise').click(function() {
		if (!$(this).hasClass('block')) {
			$(this).addClass('block');
			setImageRoller($(this));
			$(this).closest('.img-big-box').find('.img-big-insider img').css({'transform':'rotate(' + (img_degree + 90) + 'deg)'});
			$(this).removeClass('block');
		}
		
	});
	$('.counter-clockwise').click(function() {
		if (!$(this).hasClass('block')) {
			$(this).addClass('block');
			setImageRoller($(this));
			$(this).closest('.img-big-box').find('.img-big-insider img').css({'transform':'rotate(' + (img_degree - 90) + 'deg)'});
			$(this).removeClass('block');
		}
	});
	
	/* Customize column selector */
	$('.zoom-button').click(function() {
		if (!$(this).closest('.zoom-box').hasClass('zoom-in')) {
			$(this).closest('.zoom-box').addClass('zoom-in');
		} else {
			$(this).closest('.zoom-box').removeClass('zoom-in');
		}
		
	});
	
	/* Refresh page */
	$('.btn-refresh').click(function() {
		
		location.reload();
	});
	
	/* Check all */
	$('.check-all').click(function(e) {
		//e.preventDefault();
		current_value = $(this).prop('checked');
		$(this).closest('.tab-content').find('[type="checkbox"]').prop('checked', current_value);
		$(this).closest('td').click();
	});
	$('.check-all').change(function() {
		//$(this).closest('label').click();
		//current_value = $(this).prop('checked');
		//$(this).closest('.tab-content').find('[type="checkbox"]').prop('checked', current_value);
		//$.tablesorter.trigger('updateAll', true);
		//$('table').droppable();
		//return true;
	});
	
	/* Kendo customize */
	$('body').on('click', '.k-widget.k-dropdown.k-header, .k-edit-field, .k-link', function () {
		$(this).removeClass('k-state-border-up k-state-border-down');
		$(this).find('*').removeClass('k-state-border-up k-state-border-down');
		position = $(this).offset();
		$('.k-animation-container').css({'top':position.top + $(this).height()});
	});
	
	/* Test language */
	$('body').on('click', '.language>div a', function() {
		//alert(12);
	});
	
	/* Filter toggle */
	$('.toggle-filter-button').click(function() {
		if ($(this).closest('.toggle-filter-box').hasClass('filter-disable')) {
			$(this).closest('.toggle-filter-box').removeClass('filter-disable');
		} else {
			$(this).closest('.toggle-filter-box').addClass('filter-disable');
		}
	});
	
	/* Customize bootstrap input group */
	$('.input-group>input[type="text"]').on('click', function() {
		$(this).closest('.input-group').find('.input-group-btn button').click();
		return false;
	});
	$('.dropdown-menu thead *').on('click', function() {
		//$(this).closest('.input-group').find('.input-group-btn button').click();
		return false;
	});
	
	/* Customize column selector */
	$('.columnSelector button').click(function() {
		if ($(this).closest('.dropdown')) {
			$(this).closest('.dropdown').focus();
			return false;
		}
	});
	$('body').on('click', '.columnSelector label', function() {

		//$(this).find('>input').click();
	});
	$('body').on('click', '.columnSelector input', function() {
		//$(this).find('>input').click()
		$(this).closest('.dropdown').find('>button').click();
	});
	
	/* Customize table row */
	$('table:not(".noselect") tbody tr').click(function() {
		if ($(this).closest('.input-group').hasClass('multiselect')) {
			$(this).index() ? isFirst = false : isFirst = true; 
			$(this).clickTable($(this), isFirst);
			$(this).autoComplete($(this).closest('.input-group').find('tr.selected'), $(this).closest('.input-group').find('input[class="form-control"]'), isFirst);
		} else if (!$(this).closest('.input-group').hasClass('multiselect')) {
			$(this).clickTable($(this), isFirst);
			$(this).autoComplete($(this), $(this).closest('.input-group').find('input[class="form-control"]'), isFirst);
		}
		if (!$(this).parents('.tab-content').length && $(this).parents('.tablesorter').length) {
			return false;
		}
		
	});

	/* Customize tab bootstrap for column selector */
	$('.nav li a').click(function() {
		current_href = $(this).attr('href');
		columnSelectorBox = $(current_href).find('.tablesorter').attr('columnSelectorBox');
		$('#columnSelector div').removeClass('active');
		$('#columnSelector' + ' #' +  columnSelectorBox).addClass('active');
	});
	
	/* Toggle bigdata */
	/*
	$('btn-bigdata').click(function() {
		if($('.bigdata-box').hasClass('disable')) {
			$('.bigdata-box').removeClass('disable');
		} else {
			$('.bigdata-box').addClass('disable');
		}
	});
	*/
	


	/* Customize bootstrap dropdown for columnSelector */
	(function($){
		$.fn.extend({ 
			//plugin name
			autoComplete: function(options, input, isFirst) {
				selected = [''];
				row_key = 0;
				//if ($(this).closest('.dropdown_menu .tablesorter tbody tr')) {
					$(input).val('');
					$(options).each(function(row_key, object){
						$(object).find('td').each(function(col_key, value){
							if (!col_key) {
								selected[row_key] = '';
							}
							if (!selected[row_key]) {
								selected[row_key] += $(value).text();
							} else {
								selected[row_key] += " - " + $(value).text();
							}
						});
						if (!$(input).parents('div').hasClass('input-group') || !$(input).closest('.input-group').hasClass('multiselect')) {
							if (!$(object).hasClass('selected')) {
								$(input).closest('.input-group').find('input').val('');
							} else {
								$(input).val(selected[row_key]);
							}
						} else if ($(input).closest('.input-group').hasClass('multiselect')) {
							if (isFirst) {
								$(input).val(selected[row_key]);
							} else if (!$(input).val()) {
								$(input).val(selected[row_key]);
							} else {
								$(input).val($(input).val() + '; ' + selected[row_key]);
							}
						}
						
					});
					
				//}
				//return false;
			},
			clickTable: function(row, isFirst) {
				if (!$(row).closest('table').hasClass('tbl-transparent') && !$(row).closest('table').hasClass('table-raw')) {
					if (!$(row).parents('div').hasClass('input-group') || !$(row).closest('.input-group').hasClass('multiselect')) {
						if (!$(row).hasClass('selected')) {
							$(row).closest('table').find('tr').removeClass('selected');
							$(row).addClass('selected');
						} else {
							$(row).removeClass('selected');
						}
						
					} else if ($(row).closest('.input-group').hasClass('multiselect')){
						if (isFirst) {
							if (!$(row).hasClass('selected')) {
								$(row).closest('table').find('tr').removeClass('selected');
								$(row).addClass('selected');
							} else {
								$(row).closest('table').find('tr').removeClass('selected');
							}
						} else {
							$(row).closest('table').find('tr:first-child').removeClass('selected');
							if (!$(row).hasClass('selected')) {
								$(row).addClass('selected');
							} else {
								$(row).removeClass('selected');
							}
						}
					}
					$.tablesorter.window_resize();
				}
				
				//return false;
			}
		});
	})(jQuery);

	/* Full Screnn API */
	(function() {
		var
			fullScreenApi = {
				supportsFullScreen: false,
				nonNativeSupportsFullScreen: false,
				isFullScreen: function() { return false; },
				requestFullScreen: function() {},
				cancelFullScreen: function() {},
				fullScreenEventName: '',
				prefix: ''
			},
			browserPrefixes = 'webkit moz o ms khtml'.split(' ');
	 
		// check for native support
		if (typeof document.cancelFullScreen != 'undefined') {
			fullScreenApi.supportsFullScreen = true;
		} else {
			// check for fullscreen support by vendor prefix
			for (var i = 0, il = browserPrefixes.length; i < il; i++ ) {
				fullScreenApi.prefix = browserPrefixes[i];
	 
				if (typeof document[fullScreenApi.prefix + 'CancelFullScreen' ] != 'undefined' ) {
					fullScreenApi.supportsFullScreen = true;
	 
					break;
				}
			}
		}
	 
		// update methods to do something useful
		if (fullScreenApi.supportsFullScreen) {
			fullScreenApi.fullScreenEventName = fullScreenApi.prefix + 'fullscreenchange';
	 
			fullScreenApi.isFullScreen = function() {
				switch (this.prefix) {
					case '':
						return document.fullScreen;
					case 'webkit':
						return document.webkitIsFullScreen;
					default:
						return document[this.prefix + 'FullScreen'];
				}
			}
			fullScreenApi.requestFullScreen = function(el) {
				return (this.prefix === '') ? el.requestFullScreen() : el[this.prefix + 'RequestFullScreen']();
			}
			fullScreenApi.cancelFullScreen = function(el) {
				return (this.prefix === '') ? document.cancelFullScreen() : document[this.prefix + 'CancelFullScreen']();
			}
		}
		else if (typeof window.ActiveXObject !== "undefined") { // IE.
			fullScreenApi.nonNativeSupportsFullScreen = true;
			fullScreenApi.requestFullScreen = fullScreenApi.requestFullScreen = function (el) {
					var wscript = new ActiveXObject("WScript.Shell");
					if (wscript !== null) {
						wscript.SendKeys("{F11}");
					}
			}
			fullScreenApi.isFullScreen = function() {
					return document.body.clientHeight == screen.height && document.body.clientWidth == screen.width;
			}
		}
	 
		// jQuery plugin
		if (typeof jQuery != 'undefined') {
			jQuery.fn.requestFullScreen = function() {
	 
				return this.each(function() {
					if (fullScreenApi.supportsFullScreen) {
						fullScreenApi.requestFullScreen(this);
					}
				});
			};
		}
	 
		// export api
		window.fullScreenApi = fullScreenApi;
	})();
	


});

/* Set image roller */
img_degree = 0;
is_Vertical = [true, true];
function setImageRoller(obj) {
	img_height = $(obj).closest('.img-big-box').find('.img-big-insider img').height();
	img_width = $(obj).closest('.img-big-box').find('.img-big-insider img').width();
	img_degree = $(obj).closest('.img-big-box').find('.img-big-insider img').rotationInfo().deg;
	if (img_degree > -315 && img_degree <= -225) {
		img_degree = -270;
	} else if (img_degree > -225 && img_degree <= -135) {
		img_degree = -180;
	} else if (img_degree > -135 && img_degree <= -45) {
		img_degree = -90;
	} else if (img_degree > -45 && img_degree <= 45) {
		img_degree = 0;
	} else if (img_degree > 45 && img_degree <= 135) {
		img_degree = 90;
	} else if (img_degree > 135 && img_degree <= 225) {
		img_degree = 180;
	} else if (img_degree > 225 && img_degree <= 315) {
		img_degree = 270;
	} else {
		img_degree = 0;
	}
	if ($(obj).closest('.img-big-box').hasClass('img-current-template')) {
		temp = 0;
	} else {
		temp = 1;
	}
	if (is_Vertical[temp] = !is_Vertical[temp]) {
		$(obj).closest('.img-big-box').find('img').css({'width':'100%', 'max-height':'none', 'margin-right':0});
	} else {
		$(obj).closest('.img-big-box').find('img').css({'width':'auto', 'max-height':img_width, 'margin-right':-70});
	}
}

/* Set Height of Tab Content */
function setTabContentHeight() {
	if($('.tab-content').hasClass('tab-fixed')) {
		content_insider_height = $('.content>.insider').height();
		content_header_height = $('.content-header').height() ? $('.content-header').height() : 0;
		content_footer_height = $('.content-footer').height() ? $('.content-footer').height() : 0;
		tab_header_height = $('.tab-header').height();
		tab_content_height = content_insider_height - content_header_height - content_footer_height - tab_header_height - 20;
		if (tab_content_height > 100 && $('.content .insider').width() > 750) {
			$('.tab-content').height(tab_content_height);
		} else {
			$('.tab-content').height('auto');
		}
	}
	
}

/* Set Height of Table Content */
function setTableContentHeight() {
	$('.table-box').each(function(key, value){
		if($(this).hasClass('table-fixed-height')) {
			content_insider_height = $('.content>.insider').height();
			content_header_height = $('.content-header').height() ? $('.content-header').height() : 0;
			content_footer_height = $('.content-footer').height() ? $('.content-footer').height() : 0;
			table_header_height = $('.table-header').height();
			table_content_height = content_insider_height - content_header_height - content_footer_height - 20;
			if (table_content_height > 100 && $('.content-insider').width() > 750) {
				$(this).css({'max-height':table_content_height});
			} else {
				$(this).css({'max-height':'none'});
			}
		}
	});
}

/* Check and set height of table box */
function checkTableFixed() {
	if ($('.hover-content').hasClass('wrapper')) {
		content_insider_height = $('.content>.insider').height();
		content_header_height =  $('.content-header').height() ? $('.content-header').height() : 0;
		content_footer_height = 0;
		if ($('div').hasClass('content-footer')) {
			content_footer_height = $('.content-footer').height();
		}
		//console.log(content_body_title_height);
		table_fixed_height = content_insider_height - content_header_height - content_footer_height;
		if (table_fixed_height > 200 && $('.content .insider').width() > 750) {
			$('.hover-content').css({'max-height':table_fixed_height});
		} else {
			$('.hover-content').css({'max-height':'none'});
		}
	}
	if ($('.tool-box').hasClass('tool-wrapper')) {
		content_insider_height = $('.content>.insider').height();
		content_header_height =  $('.content-header').height() ? $('.content-header').height() : 0;
		content_footer_height = 0;
		if ($('div').hasClass('content-footer')) {
			content_footer_height = $('.content-footer').height();
		}
		tool_box_height = content_insider_height - content_header_height - content_footer_height - 50;
		if (tool_box_height > 150 && $('.content .insider').width() > 750) {
			$('.tool-box').css({'max-height':tool_box_height});
		} else {
			$('.tool-box').css({'max-height':'none'});
		}
	}
	if ($('.table-box').hasClass('table-wrapper')) {
		content_insider_height = $('.content>.insider').height();
		content_header_height =  $('.content-header').height() ? $('.content-header').height() : 0;
		content_footer_height = 0;
		if ($('div').hasClass('content-footer')) {
			content_footer_height = $('.content-footer').height();
		}
		//console.log(content_body_title_height);
		table_fixed_height = content_insider_height - content_header_height  - 30 ;
		
		$.each($('.table-box.table-wrapper'), function() {
			if ($(this).attr('freeze')) {
				freeze = $(this).attr('freeze');
				$(this).find('>table').tablesorter({
					headerTemplate : '{content} {icon}', // Add icon for various themes
					widgets: ['uitheme', 'zebra', 'stickyHeaders', 'scroller'],
					widgetOptions: {
						scroller_fixedColumns : freeze,
						stickyHeaders_attachTo : '.table-wrapper', // or $(this).closest('.table-wrapper')
					}
				});
			} else {
				$(this).find('>table').tablesorter({
					headerTemplate : '{content} {icon}', // Add icon for various themes
					widgets: ['uitheme', 'zebra', 'stickyHeaders', 'filter'],
					
					widgetOptions: {
						stickyHeaders_attachTo : '.table-wrapper', // or $(this).closest('.table-wrapper')
					}
				});
			}
			if ($(this).parent('div').find('.table-footer').length && !$(this).closest('.calculated').length) {
				footer_height = $(this).parent('div').find('.table-footer').height();
				$(this).closest('.table-wrapper').css({'padding-bottom':footer_height, 'margin-bottom':0-footer_height-2});
				$(this).closest('.table-wrapper').addClass('calculated');
				//console.log(max_height);
			}
		});
		
		/* Check table height */
		if (table_fixed_height > 200 && $('.content .insider').width() > 750) {
			$('.table-box').css({'max-height':table_fixed_height});
		} else {
			$('.table-box').css({'max-height':'auto'});
		}
	}
	if ($('.tab-content').hasClass('wrapper')) {
		freeze = parseInt($('.tab-content').attr('freeze'));
		content_insider_height = $('.content>.insider').height();
		content_header_height =  $('.content-header').height() ? $('.content-header').height() : 0;
		tab_header_height = $('.tab-header').height();
		content_footer_height = 0;
		if ($('div').hasClass('content-footer')) {
			content_footer_height = $('.content-footer').height();
		}
		table_fixed_height = content_insider_height - content_header_height - tab_header_height - content_footer_height - 20 ;
		sticky_header_height = $('.tablesorter-scroller>.tablesorter-scroller-header').height();
		$.each($('.tab-content .tablesorter'), function() {
			if (freeze) {
				
				$(this).tablesorter({
					headerTemplate : '{content} {icon}', // Add icon for various themes
					widgets: ['uitheme', 'zebra', 'stickyHeaders', 'scroller'],
					widgetOptions: {
						/*scroller_height: table_fixed_height,*/
						scroller_fixedColumns : freeze,
						stickyHeaders_attachTo : '.wrapper', // or $('.wrapper')
					}
				});
			} else {
				if ($(this).attr('columnSelectorBox')) {
					columnSelectorBox = $(this).attr('columnSelectorBox');
				} else {
					columnSelectorBox  = "columnSelector";
				}
				$(this).tablesorter({
					headerTemplate : '{content} {icon}', // Add icon for various themes
					widgets: ['uitheme', 'zebra', 'stickyHeaders', 'filter', 'resizable', 'columnSelector'],
					widgetOptions: {
						resizable: true,
						stickyHeaders_attachTo : '.wrapper', // or $('.wrapper')
						storage_storageType: 's', // use first letter (s)ession
						resizable_addLastColumn : true,
						
						columnSelector_container : $('#' + columnSelectorBox),
						// column status, true = display, false = hide
						// disable = do not display on list
						columnSelector_columns : {
						 //0: 'disable' // set to disabled; not allowed to unselect it
						},
						// remember selected columns (requires $.tablesorter.storage)
						columnSelector_saveColumns: false,

						// container layout
						columnSelector_layout : '<label><input type="checkbox">{name}</label>',
						// layout customizer callback called for each column
						// function($cell, name, column){ return name || $cell.html(); }
						columnSelector_layoutCustomizer : null,
						// data attribute containing column name to use in the selector container
						columnSelector_name  : 'data-selector-name',

						// Responsive Media Query settings
						// enable/disable mediaquery breakpoints
						columnSelector_mediaquery: false,
						// toggle checkbox name
						columnSelector_mediaqueryName: 'Auto',
						// breakpoints checkbox initial setting
						columnSelector_mediaqueryState: false,
						// hide columnSelector false columns while in auto mode
						columnSelector_mediaqueryHidden: false,

						// set the maximum and/or minimum number of visible columns; use null to disable
						columnSelector_maxVisible: null,
						columnSelector_minVisible: null,
						// responsive table hides columns with priority 1-6 at these breakpoints
						// see http://view.jquerymobile.com/1.3.2/dist/demos/widgets/table-column-toggle/#Applyingapresetbreakpoint
						// *** set to false to disable ***
						columnSelector_breakpoints : [ '20em', '30em', '40em', '50em', '60em', '70em' ],
						// data attribute containing column priority
						// duplicates how jQuery mobile uses priorities:
						// http://view.jquerymobile.com/1.3.2/dist/demos/widgets/table-column-toggle/
						columnSelector_priority : 'data-priority',

						// class name added to checked checkboxes - this fixes an issue with Chrome not updating FontAwesome
						// applied icons; use this class name (input.checked) instead of input:checked
						columnSelector_cssChecked : 'checked'
	  
					}
					 
				});
				$('.tab-content .tablesorter').trigger('refreshColumnSelector');
				
				
				/**
				  * Bootstrap popover demo ***/

					/*
					  // initialize column selector using default settings
					  // note: no container is defined!
					  $(".bootstrap-popup").tablesorter({
						theme: 'blue',
						widgets: ['zebra', 'columnSelector', 'stickyHeaders']
					  });

					  // call this function to copy the column selection code into the popover
					  $.tablesorter.columnSelector.attachTo( $('.bootstrap-popup'), '#popover-target');

					  $('#popover')
						.popover({
						  placement: 'right',
						  html: true, // required if content has HTML
						  content: $('#popover-target')
						});
					*/
			}
		});
		
		//Check height of tablesorter
		$('.tablesorter-scroller>.tablesorter-scroller-table').css({'height':table_fixed_height - 90, 'max-height':'none'});
		
		if (table_fixed_height > 100 && $('.content .insider').width() > 750) {
			$('.tab-content').height(table_fixed_height);
			scroller_height = table_fixed_height - 70;
		} else {
			$('.tab-content').height('auto');
			scroller_height = null;
		}
	}
	/*
	setTimeout(function() {
		tab_content_width = $('.tab-content').width();
		table_fixed_width = $('.tablesorter-scroller>div>.tablesorter-scroller-table>table').width();
		table_scroll_width = tab_content_width - table_fixed_width;
		//$('.tablesorter-scroller>.tablesorter-scroller-header').width(table_scroll_width);
		//$('.tablesorter-scroller>.tablesorter-scroller-table').width(table_scroll_width);
		//$('.tablesorter-scroller-table').height(scroller_height);
		console.log(tab_content_width);
		console.log(table_fixed_width);
	}, 500);
	*/
}

/* Check fullscreen mode */
function checkScreenMode() {
	if ($.cookie('fullscreen')) {
		//$('body').addClass('fullscreen');
	}
}

/* Check navigation height */
navbox_height = $('.nav-box>ul').height();
function checkNav() {
	var submenu_height = $('.navigation').height() - navbox_height - 230;
	$('.navigation ul li a.active+ul').css({'max-height':submenu_height});
}

/* Check to set navigation status belong to width of screen */
function checkScreen() {
	var screen_width = $(window).width();
	if (!$('html').hasClass('nav-mini') && screen_width <= 970) {
		$('html').addClass('nav-mini');
	}
	if ($('html').hasClass('nav-mini') && screen_width > 970) {
		//$('html').removeClass('nav-mini');
	} 
}

/* Check and set theme by cookie */
function checkTheme() {
	if (theme = $.cookie('theme')) {
		$('body').removeClass('red orange yellow cyan blue magenta');
		$('body').addClass(theme);
	}
	if (map_option_docked = $.cookie('map_option_docked')) {
		$('.map-option-full').addClass(map_option_docked);
	}
}

/* Scheduler resize */
scheduler_height = 500;
function checkScheduleHeight() {
	if ($('.content .insider div').hasClass('scheduler')) {
		content_insider_height = $('.content .insider').height();
		content_header_height =  $('.content-header').height() ? $('.content-header').height() : 0;
		scheduler_height = content_insider_height - content_header_height - 60;
		
		//$('.k-scheduler-times:nth-child(2)').height(scheduler_height - 150);
		//$('.k-scheduler-content').height(scheduler_height - 100);
		//$('.k-scheduler-table').height(scheduler_height - 50);
		if (scheduler_height > 100 && $('.content .insider').width() > 750 ) {
			$('.scheduler').height(scheduler_height);
		} else {
			$('.scheduler').height(auto);
		}
	}
}

/* Rotate info */
$.fn.rotationInfo = function() {
    var el = $(this),
        tr = el.css("-webkit-transform") || el.css("-moz-transform") || el.css("-ms-transform") || el.css("-o-transform") || '',
        info = {rad: 0, deg: 0};
    if (tr = tr.match('matrix\\((.*)\\)')) {
        tr = tr[1].split(',');
        if(typeof tr[0] != 'undefined' && typeof tr[1] != 'undefined') {
            info.rad = Math.atan2(tr[1], tr[0]);
            info.deg = parseFloat((info.rad * 180 / Math.PI).toFixed(1));
        }
    }
    return info;
};

/* Set thumb scroller */
function setThumbScroller() {
	if($('div').hasClass('img-scroll-box')) {
		$.each($('.img-scroll-box'), function() {
			img_item = $(this).find('img').length;
			img_width = $(this).find('.img-mini-box').width();
			$(this).find('ul').width(img_item * (img_width + 10));
		});
	}
}

/*Set map option height */
function setMapOptionHeight() {
	if ($('.content .insider div').hasClass('map-option')) {
		content_insider_height = $('.content .insider').height();
		block_header_height = $('.block-header').height();
		block_content_header_height = $('.block-content-header').height();
		map_note_height = $('.map-note').height() ? 20 : 50;
		$('.block-content-body').css({'max-height':content_insider_height - block_header_height - block_content_header_height - map_note_height - 100});
	}
}

/* Set map option content height */
function setMapOptionConentHeight() {
	if ($('.content .insider div').hasClass('map-option-full')) {
		map_option_height = $('.map-option-full').height();
		map_option_header_height = $('.map-option-full .map-option-header').height();
		map_option_content_height = $('.map-option-full .map-option-content').height(map_option_height - map_option_header_height);
	}
}

