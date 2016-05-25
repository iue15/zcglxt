; (function ($) {
    $.fn.zDialog = function (options) {
        var self = this;
        var el = self.get(0);
        function build() {
            return $.extend({
            	ClosePage: el.zDialog ? $.proxy(el.zDialog.ClosePage, el.ClosePage) : null,
            	OpenPage: el.zDialog ? $.proxy(el.zDialog.OpenPage, el.OpenPage) : null
            }, self);
        }
        if (el.zDialog) { return build(); };
        var defaults = {
            DialogMap:{
        			Page1:null,
        			Page2:null,
        			Page3:null,
        			Page4:null,
        			Page5:null
        		}
        	};
        var op = $.extend(defaults, options || {});
        var zDialog = {
                options : op,
        		ClosePage:function (pageid,obj){
        			this.options.DialogMap[pageid].close();
                    this.options.DialogMap[pageid].Callback(obj);
        			this.options.DialogMap[pageid]=null;
        		},
        		OpenPage :function (p){
                    var sf=this;
        			var d=new top.Dialog();
        	    	d.Width=100;
        			d.Height=100;
        			var pageid="";
        			$.each(this.options.DialogMap, function(key,value){
        				if(value){}
        				else {
        					pageid=key;
        					return false;
        				}
        			});
        			if(typeof p ==="string") {
        				d.URL=p+"&PageID="+pageid+"&"+new Date().getTime();
        			} else {
                        d.InnerHtml= p.InnerHtml == null ? "" : p.InnerHtml;
        				d.URL = p.url == null ? "" : p.url+"&PageID="+pageid+"&"+new Date().getTime();
        	            d.Width =  p.width == null ? "100": p.width;  //
        	            d.Height = p.height == null ? "100" : p.height;  //
        	            d.Title = p.title == null ? "" : p.title;  //
                        d.CancelEvent=p.CancelEvent?p.CancelEvent:function(){
                            sf.options.DialogMap[pageid].close();
                            sf.options.DialogMap[pageid].Callback(null);
        			        sf.options.DialogMap[pageid]=null;
                        };
                        d.OKEvent=p.OKEvent?p.OKEvent:null;
                        d.ShowButtonRow=p.ShowButtonRow?p.ShowButtonRow:false;
                        d.Callback=p.Callback?p.Callback:null;
        			}
        			this.options.DialogMap[pageid]=d;
        			d.show();
        			return pageid;
        		}
        };
        el.zDialog = zDialog;
        return build();
    }
})(jQuery);
$(top).zDialog();