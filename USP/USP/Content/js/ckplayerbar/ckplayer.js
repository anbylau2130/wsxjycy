
function ckcpt() {
    var cpt = '';
    return cpt;
}

function ckstyle() { //定义总的风格
    var ck = {
        cpath: '',
        
        language: '',
        
        flashvars: '',
        setup: '1,1,1,1,1,2,0,1,0,0,'
		+'0,1,200,0,2,1,0,1,1,1,'
		+'0,10,3,0,1,0,3,0,0,0,'
		+'0,1,1,1,1,1,1,250,0,90,'
		+'0,0,0',
        /*
		这是配置文件里比较重要的一个参数，共有N个功能控制参数，并且以后会继续的增加，各控制参数以英文逗号(,)隔开。下面列出各参数的说明：
			1、鼠标经过按钮是否使用手型，0普通鼠标，1手型鼠标，2是只有按钮手型，3是控制栏手型
			2、是否支持单击暂停，0不支持，1是支持
			3、是否支持双击全屏，0不支持，1是支持
			4、在播放前置广告时是否同时加载视频，0不加载，1加载
			5、广告显示的参考对象，0是参考视频区域，1是参考播放器区域
			6、广告大小的调整方式,只针对swf和图片有效,视频是自动缩放的
				0=自动调整大小，意思是说大的话就变小，小的话就变大
				1=是大的化变小，小的话不变
				2=是什么也不变，就这么大
				3=是跟参考对像(第5个控制)参数设置的一样宽高
			7、前置广告播放顺序，0是顺序播放，1是随机播放，>1则随机取所有广告中的(N-1)个进行播放
			8、对于视频广告是否采用修正，0是不使用，1是使用，如果是1，则用户在网速慢的情况下会按设定的倒计时进行播放广告，计时结束则放正片（比较人性化），设置成0的话，则强制播放完广告才能播放正片
			9、是否开启滚动文字广告，0是不开启，1是开启且不使用关闭按钮，2是开启并且使用关闭按钮，开启后将在加载视频的时候加载滚动文字广告
			10、视频的调整方式
				0=是自动调整大小，意思是说大的话就变小，小的话就变大，同时保持长宽比例不变
				1=是大的化变小，小的话不变
				2=是什么也不变，就这么大
				3=是跟参考对像(pm_video的设置)参数设置的一样宽高
			11、是否在多视频时分段加载，0不是，1是
			12、缩放视频时是否进行平滑处理，0不是，1是
			13、视频缓冲时间,单位：毫秒,建议不超过300
			14、初始图片调整方式(
				0=是自动调整大小，意思是说大的话就变小，小的话就变大，同时保持长宽比例不变
				1=是大的化变小，小的话不变
				2=是什么也不变，就这么大
				3=是跟pm_video参数设置的一样宽高
			15、暂停广告调整方式(
				0=是自动调整大小，意思是说大的话就变小，小的话就变大，同时保持长宽比例不变
				1=是大的化变小，小的话不变
				2=是什么也不变，就这么大
				3=是跟pm_video参数设置的一样宽
			16、暂停广告是否使用关闭广告设置，0不使用，1使用
			17、缓冲时是否播放广告，0是不显示，1是显示并同时隐藏掉缓冲图标和进度，2是显示并不隐藏缓冲图标
			18、是否支持键盘空格键控制播放和暂停0不支持，1支持
			19、是否支持键盘左右方向键控制快进快退0不支持，1支持
			20、是否支持键盘上下方向键控制音量0不支持，1支持
			21、播放器返回js全部监听函数的等级，0-2,等级越高，返回的参数越多
				0=不返回全部监听事件
				1=返回监听，但不在控制台输出
				2=返回监听，并且在控制台同步输出
				3=返回全部监听事件，并且在参数前加上"播放器ID->"，用于多播放器的监听
			22、快进和快退的秒数
			23、界面上图片元素加载失败重新加载次数
			24、开启加载皮肤压缩文件包的加载进度提示
			25、使用隐藏控制栏时显示简单进度条的功能,0是不使用，1是使用，2是只在普通状态下使用
			26、控制栏隐藏设置(0不隐藏，1全屏时隐藏，2都隐藏
			27、控制栏隐藏延时时间，即在鼠标离开控制栏后多少毫秒后隐藏控制栏
			28、滚动文字广告左右滚动时是否采用无缝，默认0采用，1是不采用
			29、0是正常状态，1是控制栏默认隐藏，播放状态下鼠标经过播放器显示控制栏，2是一直隐藏控制栏
			30、在播放rtmp视频时暂停后点击播放是否采用重新链接的方式,这里一共分0-2三个等级
			31、当采用网址形式(flashvars里s=1/2时)读取视频地址时是采用默认0=get方法，1=post方式
			32、是否启用播放按钮和暂停按钮
			33、是否启用中间暂停按钮
			34、是否启用静音按钮
			35、是否启用全屏按钮
			36、是否启用进度调节栏,0不启用，1是启用，2是只能前进（向右拖动），3是只能后退，4是只能前进但能回到第一次拖动时的位置，5是看过的地方可以随意拖动，
			37、是否启用调节音量
			38、计算时间的间隔，毫秒
			39、前置logo至少显示的时间，单位：毫秒
			40、前置视频广告的默认音量
			41、当s=3/4时加载插件是否从压缩包里加载，0不是，1是
			42、加载风格是否采用加密方式传送，该功能普通用户不能使用
			43、在s=1/2时，调用地址里的地址是否是相对地址（相对于调用文件），0不是，1是
		*/
        pm_bg: '0x000000,100,230,180',

        mylogo: 'null',

        pm_mylogo: '1,1,-100,-55',
        
        logo: 'null',

        pm_logo: '2,0,-100,20',
        
        control_rel: 'related.swf,ckplayer/related.xml,0',

        control_pv: 'Preview.swf,105,2000',

        pm_repc: '',

        pm_spac: '|',

        pm_fpac: 'file->f',

        pm_advtime: '2,0,-110,10,0,300,0',

        pm_advstatus: '1,2,2,-200,-40',

        pm_advjp: '1,1,2,2,-100,-40',

        pm_padvc: '2,0,-13,-13',

        pm_advms: '2,2,-46,-67',

        pm_zip: '1,1,-20,-8,1,0,0',

		pm_advmarquee: '1,2,50,-70,50,20,0,0x000000,50,0,20,1,30,2000',

		pm_glowfilter:'1,0x01485d, 100, 6, 3, 10, 1, 0, 0',

        advmarquee: escape('{a href="http://www.ckplayer.com/"}{font color="#FFFFFF" size="12" face="Microsoft YaHei"}这里可以放文字广告，播放器默认使用这里设置的广告内容，如果不想在这里使用可以清空这里的内容，如果想在页面中实时定义滚动文字广告内容，可以清空这里的内容，然后在页面中设置广告函数。{/font}{/a}'),

		mainfuntion:'',

		flashplayer:'',

		calljs:'ckplayer_status,ckadjump,playerstop,ckmarqueeadv',

        myweb: escape(''),

        cpt_lights: '1',

        cpt_share: 'http://www.nbjy.org.cn/content/js/ckplayerbar/ckplayer/share.xml',

        cpt_list: ckcpt()

    }
    return ck;
}

(function() {
    var CKobject = {
        _K_: function(d){return document.getElementById(d);},
        _T_: false,
		_M_: false,
		_G_: false,
		_Y_: false,
		_I_: null,
		_J_: 0,
		_O_: {},
		uaMatch:function(u,rMsie,rFirefox,rOpera,rChrome,rSafari,rSafari2,mozilla,mobile){
			var match = rMsie.exec(u);
			if (match != null) {
				return {
					b: 'IE',
					v: match[2] || '0'
				}
			}
			match = rFirefox.exec(u);
			if (match != null) {
				return {
					b: match[1] || '',
					v: match[2] || '0'
				}
			}
			match = rOpera.exec(u);
			if (match != null) {
				return {
					b: match[1] || '',
					v: match[2] || '0'
				}
			}
			match = rChrome.exec(u);
			if (match != null) {
				return {
					b: match[1] || '',
					v: match[2] || '0'
				}
			}
			match = rSafari.exec(u);
			if (match != null) {
				return {
					b: match[2] || '',
					v: match[1] || '0'
				}
			}
			match = rSafari2.exec(u);
			if (match != null) {
				return {
					b: match[1] || '',
					v: match[2] || '0'
				}
			}
			match = mozilla.exec(u);
			if (match != null) {
				return {
					b: match[1] || '',
					v: match[2] || '0'
				}
			}
			match = mobile.exec(u);
			if (match != null) {
				return {
					b: match[1] || '',
					v: match[2] || '0'
				}
			}
			else {
				return {
					b: 'unknown',
					v: '0'
				}
			}
		},
		browser: function() {
			var u = navigator.userAgent,
			rMsie = /(msie\s|trident.*rv:)([\w.]+)/,
			rFirefox = /(firefox)\/([\w.]+)/,
			rOpera = /(opera).+version\/([\w.]+)/,
			rChrome = /(chrome)\/([\w.]+)/,
			rSafari = /version\/([\w.]+).*(safari)/,
			rSafari2 = /(safari)\/([\w.]+)/,
			mozilla = /(mozilla)\/([\w.]+)/,
			mobile = /(mobile)\/([\w.]+)/;
			var c = u.toLowerCase();
			var d = this.uaMatch(c,rMsie,rFirefox,rOpera,rChrome,rSafari,rSafari2,mozilla,mobile);
			if (d.b) {
				b = d.b;
				v = d.v;
			}
			return {B: b, V: v};
        },
        Platform: function() {
            var w = '';
            var u = navigator.userAgent,
            app = navigator.appVersion;
            var b = {
                iPhone: u.indexOf('iPhone') > -1 || u.indexOf('Mac') > -1,
                iPad: u.indexOf('iPad') > -1,
                ios: !!u.match(/\(i[^;]+;( U;)? CPU.+Mac OS X/),
                android: u.indexOf('Android') > -1 || u.indexOf('Linux') > -1,
                webKit: u.indexOf('AppleWebKit') > -1,
				trident: u.indexOf('Trident') > -1,
                gecko: u.indexOf('Gecko') > -1 && u.indexOf('KHTML') == -1,
                presto: u.indexOf('Presto') > -1,
                mobile: !!u.match(/AppleWebKit.*Mobile.*/) || !!u.match(/AppleWebKit/),
                webApp: u.indexOf('Safari') == -1
            };
            for (var k in b) {
                if (b[k]) {
                    w = k;
                    break;
                }
            }
            return w;
        },
		isHTML5:function(){
			return !!document.createElement('video').canPlayType;
		},
		getType:function(){
			return this._T_;
		},
        getVideo: function() {
            var v = '';
            var s = this._E_['v'];
            if (s && s.length>1) {
                for (var i = 0; i < s.length; i++) {
                    var a = s[i].split('->');
                    if (a.length >= 1 && a[0] != '') {
                        v += '<source src="' + a[0] + '"';
                    }
                    if (a.length >= 2 && a[1] != '') {
                        v += ' type="' + a[1] + '"';
                    }
                    v += '>';
                }
            }
            return v;
        },
        getVars: function(k) {
			var o=this._A_;
			if (typeof(o) == 'undefined') { 
				return null;
			}
            if (k in o) {
                return o[k];
            } else {
                return null;
            }
        },
        getParams: function() {
            var p = '';
            if (this._A_) {
                if (parseInt(this.getVars('p')) == 1) {
                    p += ' autoplay="autoplay"';
                }
                if (parseInt(this.getVars('e')) == 1) {
                    p += ' loop="loop"';
                }
                if (parseInt(this.getVars('p')) == 2) {
                    p += ' preload="metadata"';
                }
                if (this.getVars('i')) {
                    p += ' poster="' + this.getVars('i') + '"';
                }
            }
            return p;
        },
        getpath: function(z) {
			var f='CDEFGHIJKLMNOPQRSTUVWXYZcdefghijklmnopqrstuvwxyz';
			var w=z.substr(0,1);
			if(f.indexOf(w)>-1 && (z.substr(0,4)==w+'://' || z.substr(0,4)==w+':\\')){
				return z;
			}
            var d = unescape(window.location.href).replace('file:///', '');
            var k = parseInt(document.location.port);
            var u = document.location.protocol + '//' + document.location.hostname;
            var l = '',
            e = '',
            t = '';
            var s = 0;
            var r = unescape(z).split('//');
            if (r.length > 0) {
                l = r[0] + '//'
            }
            var h = 'http|https|ftp|rtsp|mms|ftp|rtmp|file';
            var a = h.split('|');
            if (k != 80 && k) {
                u += ':' + k;
            }
            for (i = 0; i < a.length; i++) {
                if ((a[i] + '://') == l) {
                    s = 1;
                    break;
                }
            }
            if (s == 0) {
                if (z.substr(0, 1) == '/') {
                    t = u + z;
                } else {
                    e = d.substring(0, d.lastIndexOf('/') + 1).replace('\\', '/');
                    var w = z.replace('../', './');
                    var u = w.split('./');
                    var n = u.length;
                    var r = w.replace('./', '');
                    var q = e.split('/');
                    var j = q.length - n;
                    for (i = 0; i < j; i++) {
                        t += q[i] + '/';
                    }
                    t += r;
                }
            } else {
                t = z;
            }
            return t;
        },
        getXhr: function() {
            var x;
            try {
                x = new ActiveXObject('Msxml2.XMLHTTP');
            } catch(e) {
                try {
                    x = new ActiveXObject('Microsoft.XMLHTTP');
                } catch(e) {
                    x = false;
                }
            }
            if (!x && typeof XMLHttpRequest != 'undefined') {
                x = new XMLHttpRequest();
            }
            return x;
        },
		getX: function(){
			var f='ckstyle()';
			if (this.getVars('x') && parseInt(this.getVars('c'))!=1 ) {
				f=this.getVars('x')+'()';
			}
			try {
				if (typeof(eval(f)) == 'object') {
					this._X_ = eval(f);
				}
			} catch(e) {
				try {
					if (typeof(eval(ckstyle)) == 'object') {
						this._X_ = ckstyle();
					}
				} catch(e) {
					this._X_ = ckstyle();
				}
			}
		},
		getSn: function(s, n) {
			if(n>=0){
				return this._X_[s].split(',')[n];
			}
			else{
				return this._X_[s];
			}
        },
		getUrl: function(L, B) {
			var C = this;
            var b = ['get', 'utf-8'];
            if (L && L.length == 2) {
                var a = L[0];
                var c = L[1].split('/');
                if (c.length >= 2) {
                    b[0] = c[1];
                }
                if (c.length >= 3) {
                    b[1] = c[2];
                }
                this.ajax(b[0], b[1], a,
                function(s) {
                    if (s && s != 'error') {
                        var d = '',
                        e = s;
                        if (s.indexOf('}') > -1) {
                            var f = s.split('}');
                            for (var i = 0; i < f.length - 1; i++) {
                                d += f[i] + '}';
                                var h = f[i].replace('{', '').split('->');
                                if (h.length == 2) {
                                    C._A_[h[0]] = h[1];
                                }
                            }
                            e = f[f.length - 1];
                        }
                        C._E_['v'] = e.split(',');
                        if (B) {
                            C.showHtml5();
                        } else {
                            C.changeParams(d);
                            C.newAdr();
                        }
                    }
                });
            }
        },
        getflashvars: function(s) {
            var v = '',
            i = 0;
            if (s) {
                for (var k in s) {
                    if (i > 0) {
                        v += '&';
                    }
                    if (k == 'f' && s[k] && ! this.getSn('pm_repc',-1)) {
                        s[k] = this.getpath(s[k]);
                        if (s[k].indexOf('&') > -1) {
                            s[k] = encodeURIComponent(s[k]);
                        }
                    }
                    if (k == 'y' && s[k]) {
                        s[k] = this.getpath(s[k]);
                    }
                    v += k + '=' + s[k];
                    i++;
                }
            }
            return v;
        },
        getparam: function(s) {
            var w = '',
            v = '',
            o = {
                allowScriptAccess: 'always',
                allowFullScreen: true,
                quality: 'high',
                bgcolor: '#000'
            };
            if (s) {
                for (var k in s) {
                    o[k] = s[k];
                }
            }
            for (var e in o) {
                w += e + '="' + o[e] + '" ';
                v += '<param name="' + e + '" value="' + o[e] + '" />';
            }
            w = w.replace('movie=', 'src=');
            return {
                w: w,
                v: v
            };
        },
        getObjectById: function(s) {
			var C = this;
            if (C._T_) {
				C._V_=C._K_(s)
                return C ;
            }
            var x = null,
            y = C._K_(s),
            r = 'embed';
            if (y && y.nodeName == 'OBJECT') {
                if (typeof y.SetVariable != 'undefined') {
                   x= y;
                } else {
                    var z = y.getElementsByTagName(r)[0];
                    if (z) {
                        x= z;
                    }
                }
            }
            return x;
        },
        ajax: function(b, u, s, f) {
            var x = this.getXhr();
            var a = [],
            m = '';
            if (b == 'get') {
                if (s.indexOf('?') > -1) {
                    m = s + '&t=' + new Date().getTime();
                } else {
                    m = s + '?t=' + new Date().getTime();
                }
                x.open('get', m);
            } else {
                a = s.split('?');
                s = a[0],
                m = a[1];
                x.open('post', s, true);
            }
            x.setRequestHeader('Content-Type', 'application/x-www-form-urlencoded');
            x.setRequestHeader('charset', u);
            if (b == 'post') {
                x.send(m);
            } else {
                x.send(null);
            }
            x.onreadystatechange = function() {
                if (x.readyState == 4) {
                    var g = x.responseText;
                    if (g != '') {
                        f(g);
                    } else {
                        f(null);
                    }
                }
            }
        },
        addListener: function(e, f) {
			var o=this._V_;
			switch(e){
				case 'time':
					e='timeupdate';
					this.AT=f;
					f=this.addListenerTime;
					break;
				case 'totaltime':
					this.ATAll=f;
					return;
					break;
				default:
					break;
			}
			//console.log(typeof(f));
			if(typeof(f)=='string'){
				f=eval(f);
			}
            if (o.addEventListener) {
				try{
                	o.addEventListener(e, f, false);
				}
				catch (e) {
					 this.getNot();
				}
            }
			else if (o.attachEvent) {
				try{
                	o.attachEvent('on' + e, f);
				}
				catch(e){
					 this.getNot();
				}
            }
			else {
                o['on' + e] = f;
            }
        },
        removeListener: function( e, f) {
			var o=this._V_;
			switch(e){
				case 'time':
					e='timeupdate';
					this.AT=null;
					break;
				case 'totaltime':
					this.ATAll=null;
					return;
					break;
				default:
					break;
			}
			if(typeof(f)=='string'){
				f=eval(f);
			}
            if (o.removeEventListener) {
				try{
                	o.removeEventListener(e, f, false);
				}
				catch(e){
					 this.getNot();
				}
			}
			else if (o.detachEvent) {
				try{
                	o.detachEvent('on' + e, f);
				}
				catch(e){
					 this.getNot();
				}
			}
			else {
                o['on' + e] = null;
            }
        },
        Flash: function() {
            var f = false,v = 0;
            if (document.all  || this.browser()['B'].toLowerCase().indexOf('ie')>-1) {
                try {
                    var s = new ActiveXObject('ShockwaveFlash.ShockwaveFlash');
                    f = true;
                    var z = s.GetVariable('$version');
                    v = parseInt(z.split(' ')[1].split(',')[0]);
                } catch(e) {}
            } else {
                if (navigator.plugins && navigator.plugins.length > 0) {
                    var s = navigator.plugins['Shockwave Flash'];
                    if (s) {
                        f = true;
                        var w = s.description.split(' ');
                        for (var i = 0; i < w.length; ++i) {
                            if (isNaN(parseInt(w[i]))) continue;
                            v = parseInt(w[i]);
                        }
                    }
                }
            }
            return {
                f: f,
                v: v
            };
        },
		embed:function(f,d,i,w,h,b,v,e,p,j){
			var s=['all'];
			if(b){
				if(this.isHTML5()){
					this.embedHTML5(d,i,w,h,e,v,s,j);
				}
				else{
					this.embedSWF(f,d,i,w,h,v,p);
				}
			}
			else{
				if(this.Flash()['f'] && parseInt(this.Flash()['v'])>10){
					this.embedSWF(f,d,i,w,h,v,p);
				}
				else if(this.isHTML5()){
					this.embedHTML5(d,i,w,h,e,v,s,j);
				}
				else{
					this.embedSWF(f,d,i,w,h,v,p);
				}
			}
		},
		embedSWF: function(C, D, N, W, H, V, P) {
            if (!N) {
                N = 'ckplayer_a1'
            }
            if (!P) {
                P = {
                    bgcolor: '#FFF',
                    allowFullScreen: true,
                    allowScriptAccess: 'always',
					wmode:'transparent'
                };
            }
			this._A_=V;
			this.getX();
            var u = 'undefined',
			g = false,
            j = document,
            r = 'http://www.macromedia.com/go/getflashplayer',
            t = '<a href="' + r + '" target="_blank">请点击此处下载安装最新的flash插件</a>',
            error = {
                w: '您的网页不符合w3c标准，无法显示播放器',
                f: '您没有安装flash插件，无法播放视频，' + t,
                v: '您的flash插件版本过低，无法播放视频，' + t
            },
            w3c = typeof j.getElementById != u && typeof j.getElementsByTagName != u && typeof j.createElement != u,
            i = 'id="' + N + '" name="' + N + '" ',
            s = '',
            l = '';
            P['movie'] = C;
            P['flashvars'] = this.getflashvars(V);
			if(W==-1){
				d=true;
				this._K_(D).style.width='100%';
				W='100%';
			}
            s += '<object pluginspage="http://www.macromedia.com/go/getflashplayer" ';
            s += 'classid="clsid:d27cdb6e-ae6d-11cf-96b8-444553540000" ';
            s += 'codebase="swflash.cab#version=11,3,0,0"/*tpa=http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=11,3,0,0*/ ';
            s += 'width="' + W + '" ';
            s += 'height="' + H + '" ';
            s += i;
            s += 'align="middle">';
            s += this.getparam(P)['v'];
            s += '<embed ';
            s += this.getparam(P)['w'];
            s += ' width="' + W + '" height="' + H + '" name="' + N + '" id="' + N + '" align="middle" ' + i;
            s += 'type="application/x-shockwave-flash" pluginspage="' + r + '" />';
            s += '</object>';
            if (!w3c) {
                l = error['w'];
				g = true;
            } else {
                if (!this.Flash()['f']) {
                    l = error['f'];
					g = true;
                } else {
                    if (this.Flash()['v'] < 11) {
                        l = error['v'];
						g = true;
                    } else {
                        l = s;
						this._T_=false;
                    }
                }
            }
            if (l) {
                this._K_(D).innerHTML = l;
            }
			if (g){
				this._K_(D).style.color = '#0066cc';
				this._K_(D).style.lineHeight = this._K_(D).style.height;
				this._K_(D).style.textAlign= 'center';
			}
        },
        embedHTML5: function(C, P, W, H, V, A, S, J) {
            this._E_ = {
                c: C,
                p: P,
                w: W,
                h: H,
                v: V,
                s: S,
				j: J==undefined || J?true:false
            };
            this._A_ = A;
			this.getX();
            b = this.browser()['B'],
            v = this.browser()['V'],
            x = v.split('.'),
            t = x[0],
            m = b + v,
            n = b + t,
            w = '',
            s = false,
            f = this.Flash()['f'],
            a = false;
            if (!S) {
                S = ['iPad', 'iPhone', 'ios'];
            }
            for (var i = 0; i < S.length; i++) {
                w = S[i];
                if (w.toLowerCase() == 'all') {
                    s = true;
                    break;
                }
                if (w.toLowerCase() == 'all+false' && !f) {
                    s = true;
                    break;
                }
                if (w.indexOf('+') > -1) {
                    w = w.split('+')[0];
                    a = true;
                } else {
                    a = false;
                }
                if (this.Platform() == w || m == w || n == w || b == w) {
                    if (a) {
                        if (!f) {
                            s = true;
                            break;
                        }
                    }else {
                        s = true;
                        break;
                    }
                }
            }
            if (s) {
                if (V) {
                    var l = V[0].split('->');
                    if (l && l.length == 2 && l[1].indexOf('ajax') > -1) {
                        this.getUrl(l, true);
                        return;
                    }
                }
                this.showHtml5();
            }
        },
        status: function() {
            this._H_ = parseInt(this.getSn('setup', 20));
			var f='ckplayer_status';
			if (this.getSn('calljs', 0)!='') {
				f=this.getSn('calljs', 0);
			}
			try {
				if (typeof(eval(f)) == 'function') {
					this._L_=eval(f);
					this._M_=true;
					return true;
				}
			} catch(e) {
				try {
					if (typeof(eval(ckplayer_status)) == 'function') {
						this._L_=ckplayer_status;
						this._M_=true;
						return true;
					}
				} catch(e) {
					return false;
				}
			}
			return false;
        },
        showHtml5: function() {
            var C = this;
            var p = C._E_['p'],
			a = C._E_['v'],
			c = C._E_['c'],
			j = '',
			b = false;
			var s = this._E_['v'];
			var w=C._E_['w'],h=C._E_['h'];
			var d=false;
			var r='';
			if(s.length==1){
				r=' src="'+s[0].split('->')[0]+'"';
			}
			if(w==-1){
				d=true;
				C._K_(c).style.width='100%';
				w='100%';
			}
			if(w.toString().indexOf('%')>-1){
				w='100%';
			}
			if(h.toString().indexOf('%')>-1){
				h='100%';
			}
			if(C._E_['j']){
				j=' controls="controls"';
			}
			var v = '<video'+j+r+' id="' + p + '" width="' + w + '" height="' + h + '"' + C.getParams() + ' webkit-playsinline>' + C.getVideo() + '</video>';
            C._K_(c).innerHTML = v;
            C._K_(c).style.backgroundColor = '#000';
            C._V_ = C._K_(p);
			if(!d){
				C._K_(c).style.width=C._E_['w'].toString().indexOf('%')>-1?(C._K_(c).offsetWidth*parseInt(C._E_['w'])*0.01)+'px':C._V_.width+'px';
				C._K_(c).style.height=C._E_['h'].toString().indexOf('%')>-1?(C._K_(c).offsetHeight*parseInt(C._E_['h'])*0.01)+'px':C._V_.height+'px';
			}
            C._P_ = false;
            C._T_ = true;
			if (C.getVars('loaded')!='') {
				var f=C.getVars('loaded')+'()';
				try {
                	if (typeof(eval(f)) == 'function') {
						eval(f);
					}
				} catch(e) {
					try {
						if (typeof(eval(loadedHandler)) == 'function') {
							loadedHandler();
						}
					} catch(e) {
					}
				}
            }
            C.status();
			C.addListener('play', C.playHandler);
			C.addListener('pause', C.playHandler);
			C.addListener('error', C.errorHandler);
			C.addListener('emptied', C.errorHandler);
			C.addListener('loadedmetadata', C.loadedMetadataHandler);
			C.addListener('ended', C.endedHandler);
			C.addListener('volumechange', C.volumeChangeHandler);
			if((C.getVars('m')!='' && C.getVars('m')!=null) || parseInt( C.getSn('setup', 0))>0){
				C._K_(c).style.cursor='pointer';
			}
			if((C.getVars('m')!='' && C.getVars('m')!=null) || parseInt( C.getSn('setup', 1))==1){
				C.addListener('click', C.html5Click);
			}
        },
		addListenerTime:function(){
			var C = CKobject;
			if(C.AT){
				C.AT(C._V_['currentTime']);
			}
		},
        videoPlay: function() {
            if (this._T_) {
                this._V_.play();
            }
        },
        videoPause: function() {
            if (this._T_) {
                this._V_.pause();
            }
        },
        playOrPause: function() {
            if (this._T_) {
                if (this._V_.paused) {
                    this._V_.play();
                } else {
                    this._V_.pause();
                }
            }
        },
        fastNext: function() {
            if (this._T_) {
                this._V_['currentTime'] = this._V_['currentTime'] + 10;
            }
        },
        fastBack: function() {
            if (this._T_) {
                this._V_['currentTime'] = this._V_['currentTime'] - 10;
            }
        },
        changeVolume: function(n) {
			if(n<0 || n>100){
				return;
			}
            if (this._T_) {
                this._V_['volume'] = n * 0.01;
            }
        },
        videoSeek: function(t) {
            if (this._T_) {
                this._V_['currentTime'] = t;
            }
        },
        newAddress: function(u) {
            var s = [];
            if (u) {
                s = this.isHtml5New(u);
            } else {
                return;
            }
            if (s && this._T_) {
                this.changeParams(u);
                var l = s[0].split('->');
                if (l && l.length == 2 && l[1].indexOf('ajax') > -1) {
                    this.getUrl(l, false);
                    return;
                }
                this._E_['v'] = s;
                this.newAdr();
            }
        },
		quitFullScreen:function() {
			if(document.cancelFullScreen) {
				document.cancelFullScreen();
			} 
			else if(document.mozCancelFullScreen) {
				document.mozCancelFullScreen();
			} else if(document.webkitCancelFullScreen) {
	   			document.webkitCancelFullScreen();
			}

		},
		changeStatus:function(n){
			this._H_=n;
		},
        newAdr: function() {
			var s = this._E_['v'];
            this._V_.pause();
			if(s.length==1){
            	this._V_.src=s[0].split('->')[0];
			}
			else{
				this._V_['innerHTML'] = this.getVideo();
			}
            this._V_.load();
        },
        isHtml5New: function(s) {
            if (s.indexOf('html5') == -1) {
                return false;
            }
            var a = s.replace(/{/g, '');
            var b = a.split('}');
            var c = '';
            for (var i = 0; i < b.length; i++) {
                if (b[i].indexOf('html5') > -1) {
                    c = b[i].replace('html5->', '').split(',');
                    break;
                }
            }
            return c;
        },
        changeParams: function(f) {
            if (f) {
                var a = f.replace(/{/g, '');
                var b = a.split('}');
                var c = '';
                for (var i = 0; i < b.length; i++) {
                    var d = b[i].split('->');
					if(d.length == 2){
						switch(d[0]){
							case 'p':
								if(parseInt(d[1]) == 1){
									this._V_.autoplay = true;
								}
								else if(parseInt(d[1]) == 2){
									this._V_.preload = 'metadata';
								}
								else{
									this._V_.autoplay = false;
									if(this._I_!=null){
										clearInterval(this._I_);
										this._I_=null;
									}
								}
								break;
							case 'e':
								if(parseInt(d[1]) == 1){
									this._V_.loop = true;
								}
								else{
									this._V_.loop = false;
								}
								break;
							case 'i':
								this._V_.poster = d[1];
								break;
							default:
								break;
						}
					}
                }
            }
        },
        frontAdPause: function(s) {
            this.getNot();
        },
        frontAdUnload: function() {
            this.getNot();
        },
        changeFace: function(s) {
            this.getNot();
        },
        plugin: function(a, b, c, d, e, f, g) {
            this.getNot();
        },
        videoClear: function() {
            this.getNot();
        },
        videoBrightness: function(s) {
            this.getNot();
        },
        videoContrast: function(s) {
            this.getNot();
        },
        videoSaturation: function(s) {
            this.getNot();
        },
        videoSetHue: function(s) {
            this.getNot();
        },
        videoWAndH: function(a, b) {
            this.getNot();
        },
        videoWHXY: function(a, b, c, d) {
            this.getNot();
        },
		changeFlashvars: function(a) {
            this.getNot();
        },
		changeMyObject: function(a, b) {
            this.getNot();
        },
		getMyObject: function(a, b) {
            this.getNot();
        },
		changeeFace: function() {
            this.getNot();
        },
		changeStyle: function(a, b) {
            this.getNot();
        },
		promptLoad: function() {
            this.getNot();
        },
		promptUnload: function() {
            this.getNot();
        },
		marqueeLoad: function(a,b) {
            this.getNot();
        },
		marqueeClose: function(s) {
            this.getNot();
        },
		videoError: function(s) {
            this.getNot();
        },
		formatUrl: function(s) {
            this.getNot();
        },
		sendJS: function(s) {
            this.getNot();
        },
		plugAttribute: function(s) {
            this.getNot();
        },
		errorTextShow: function(s) {
            this.getNot();
        },
		openUrl: function(s) {
            window.open(s);
        },
		jsonParse: function(s) {
            this.getNot();
        },
		promptShow: function(s,x,y) {
            this.getNot();
        },
		screenShot: function(s,x,y,x2,y2) {
            this.getNot();
        },
		fullScreen: function() {
            this.getNot();
        },
		allowFull: function() {
            this.getNot();
        },
		loadButton: function() {
            this.getNot();
        },
		getFile: function() {
            this.getNot();
        },
		textBoxShow:function() {
            this.getNot();
        },
		loadElement: function() {
            this.getNot();
        },
		textBoxClose: function() {
            this.getNot();
        },
		textBoxTween: function() {
            this.getNot();
        },
        getNot: function() {
            var s='The ckplayer\'s API for HTML5 does not exist';
			return s;
        },
        volumeChangeHandler: function() {
            var C = CKobject;
            if (C._V_.muted) {
                C.returnStatus('volumechange:0', 1);
                C._O_['volume'] = 0;
                C._O_['mute'] = true;
            } else {
                C._O_['mute'] = false;
                C._O_['volume'] = C._V_['volume'] * 100;
                C.returnStatus('volumechange:'+C._V_['volume'] * 100, 1);
            }
        },
        endedHandler: function() {
            var C = CKobject;
			var e=parseInt(C.getVars('e'));
            C.returnStatus('ended', 1);
			if(C._I_){
				clearInterval(C._I_);
				C._I_=null;
			}
            if ( e!= 0 && e !=4 && e !=6) {
                return;
            }
			if(e==6){
				this.quitFullScreen();
			}
			var f='playerstop()';
			if (C.getSn('calljs', 2)!='') {
				f=C.getSn('calljs', 2)+'()';
			}
			try {
				if (typeof(eval(f)) == 'function') {
					eval(f);
					return;
				}
			} catch(e) {
				try {
					if (typeof(eval(playerstop)) == 'function') {
						playerstop();
						return;
					}
				} catch(e) {
					return;
				}
			}
        },
        loadedMetadataHandler: function() {
            var C = CKobject;
            C.returnStatus('loadedmetadata', 1);
            C._O_['totalTime'] = C._V_['duration'];
            C._O_['width'] = C._V_['width'];
            C._O_['height'] = C._V_['height'];
            C._O_['awidth'] = C._V_['videoWidth'];
            C._O_['aheight'] = C._V_['videoHeight'];
            if (C._V_.defaultMuted) {
                C.returnStatus('volumechange:0', 1);
                C._O_['mute'] = true;
                C._O_['volume'] = 0;
            } else {
                C._O_['mute'] = false;
                C._O_['volume'] = C._V_['volume'] * 100;
                C.returnStatus('volumechange:'+C._V_['volume'] * 100, 1);
            }
			if (parseInt(C.getVars('p')) == 1) {
				C.playHandler();
			}
			if(C.ATAll){
				C.ATAll(C._V_['duration']);
			}
        },
        errorHandler: function() {
            CKobject.returnStatus('error', 1);
        },
        playHandler: function() {
            var C = CKobject;
            if (C._V_.paused) {
                C.returnStatus('pause', 1);
                C.addO('play', false);
				if(C._I_!=null){
					clearInterval(C._I_);
					C._I_=null;
				}
            } else {
                C.returnStatus('play', 1);
                C.addO('play', true);
                if (!C._P_) {
                    C.returnStatus('play', 1);
                    C._P_ = true;
                }
                C._I_ = setInterval(C.playTime, parseInt( C.getSn('setup', 37)));
				if(!C._G_){
					C._G_=true;
					for(var k in C._A_){
						if(k=='g' && C._A_[k]){
							var g=parseInt(C._A_[k]);
							C.videoSeek(g);
						}	
					}
				}
				if(!C._Y_){
					C._Y_=true;
					for(var k in C._A_){
						if(k=='j' && C._A_[k]){
							var j=parseInt(C._A_[k]);
							if(j>0){
								C._J_=j;
							}
							else{
								C._J_=parseInt(C._O_['totalTime'])+j;
							}
						}	
					}
				}
            }
        },
		html5Click: function(){
			//console.log(this);
			var C = CKobject;
			if(C.getVars('m')!='' && C.getVars('m')!=null){
				window.open(C.getVars('m'));
			}
		},
        returnStatus: function(s, j) {
            var h = s;
            if (this._H_ == 3) {
                h = this._E_['p'] +'->'+ h;
            }
            if (this._M_ && j <= this._H_ ) {
                this._L_(h);
            }
        },
        addO: function(s, z) {
            this._O_[s] = z;
        },
        getStatus: function() {
            return this._O_;
        },
        playTime: function() {
            var C = CKobject;
            var t = C._V_['currentTime'];
            C._O_['time'] = t;
			if(C._J_>0 && t>C._J_){
				C._J_=0;
				C.videoSeek(C._O_['totaltime']);
			}
            C.returnStatus('time:' + t, 1);
        }
    }
    window.CKobject = CKobject;
})();