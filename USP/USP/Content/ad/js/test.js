var adStr='<div id="imgads" style="Z-INDEX: 1009; LEFT: 2px; WIDTH: 230px; POSITION: absolute; TOP: 43px; HEIGHT: 75px;visibility: visible;" onmouseover="pause_resume()" onmouseout="pause_resume()">';
   adStr+='<a href="../../../2016jyzx/pxjg.html"/*tpa=http://www.nbjy.org.cn/2016jyzx/pxjg.html*/ target="_blank"><img src="../images/2016jyzx.jpg"/*tpa=http://www.nbjy.org.cn/content/ad/images/2016jyzx.jpg*/ width="230" height="75" border="0"></a></div>';

var adStr2='<div id="imgads2" style="Z-INDEX: 1010; LEFT: 800px; WIDTH: 230px; POSITION: absolute; TOP: 43px; HEIGHT: 75px;visibility: visible;" onmouseover="pause_resume2()" onmouseout="pause_resume2()">';
   adStr2+='<a href="../../../cn/tzgg/3260.html"/*tpa=http://www.nbjy.org.cn/cn/tzgg/3260.html*/ target="_blank"><img src="../images/foreigner.jpg"/*tpa=http://www.nbjy.org.cn/content/ad/images/foreigner.jpg*/ width="230" height="75" border="0"></a></div>';
   $("body").append(adStr);
$("body").append(adStr2);
var xPos = 300;
var yPos = 200; 
var step = 1;
var delay = 30; 
var width = 0;
var height = 0;
var Hoffset = 0;
var Woffset = 0;
var yon = 0;
var xon = 0;
var pause = true;
var interval;
imgads.style.top = yPos;

var xPos2 = 600;
var yPos2 = 200; 
var Hoffset2 = 0;
var Woffset2 = 0;
var yon2 = 0;
var xon2 = 0;
var pause2 = true;
var interval2;
imgads2.style.top = yPos2;

function changePos() 
{
	width = document.body.clientWidth;
	height = document.body.clientHeight;
	Hoffset = imgads.offsetHeight;
	Woffset = imgads.offsetWidth;
	imgads.style.left = xPos + document.body.scrollLeft;
	imgads.style.top = yPos + document.body.scrollTop;
	if (yon) 
		{yPos = yPos + step;}
	else 
		{yPos = yPos - step;}

	if (yPos < 0) 
		{yon = 1;yPos = 0;}

	if (yPos >= (height - Hoffset)) 
		{yon = 0;yPos = (height - Hoffset);}

	if (xon) 
		{xPos = xPos + step;}
	else 
		{xPos = xPos - step;}

	if (xPos < 0) 
		{xon = 1;xPos = 0;}
	if (xPos >= (width - Woffset)) 
		{xon = 0;xPos = (width - Woffset); }
}
function changePos2() 
{
	width = document.body.clientWidth;
	height = document.body.clientHeight;
	Hoffset2 = imgads2.offsetHeight;
	Woffset2 = imgads2.offsetWidth;
        imgads2.style.left = xPos2 + document.body.scrollLeft;
	imgads2.style.top = yPos2 + document.body.scrollTop;

	if (yon2) 
		{yPos2 = yPos2 + step;}
	else 
		{yPos2 = yPos2 - step;}

	if (yPos2 < 0) 
		{yon2 = 1;yPos2 = 0;}

	if (yPos2 >= (height - Hoffset2)) 
		{yon2 = 0;yPos2 = (height - Hoffset2);}

	if (xon2) 
		{xPos2 = xPos2 + step;}
	else 
		{xPos2 = xPos2 - step;}

	if (xPos2 < 0) 
		{xon2 = 1;xPos2 = 0;}
	if (xPos2 >= (width - Woffset2)) 
		{xon2 = 0;xPos2 = (width - Woffset2); }
}
	
function start()
{
	imgads.visibility = "visible";
	imgads2.visibility = "visible";
	interval = setInterval('changePos()', delay);
	interval2 = setInterval('changePos2()', delay);
}
function pause_resume() 
{
	if(pause) 
	{
		clearInterval(interval);
		pause = false;
        }
	else 
	{
		interval = setInterval('changePos()',delay);
		pause = true; 
	}
}
function pause_resume2() 
{
	if(pause2) 
	{
		clearInterval(interval2);
		pause2 = false;
        }
	else 
	{
		interval2 = setInterval('changePos2()',delay);
		pause2 = true; 
	}
}
start();