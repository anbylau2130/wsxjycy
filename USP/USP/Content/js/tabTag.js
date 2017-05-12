// JavaScript Document 
function set(name,cursel,n){
	  for(i=1;i<=n;i++){
	  var menu=document.getElementById(name+i);
	  var con=document.getElementById(name+"_"+i);
	  menu.className=i==cursel?"current":"";
	  con.style.display=i==cursel?"block":"none";
	} 
  }
 function showList(id,num){
	if(num == 1){
		document.getElementById(id).style.display = "block";
	}
	else{
		document.getElementById(id).style.display = "none";
	}
 }
 
 //load data 2014-8-19 add by drt
 var sys_cacheData = {};
 var sys_index = 0;
 function easyPost(url, data, t, func, inter) {

     if (sys_cacheData[data.mname]) {
         //console.log('##cache##'+sys_cacheData[data.mname]);
         $(t).html(sys_cacheData[data.mname]);
     } else {
         sys_index++;
         setTimeout(function () {
             $(t).html('<img src="../images/loding_1.jpg.gif"/*tpa=http://www.nbjy.org.cn/Content/images/loding_1.jpg*/ style="width:32px;height:auto;"/>');

             $.post(url, data, function (ht) {
                 var nht = $('<div></div>').html(ht).text();
                 if (data.mname)
                     sys_cacheData[data.mname] = nht;
                 $(t).html(nht);
                 if (func)
                     func(ht);
             });

         }, 50);
     }
 }