$(function() {
		 var  subnavTimer;

	$(".headNav li").hover(function() {
		clearInterval(subnavTimer);
		var index = $(this).index();
		if (index == 0) {
			$(".headNav li").removeClass("cur");
			$(".subNav div[dataType=subnav]").hide();
			return;
		}
		$(this).addClass("cur").siblings("li").removeClass("cur");
	  
		$(".subNav div[dataType=subnav]").eq(index).slideDown(300).siblings("div[dataType=subnav]").stop().hide();
	}, function() {
		var that = $(this);
		subnavTimer = setTimeout(function() {
			var index = that.index();
			that.removeClass("cur");
			$(".subNav div[dataType=subnav]").eq(index).hide();
			//$("#" + curNavId).addClass("cur");
		}, 100);
	});

	$(".subNav div[dataType=subnav]").hover(function() {
		clearInterval(subnavTimer);
	}, function() {
		var that = $(this);
		subnavTimer = setTimeout(function() {
			var index = that.index();

			$(".headNav li").eq(index).removeClass("cur");
			//$("#" + curNavId).addClass("cur");
			that.hide();
		}, 100);
	});
	// $(".subNav .cont2 .title li").mouseover(function() {
	// 	$(this).addClass("cur").siblings("li").removeClass("cur");
	// 	var index = $(this).index();
	// 	$("http://www.nbjy.org.cn/Content/js/.subNav .cont2 .list").hide().eq(index).show();
	// });
})


Date.prototype.format = function (format) //author: meizz
{
    var o = {
        "yy+": this.getYear(),//year
        "M+": this.getMonth() + 1, //month
        "d+": this.getDate(),    //day
        "h+": this.getHours(),   //hour
        "m+": this.getMinutes(), //minute
        "s+": this.getSeconds(), //second
        "q+": Math.floor((this.getMonth() + 3) / 3),  //quarter
        "S": this.getMilliseconds() //millisecond
    }
    if (/(y+)/.test(format)) format = format.replace(RegExp.$1,
    (this.getFullYear() + "").substr(4 - RegExp.$1.length));
    for (var k in o) if (new RegExp("(" + k + ")").test(format))
        format = format.replace(RegExp.$1,
      RegExp.$1.length == 1 ? o[k] :
        ("00" + o[k]).substr(("" + o[k]).length));
    return format;
}
